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
            //Open a new source
            var stream = File.Open("test.bik", FileMode.Open);
            var media = new Source(stream);

            //Check that both video & audio are found
            Assert.True(media.HasAudio);
            Assert.True(media.HasVideo);

            //Check the duration is correct
            Assert.Equal(new TimeSpan(0,0,9,56,457), media.Duration);

            //Check the bitrate is correct
            Assert.Equal(690451, media.BitRate);

            //Check the file contains exactly two streams
            Assert.Equal(2, media.Streams.Count);
            stream.Close();
        }

        [Fact]
        public unsafe void CanReadVp6()
        {
            //Open a new source
            var stream = File.Open("test.vp6", FileMode.Open);
            var media = new Source(stream);

            //Check that both video & audio are found
            Assert.True(media.HasAudio);
            Assert.True(media.HasVideo);

            //Check the duration is correct
            Assert.Equal(new TimeSpan(0, 0, 9, 56, 480), media.Duration);

            //Check the bitrate is correct
            Assert.Equal(688981, media.BitRate);

            //Check the file contains exactly two streams
            Assert.Equal(2, media.Streams.Count);
            stream.Close();
        }

        class VideoHandler : IVideoHandler
        {
            public void CreateTexture(int index, int width, int height)
            {
               
            }

            public void UpdateTexture(int index, byte[] data)
            {
                
            }
        }

        class AudioHandler : IAudioHandler
        {
            public AudioLayout Layout => AudioLayout.Interleaved;
            private int _bufferIndex = 0;


            public int CreateBuffer(int frequency, int channels, long sampleRate)
            {
                return _bufferIndex++;
            }

            public void UpdateBuffer(int buffer,IntPtr data, int size)
            {
                
            }
        }

        [Fact]
        public unsafe void Playback()
        {
            var vidHandler = new VideoHandler();
            var audioHandler = new AudioHandler();
            var stream = File.Open("test.bik", FileMode.Open);

            //Open a new source
            var media = new Source(stream,vidHandler,audioHandler);

            media.Start();

            stream.Close();
        }
    }
}
