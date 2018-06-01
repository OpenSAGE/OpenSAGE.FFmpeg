using System;
using System.Runtime.InteropServices;

namespace OpenSage.FFmpegNative
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVIOContext_read_packet(void* @opaque, byte* @buf, int @buf_size);
    internal unsafe struct AVIOContext_read_packet_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVIOContext_read_packet_func(AVIOContext_read_packet func) => new AVIOContext_read_packet_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate string AVClass_item_name(void* @ctx);
    internal unsafe struct AVClass_item_name_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVClass_item_name_func(AVClass_item_name func) => new AVClass_item_name_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void* AVClass_child_next(void* @obj, void* @prev);
    internal unsafe struct AVClass_child_next_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVClass_child_next_func(AVClass_child_next func) => new AVClass_child_next_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate AVClass* AVClass_child_class_next(AVClass* @prev);
    internal unsafe struct AVClass_child_class_next_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVClass_child_class_next_func(AVClass_child_class_next func) => new AVClass_child_class_next_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate AVClassCategory AVClass_get_category(void* @ctx);
    internal unsafe struct AVClass_get_category_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVClass_get_category_func(AVClass_get_category func) => new AVClass_get_category_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVClass_query_ranges(AVOptionRanges** @p0, void* @obj, [MarshalAs(UnmanagedType.LPStr)] string @key, int @flags);
    internal unsafe struct AVClass_query_ranges_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVClass_query_ranges_func(AVClass_query_ranges func) => new AVClass_query_ranges_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void av_fifo_generic_peek_at_func(void* @p0, void* @p1, int @p2);
    internal unsafe struct av_fifo_generic_peek_at_func_func
    {
        internal IntPtr Pointer;
        public static implicit operator av_fifo_generic_peek_at_func_func(av_fifo_generic_peek_at_func func) => new av_fifo_generic_peek_at_func_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void av_fifo_generic_peek_func(void* @p0, void* @p1, int @p2);
    internal unsafe struct av_fifo_generic_peek_func_func
    {
        internal IntPtr Pointer;
        public static implicit operator av_fifo_generic_peek_func_func(av_fifo_generic_peek_func func) => new av_fifo_generic_peek_func_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void av_fifo_generic_read_func(void* @p0, void* @p1, int @p2);
    internal unsafe struct av_fifo_generic_read_func_func
    {
        internal IntPtr Pointer;
        public static implicit operator av_fifo_generic_read_func_func(av_fifo_generic_read_func func) => new av_fifo_generic_read_func_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int av_fifo_generic_write_func(void* @p0, void* @p1, int @p2);
    internal unsafe struct av_fifo_generic_write_func_func
    {
        internal IntPtr Pointer;
        public static implicit operator av_fifo_generic_write_func_func(av_fifo_generic_write_func func) => new av_fifo_generic_write_func_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVHWDeviceContext_free(AVHWDeviceContext* @ctx);
    internal unsafe struct AVHWDeviceContext_free_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVHWDeviceContext_free_func(AVHWDeviceContext_free func) => new AVHWDeviceContext_free_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVHWFramesContext_free(AVHWFramesContext* @ctx);
    internal unsafe struct AVHWFramesContext_free_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVHWFramesContext_free_func(AVHWFramesContext_free func) => new AVHWFramesContext_free_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVD3D11VADeviceContext_lock(void* @lock_ctx);
    internal unsafe struct AVD3D11VADeviceContext_lock_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVD3D11VADeviceContext_lock_func(AVD3D11VADeviceContext_lock func) => new AVD3D11VADeviceContext_lock_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVD3D11VADeviceContext_unlock(void* @lock_ctx);
    internal unsafe struct AVD3D11VADeviceContext_unlock_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVD3D11VADeviceContext_unlock_func(AVD3D11VADeviceContext_unlock func) => new AVD3D11VADeviceContext_unlock_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_init_thread_copy(AVCodecContext* @p0);
    internal unsafe struct AVCodec_init_thread_copy_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_init_thread_copy_func(AVCodec_init_thread_copy func) => new AVCodec_init_thread_copy_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_update_thread_context(AVCodecContext* @dst, AVCodecContext* @src);
    internal unsafe struct AVCodec_update_thread_context_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_update_thread_context_func(AVCodec_update_thread_context func) => new AVCodec_update_thread_context_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVCodec_init_static_data(AVCodec* @codec);
    internal unsafe struct AVCodec_init_static_data_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_init_static_data_func(AVCodec_init_static_data func) => new AVCodec_init_static_data_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_init(AVCodecContext* @p0);
    internal unsafe struct AVCodec_init_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_init_func(AVCodec_init func) => new AVCodec_init_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_encode_sub(AVCodecContext* @p0, byte* @buf, int @buf_size, AVSubtitle* @sub);
    internal unsafe struct AVCodec_encode_sub_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_encode_sub_func(AVCodec_encode_sub func) => new AVCodec_encode_sub_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_encode2(AVCodecContext* @avctx, AVPacket* @avpkt, AVFrame* @frame, int* @got_packet_ptr);
    internal unsafe struct AVCodec_encode2_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_encode2_func(AVCodec_encode2 func) => new AVCodec_encode2_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_decode(AVCodecContext* @p0, void* @outdata, int* @outdata_size, AVPacket* @avpkt);
    internal unsafe struct AVCodec_decode_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_decode_func(AVCodec_decode func) => new AVCodec_decode_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_close(AVCodecContext* @p0);
    internal unsafe struct AVCodec_close_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_close_func(AVCodec_close func) => new AVCodec_close_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_send_frame(AVCodecContext* @avctx, AVFrame* @frame);
    internal unsafe struct AVCodec_send_frame_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_send_frame_func(AVCodec_send_frame func) => new AVCodec_send_frame_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_receive_packet(AVCodecContext* @avctx, AVPacket* @avpkt);
    internal unsafe struct AVCodec_receive_packet_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_receive_packet_func(AVCodec_receive_packet func) => new AVCodec_receive_packet_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodec_receive_frame(AVCodecContext* @avctx, AVFrame* @frame);
    internal unsafe struct AVCodec_receive_frame_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_receive_frame_func(AVCodec_receive_frame func) => new AVCodec_receive_frame_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVCodec_flush(AVCodecContext* @p0);
    internal unsafe struct AVCodec_flush_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodec_flush_func(AVCodec_flush func) => new AVCodec_flush_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVCodecContext_draw_horiz_band(AVCodecContext* @s, AVFrame* @src, ref int_array8 @offset, int @y, int @type, int @height);
    internal unsafe struct AVCodecContext_draw_horiz_band_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodecContext_draw_horiz_band_func(AVCodecContext_draw_horiz_band func) => new AVCodecContext_draw_horiz_band_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate AVPixelFormat AVCodecContext_get_format(AVCodecContext* @s, AVPixelFormat* @fmt);
    internal unsafe struct AVCodecContext_get_format_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodecContext_get_format_func(AVCodecContext_get_format func) => new AVCodecContext_get_format_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVCodecContext_get_buffer2(AVCodecContext* @s, AVFrame* @frame, int @flags);
    internal unsafe struct AVCodecContext_get_buffer2_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodecContext_get_buffer2_func(AVCodecContext_get_buffer2 func) => new AVCodecContext_get_buffer2_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void AVCodecContext_rtp_callback(AVCodecContext* @avctx, void* @data, int @size, int @mb_nb);
    internal unsafe struct AVCodecContext_rtp_callback_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVCodecContext_rtp_callback_func(AVCodecContext_rtp_callback func) => new AVCodecContext_rtp_callback_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVHWAccel_alloc_frame(AVCodecContext* @avctx, AVFrame* @frame);
    internal unsafe struct AVHWAccel_alloc_frame_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVHWAccel_alloc_frame_func(AVHWAccel_alloc_frame func) => new AVHWAccel_alloc_frame_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int AVIOContext_write_packet(void* @opaque, byte* @buf, int @buf_size);
    internal unsafe struct AVIOContext_write_packet_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVIOContext_write_packet_func(AVIOContext_write_packet func) => new AVIOContext_write_packet_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate long AVIOContext_seek(void* @opaque, long @offset, int @whence);
    internal unsafe struct AVIOContext_seek_func
    {
        internal IntPtr Pointer;
        public static implicit operator AVIOContext_seek_func(AVIOContext_seek func) => new AVIOContext_seek_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int avio_alloc_context_read_packet(void* @opaque, byte* @buf, int @buf_size);
    internal unsafe struct avio_alloc_context_read_packet_func
    {
        internal IntPtr Pointer;
        public static implicit operator avio_alloc_context_read_packet_func(avio_alloc_context_read_packet func) => new avio_alloc_context_read_packet_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate int avio_alloc_context_write_packet(void* @opaque, byte* @buf, int @buf_size);
    internal unsafe struct avio_alloc_context_write_packet_func
    {
        internal IntPtr Pointer;
        public static implicit operator avio_alloc_context_write_packet_func(avio_alloc_context_write_packet func) => new avio_alloc_context_write_packet_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate long avio_alloc_context_seek(void* @opaque, long @offset, int @whence);
    internal unsafe struct avio_alloc_context_seek_func
    {
        internal IntPtr Pointer;
        public static implicit operator avio_alloc_context_seek_func(avio_alloc_context_seek func) => new avio_alloc_context_seek_func { Pointer = func == null ? IntPtr.Zero : Marshal.GetFunctionPointerForDelegate(func) };
    }
}
