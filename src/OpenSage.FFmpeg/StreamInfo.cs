using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    public interface IStreamInfo
    {
        long BitRate { get; set; }
    }

    public class VideoStreamInfo : IStreamInfo
    {
        public long BitRate { get; set; }
        public double Fps { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class AudioStreamInfo : IStreamInfo
    {
        public long BitRate { get; set; }
        public int Frequency { get; set; }
        public int Channels { get; set; }
    }
}
