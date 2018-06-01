using OpenSage.FFmpegNative;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace OpenSage.FFmpeg
{
    public enum PlayState
    {
        Playing,
        Stopped,
        Paused
    }

    public sealed unsafe class Source
    {
        //FFMPEG structs
        private AvStream _avStream;
        private AVFormatContext* _formatCtx;
        private AVPacket* _packet;

        private int _numVideoStreams;
        private int _numAudioStreams;
        private TimeSpan _duration;
        private List<StreamContext> _streams;
        private long _bitRate;
        private PlayState _state;

        private IVideoHandler _vidHandler;
        private IAudioHandler _audioHandler;

        public bool HasVideo => _numVideoStreams > 0;
        public bool HasAudio => _numAudioStreams > 0;

        public TimeSpan Duration => _duration;
        public long BitRate => _bitRate;

        public List<StreamContext> Streams => _streams;

        internal IVideoHandler VideoHandler => _vidHandler;
        internal IAudioHandler AudioHandler => _audioHandler;

        public Source(Stream stream,IVideoHandler vidHandler = null,IAudioHandler audioHandler=null)
        {
            _state = PlayState.Stopped;

            _vidHandler = vidHandler;
            _audioHandler = audioHandler;

            //allocate a new format context
            _formatCtx = ffmpeg.avformat_alloc_context();

            //create a custom avstream to read from C#'s Stream
            _avStream = new AvStream(stream);
            _avStream.Attach(_formatCtx);

            fixed (AVFormatContext** ctxPtr = &_formatCtx)
            {
                if(ffmpeg.avformat_open_input(ctxPtr, "", null, null)!=0)
                {
                    throw new InvalidDataException("Cannot open input");
                }
            }

            if(ffmpeg.avformat_find_stream_info(_formatCtx, null)<0)
            {
                throw new InvalidDataException("Cannot find stream info");
            }

            //allocate the streams list
            _streams = new List<StreamContext>();

            double ms = _formatCtx->duration / (double)ffmpeg.AV_TIME_BASE;
            _duration = TimeSpan.FromSeconds(ms);
            _bitRate = _formatCtx->bit_rate;

            _numVideoStreams = 0;
            _numAudioStreams = 0;

            //Iterate over all streams to get the overall number
            for (int i = 0; i < _formatCtx->nb_streams; i++)
            {
                var avStream = _formatCtx->streams[i];
                switch (avStream->codec->codec_type)
                {
                    case AVMediaType.AVMEDIA_TYPE_VIDEO:
                        _numVideoStreams++;
                        _streams.Add(new VideoContext(avStream,this));
                        break;
                    case AVMediaType.AVMEDIA_TYPE_AUDIO:
                        _numAudioStreams++;
                        _streams.Add(new AudioContext(avStream, this));
                        break;
                    default:
                        throw new NotSupportedException("Invalid stream type, which is not suppurted!");
                }
            }

            _packet = ffmpeg.av_packet_alloc();
        }

        public void Start()
        {
            //should reset to frame 0 
            if(_state==PlayState.Stopped)
            {
                Reset();
                _state = PlayState.Playing;
            }

            while(_state==PlayState.Playing && (ffmpeg.av_read_frame(_formatCtx,_packet)>=0))
            {
                if(_packet==null)
                {
                    throw new InvalidDataException("Empty packet! Probably should continue");
                }

                int streamIdx = _packet->stream_index;

                var ctx = _streams[streamIdx];
                ctx.ReceivePacket(_packet);
            }

        }

        //reset the codecCtx
        private void Reset()
        {
            //flush the format context
            if(ffmpeg.avformat_flush(_formatCtx)<0)
            {
                throw new InvalidOperationException();
            }

            //flush all streams
            foreach (var stream in _streams)
            {
                stream.Reset();
            }

            //seek back to the beginning
            //if (ffmpeg.avio_seek(_avStream.GetContext(), 0, 0) < 0)
            //{
            //    throw new InvalidOperationException();
            //}

            for (int i = 0; i < _streams.Count; ++i)
            {
                if (ffmpeg.av_seek_frame(_formatCtx, i, 0, ffmpeg.AVSEEK_FLAG_FRAME) < 0)
                    throw new InvalidOperationException();
            }
        }

        ~Source()
        {
            fixed (AVFormatContext** ctxPtr = &_formatCtx)
            {
                ffmpeg.avformat_close_input(ctxPtr);
            };

            fixed (AVPacket** pktPtr = &_packet)
            {
                ffmpeg.av_packet_free(pktPtr);
            };
        }
    }
}
