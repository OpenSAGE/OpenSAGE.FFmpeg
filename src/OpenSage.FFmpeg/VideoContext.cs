using System;
using System.Collections.Generic;
using System.Text;
using OpenSage.FFmpegNative;

namespace OpenSage.FFmpeg
{
    public sealed unsafe class VideoContext : StreamContext
    {
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

            var vidHandler = _source.VideoHandler;
            //TODO: fix this to handle the index correctly
            var vidInfo = _info as VideoStreamInfo;
            vidHandler?.CreateTexture(0, vidInfo.Width, vidInfo.Height);
        }

        /// <summary>
        /// Called when a new packet arrives
        /// </summary>
        protected override void Update()
        {
            AVFrame* frame = _decoded;
        }

    }
}
