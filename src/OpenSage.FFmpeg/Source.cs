using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FFmpeg.AutoGen;


namespace OpenSage.FFmpeg
{
    public unsafe sealed class Source
    {
        private AvStream _avStream;
        private AVFormatContext* _formatCtx;
        private int _numVideoStreams;
        private int _numAudioStreams;
        private TimeSpan _duration;

        private IVideoHandler _vidHandler;
        private IAudioHandler _audioHandler;

        public bool HasVideo => _numVideoStreams > 0;
        public bool HasAudio => _numAudioStreams > 0;

        static Source()
        {
            ffmpeg.RootPath = Environment.CurrentDirectory;

            ffmpeg.av_register_all();
            ffmpeg.avcodec_register_all();
        }

        public Source(Stream stream,IVideoHandler vidHandler = null,IAudioHandler audioHandler=null)
        {
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

            _numVideoStreams = 0;
            _numAudioStreams = 0;

            //Iterate over all streams to get the overall number
            for (int i = 0; i < _formatCtx->nb_streams; i++)
            {
                switch (_formatCtx->streams[i]->codec->codec_type)
                {
                    case AVMediaType.AVMEDIA_TYPE_VIDEO:
                        _numVideoStreams++;
                        break;
                    case AVMediaType.AVMEDIA_TYPE_AUDIO:
                        _numAudioStreams++;
                        break;
                    default:
                        throw new NotSupportedException("Invalid stream type, which is not suppurted!");
                }
            }

            double ms = _formatCtx->duration / (double)ffmpeg.AV_TIME_BASE;
            _duration = TimeSpan.FromMilliseconds(ms);

            for (int i = 0; i < _formatCtx->nb_streams; i++)
            {
                switch (_formatCtx->streams[i]->codec->codec_type)
                {
                    case AVMediaType.AVMEDIA_TYPE_VIDEO:
                        _numVideoStreams++;
                        break;
                    case AVMediaType.AVMEDIA_TYPE_AUDIO:
                        _numAudioStreams++;
                        break;
                    default:
                        throw new NotSupportedException("Invalid stream type, which is not suppurted!");
                }
            }


        }

        ~Source()
        {
            fixed (AVFormatContext** ctxPtr = &_formatCtx)
            {
                ffmpeg.avformat_close_input(ctxPtr);
            };
        }
    }
}
