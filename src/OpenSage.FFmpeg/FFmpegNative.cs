using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenSage.FFmpeg
{
    public static unsafe class FFmpegNative
    {
        private const string avCodecLib = "avcodec-57";
        private const string avFormatLib = "avformat-57";
        private const string avUtilLib = "avutil-55";

        [DllImport(avUtilLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr av_malloc(uint size);

        [DllImport(avUtilLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern void av_free(IntPtr ptr);

        [DllImport(avUtilLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern void av_freep(IntPtr ptr);

        [DllImport(avFormatLib, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr avio_alloc_context(IntPtr buf,uint bufSize,int writeFlags,IntPtr userData,
                                                       IntPtr readFunc,IntPtr writeFunc, IntPtr seekFunc);


    }
}
