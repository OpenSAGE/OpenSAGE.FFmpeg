using System;
using System.IO;
using Xunit;

namespace OpenSage.FFmpeg.Tests
{
    /// <summary>
    /// test on the big buck bunny movie (which has been encoded to different formats)
    /// see: https://peach.blender.org/
    /// </summary>
    public class Test
    {
        [Fact]
        public unsafe void CanReadBink()
        {
            //Check av_malloc and av_freep
            var media = new Source(File.Open("test.bik",FileMode.Open));

            //Check that both video & audio are found
            Assert.True(media.HasAudio);
            Assert.True(media.HasVideo);
        }

        [Fact]
        public unsafe void CanReadVp6()
        {
            //Check av_malloc and av_freep
            var media = new Source(File.Open("test.vp6", FileMode.Open));

            //Check that both video & audio are found
            Assert.True(media.HasAudio);
            Assert.True(media.HasVideo);
        }
    }
}
