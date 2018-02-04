using System;
using Xunit;

namespace OpenSage.FFmpeg.Tests
{
    public class Test
    {
        [Fact]
        public unsafe void Memory()
        {
            //Check av_malloc and av_freep
            var mem = FFmpegNative.av_malloc(1024);
            Assert.NotEqual(0, mem.ToInt64());
            IntPtr memP = new IntPtr((void*)&mem);
            FFmpegNative.av_freep(memP);
            Assert.Equal(0, mem.ToInt64());

            //Check normal av_free
            mem = FFmpegNative.av_malloc(1024);
            Assert.NotEqual(0, mem.ToInt64());
            FFmpegNative.av_free(mem);
        }

        [Fact]
        public void OpenStream()
        {

        }
    }
}
