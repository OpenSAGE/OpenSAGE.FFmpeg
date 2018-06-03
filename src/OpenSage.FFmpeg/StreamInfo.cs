using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    /// <summary>
    /// The interface for stream informations
    /// </summary>
    public interface IStreamInfo
    {
        long BitRate { get; set; }
    }

    /// <summary>
    /// Stream infomrations that are specific to video streams
    /// </summary>
    public class VideoStreamInfo : IStreamInfo
    {
        public long BitRate { get; set; }
        public double Fps { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    /// <summary>
    /// Stream infomrations that are specific to audio streams
    /// </summary>
    public class AudioStreamInfo : IStreamInfo
    {
        public long BitRate { get; set; }
        public int Frequency { get; set; }
        public int Channels { get; set; }
    }
}
