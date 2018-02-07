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

        private StreamType _type;
        private IStreamInfo _info; 

        public StreamType Type => _type;

        public StreamContext(AVStream* stream)
        {
            _stream = stream;
            
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
                    break;
                default:
                    throw new NotSupportedException();
            }


        }

    }
}
