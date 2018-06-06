using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenSage.FFmpegNative
{
    internal unsafe static partial class ffmpeg
    {
        private const string avformat = "avformat-58";
        private const string avcodec = "avcodec-58";
        private const string avutil = "avutil-56";
        private const string swresample = "swresample-3";
        private const string swscale = "swscale-5";

        //AVFORMAT
        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern void av_register_all();

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern AVFormatContext* avformat_alloc_context();

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int avformat_find_stream_info(AVFormatContext* @ic, AVDictionary** @options);

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern  int avformat_open_input(AVFormatContext** @ps, [MarshalAs(UnmanagedType.LPStr)] string @url, 
                                                                AVInputFormat* @fmt, AVDictionary** @options);

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern AVIOContext* avio_alloc_context(byte* @buffer, int @buffer_size, int @write_flag, void* @opaque, avio_alloc_context_read_packet_func @read_packet, 
            avio_alloc_context_write_packet_func @write_packet, avio_alloc_context_seek_func @seek);

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern AVInputFormat* av_probe_input_format(AVProbeData* @pd, int @is_opened);

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern int av_read_frame(AVFormatContext* @s, AVPacket* @pkt);

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern int avformat_flush(AVFormatContext* @s);

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern void avformat_close_input(AVFormatContext** @s);

        [DllImport(avformat, CallingConvention = CallingConvention.Cdecl)]
        public static extern int av_seek_frame(AVFormatContext* @s, int @stream_index, long @timestamp, int @flags);

        //AVUTIL
        [DllImport(avutil, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int av_samples_get_buffer_size(int* @linesize, int @nb_channels, int @nb_samples, AVSampleFormat @sample_fmt, int @align);

        [DllImport(avutil, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern AVFrame* av_frame_alloc();

        [DllImport(avutil, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern long av_frame_get_best_effort_timestamp(AVFrame* @frame);

        [DllImport(avutil, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr av_get_media_type_string(AVMediaType @media_type);

        [DllImport(avutil, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void av_free(void* @ptr);

        [DllImport(avutil, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void* av_malloc(ulong @size);

        //AVCODEC
        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl)]
        public static extern void avcodec_register_all();

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl)]
        public static extern AVPacket* av_packet_alloc();

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl)]
        public static extern void av_packet_free(AVPacket** @pkt);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl)]
        public static extern AVCodec* avcodec_find_decoder(AVCodecID @id);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl)]
        public static extern AVCodecContext* avcodec_alloc_context3(AVCodec* @codec);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int avcodec_parameters_to_context(AVCodecContext* @codec, AVCodecParameters* @par);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int avcodec_open2(AVCodecContext* @avctx, AVCodec* @codec, AVDictionary** @options);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int avcodec_send_packet(AVCodecContext* @avctx, AVPacket* @avpkt);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int avcodec_receive_frame(AVCodecContext* @avctx, AVFrame* @frame);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void avcodec_flush_buffers(AVCodecContext* @avctx);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int avpicture_fill(AVPicture* @picture, byte* @ptr, AVPixelFormat @pix_fmt, int @width, int @height);

        [DllImport(avcodec, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int avpicture_get_size(AVPixelFormat @pix_fmt, int @width, int @height);

        //SWRESAMPLE
        [DllImport(swresample, CallingConvention = CallingConvention.Cdecl)]
        public static extern int swr_convert_frame(SwrContext* @swr, AVFrame* @output, AVFrame* @input);

        [DllImport(swresample, CallingConvention = CallingConvention.Cdecl)]
        public static extern int swr_init(SwrContext* @s);

        [DllImport(swresample, CallingConvention = CallingConvention.Cdecl)]
        public static extern SwrContext* swr_alloc_set_opts(SwrContext* @s, long @out_ch_layout, AVSampleFormat @out_sample_fmt, int @out_sample_rate, long @in_ch_layout,
                                                            AVSampleFormat @in_sample_fmt, int @in_sample_rate, int @log_offset, void* @log_ctx);

        //SWSCALE
        [DllImport(swscale, CallingConvention = CallingConvention.Cdecl)]
        public static extern SwsContext* sws_getContext(int @srcW, int @srcH, AVPixelFormat @srcFormat, int @dstW, int @dstH, AVPixelFormat @dstFormat, int @flags, 
            SwsFilter* @srcFilter, SwsFilter* @dstFilter, double* @param);

        [DllImport(swscale, CallingConvention = CallingConvention.Cdecl)]
        public static extern int sws_scale(SwsContext* @c, byte*[] @srcSlice, int[] @srcStride, int @srcSliceY, int @srcSliceH, byte*[] @dst, int[] @dstStride);
    }
}
