using System;
using System.IO;
using Xunit;

namespace OpenSage.FFmpeg.Tests
{
    public class Test
    {
        [Fact]
        public unsafe void OpenStream()
        {
            //Check av_malloc and av_freep
            var media = new Source(File.Open("test.vp6",FileMode.Open));
        }
    }
}
