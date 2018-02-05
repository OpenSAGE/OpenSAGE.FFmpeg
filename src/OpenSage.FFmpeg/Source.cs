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


        static Source()
        {
            ffmpeg.RootPath = Environment.CurrentDirectory;

            ffmpeg.av_register_all();
            ffmpeg.avcodec_register_all();
        }

        public Source(Stream stream)
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
