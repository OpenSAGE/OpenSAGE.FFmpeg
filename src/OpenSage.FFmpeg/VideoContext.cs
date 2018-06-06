using System;
using System.Collections.Generic;
using System.Text;
using OpenSage.FFmpegNative;

namespace OpenSage.FFmpeg
{
    public sealed unsafe class VideoContext : StreamContext
    {
        private AVFrame* _rescaled;
        private byte* _rescaledBuf;
        private SwsContext* _rescaler;
        private DataLayout _inputLayout;
        private AVPixelFormat _outputFmt;
        private int _numBytes;

        /// <summary>
        /// Called once for each video stream
        /// </summary>
        /// <param name="stream">the underlying libav stream</param>
        /// <param name="source">the container</param>
        internal VideoContext(AVStream* stream, Source source) : base(stream, source)
        {
            _type = StreamType.Video;
            var ratio = _stream->avg_frame_rate;
            _info = new VideoStreamInfo()
            {
                BitRate = _codecCtx->bit_rate,
                Width = _codecCtx->width,
                Height = _codecCtx->height,
                Fps = ratio.num / ratio.den
            };

            CreateVideo();
        }

        /// <summary>
        /// Create the audio buffers in the handler. Check if resampling is required
        /// </summary>
        private void CreateVideo()
        {
            var vidHandler = _source.VideoHandler;

            _outputFmt = (vidHandler.Layout == DataLayout.Planar) ? AVPixelFormat.AV_PIX_FMT_YUV420P :
                                                                    AVPixelFormat.AV_PIX_FMT_RGB24;
            //TODO: fix this to handle the index correctly
            var vidInfo = _info as VideoStreamInfo;
            vidHandler?.CreateTexture(0, vidInfo.Width, vidInfo.Height);

            _rescaled = ffmpeg.av_frame_alloc();

            _numBytes = ffmpeg.avpicture_get_size(_outputFmt, vidInfo.Width, vidInfo.Height);

            _rescaledBuf = (byte*)ffmpeg.av_malloc((ulong)_numBytes);

            ffmpeg.avpicture_fill((AVPicture*)_rescaled, _rescaledBuf, _outputFmt, vidInfo.Width, vidInfo.Height);
        }

        /// <summary>
        /// Called when a new packet arrives
        /// </summary>
        protected override void Update()
        {
            AVFrame* frame = _decoded;
            int planes = 0;

            for (uint i = 0u; i < 8u; ++i)
            {
                if (_decoded->data[i] != null)
                    ++planes;
            }

            var vidHandler = _source.VideoHandler;

            AVPixelFormat inputFmt = (AVPixelFormat)_decoded->format;
            bool resample = _outputFmt != inputFmt;

            if (resample)
            {
                var context = ffmpeg.sws_getContext(_decoded->width, _decoded->height, inputFmt, _decoded->width, _decoded->height, _outputFmt, ffmpeg.SWS_FAST_BILINEAR, null, null, null);

                ffmpeg.sws_scale(context, frame->data, frame->linesize, 0, _codecCtx->height, _rescaled->data, _rescaled->linesize);

                //Update the texture with the rescaled data
                vidHandler?.UpdateTexture(0, (IntPtr)_rescaled->data[0], _numBytes);
            }

            //Update the texture with the original data
            vidHandler?.UpdateTexture(0, (IntPtr)frame->data[0], _numBytes);
        }

    }
}
