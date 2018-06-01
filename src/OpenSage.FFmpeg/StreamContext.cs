using OpenSage.FFmpegNative;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenSage.FFmpeg
{
    /// <summary>
    /// The type of stream
    /// </summary>
    public enum StreamType
    {
        Video,
        Audio
    }

    public abstract unsafe class StreamContext
    {
        internal AVStream* _stream;
        internal AVCodec* _codec;
        internal AVCodecContext* _codecCtx;
        internal Source _source;
        internal AVFrame* _decoded;
        private TimeSpan _position;

        protected StreamType _type;
        protected IStreamInfo _info; 

        public StreamType Type => _type;

        internal StreamContext(AVStream* stream,Source source)
        {
            _stream = stream;
            _source = source;
            var origCtx = _stream->codec;

            //find the corresponding codec
            _codec = ffmpeg.avcodec_find_decoder(origCtx->codec_id);
            if (_codec == null)
                throw new NotSupportedException("This " + Marshal.PtrToStringAnsi(ffmpeg.av_get_media_type_string(origCtx->codec_type)) + 
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


            _decoded = ffmpeg.av_frame_alloc();
        }

        /// <summary>
        /// Called by the demuxer when a new packet arrives
        /// </summary>
        internal void ReceivePacket(AVPacket* packet)
        {
            //send the packet to the decoder
            ffmpeg.avcodec_send_packet(_codecCtx, packet);

            //get the decodec data
            ffmpeg.avcodec_receive_frame(_codecCtx, _decoded);
            double pts = ffmpeg.av_frame_get_best_effort_timestamp(_decoded);
            pts *= _codecCtx->time_base.num / _codecCtx->time_base.den;
            _position = TimeSpan.FromSeconds(pts);

            Update();          
        }

        /// <summary>
        /// Called when a new packet arrives
        /// </summary>
        protected abstract void Update();

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
