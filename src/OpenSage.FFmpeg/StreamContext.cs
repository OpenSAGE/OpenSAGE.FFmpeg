using FFmpeg.AutoGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    public enum StreamType
    {
        Video,
        Audio
    }

    public unsafe sealed class StreamContext
    {
        private AVStream* _stream;
        private AVCodec* _codec;
        private AVCodecContext* _codecCtx;
        private Source _source;
        private AVFrame* _decoded;
        private TimeSpan _position;

        private StreamType _type;
        private IStreamInfo _info; 

        public StreamType Type => _type;

        public StreamContext(AVStream* stream,Source source)
        {
            _stream = stream;
            _source = source;
            
            var origCtx = _stream->codec;

            //find the corresponding codec
            _codec = ffmpeg.avcodec_find_decoder(origCtx->codec_id);
            if (_codec == null)
                throw new NotSupportedException("This " + ffmpeg.av_get_media_type_string(origCtx->codec_type) + 
                                                " codec is not supported by the current ffmpeg binaries!");

            //copy the context from ffmpeg (required because we don't own the other one)
            _codecCtx = ffmpeg.avcodec_alloc_context3(_codec);
            if (ffmpeg.avcodec_parameters_to_context(_codecCtx, _stream->codecpar) != 0)
            {
                throw new Exception("Couldn't copy stream parameters!");
            }

            if(ffmpeg.avcodec_open2(_codecCtx,_codec,null)!=0)
            {
                throw new Exception("Couldn't copy the codec!");
            }

            switch (_codec->type)
            {
                case AVMediaType.AVMEDIA_TYPE_AUDIO:
                    _type = StreamType.Audio;
                    _info = new AudioStreamInfo()
                    {
                        BitRate = _codecCtx->bit_rate,
                        Frequency = _codecCtx->sample_rate,
                        Channels = _codecCtx->channels
                    };

                    var audioHandler = _source.AudioHandler;
                    //TODO: fix this to handle the index correctly
                    var audioInfo = _info as AudioStreamInfo;
                    audioHandler?.CreateBuffer(0, audioInfo.Frequency, audioInfo.Channels, audioInfo.BitRate);
                    break;
                case AVMediaType.AVMEDIA_TYPE_VIDEO:
                    _type = StreamType.Video;
                    var ratio = _stream->avg_frame_rate;
                    _info = new VideoStreamInfo()
                    {
                        BitRate = _codecCtx->bit_rate,
                        Width = _codecCtx->width,
                        Height = _codecCtx->height,
                        Fps = ratio.num / ratio.den
                    };

                    var vidHandler = _source.VideoHandler;
                    //TODO: fix this to handle the index correctly
                    var vidInfo = _info as VideoStreamInfo;
                    vidHandler?.CreateTexture(0, vidInfo.Width, vidInfo.Height);
                    break;
                default:
                    throw new NotSupportedException();
            }

            _decoded = ffmpeg.av_frame_alloc();
        }

        public void ReceivePacket(AVPacket* packet)
        {
            //send the packet to the decoder
            ffmpeg.avcodec_send_packet(_codecCtx, packet);

            //get the decodec data
            ffmpeg.avcodec_receive_frame(_codecCtx, _decoded);
            double pts = ffmpeg.av_frame_get_best_effort_timestamp(_decoded);
            pts *= _codecCtx->time_base.num / _codecCtx->time_base.den;
            _position = TimeSpan.FromSeconds(pts);


            switch (_type)
            {
                case StreamType.Video:
                    UpdateVideo();
                    break;
                case StreamType.Audio:
                    UpdateAudio();
                    break;
            }
        }

        //interpret the decoded frame as audio
        private void UpdateAudio()
        {
            int data_size = ffmpeg.av_samples_get_buffer_size(null, _codecCtx->channels, _decoded->nb_samples, _codecCtx->sample_fmt, 1);

            var audioHandler = _source.AudioHandler;

            audioHandler.UpdateBuffer(new IntPtr(_decoded->data[0]), data_size);
        }

        //interpret the decoded frame as video
        private void UpdateVideo()
        {

        }


        internal void Reset()
        {
            //enter draining mode
            ffmpeg.avcodec_send_packet(_codecCtx, null);

            //receive frames until there is no more data
            while (ffmpeg.avcodec_receive_frame(_codecCtx, _decoded) != ffmpeg.AVERROR_EOF)
            { }

            ffmpeg.avcodec_flush_buffers(_codecCtx);
        }
    }
}
