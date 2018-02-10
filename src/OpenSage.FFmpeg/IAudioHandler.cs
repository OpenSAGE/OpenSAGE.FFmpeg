using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    public enum AudioLayout
    {
        Any,
        Interleaved,
        Planar
    }

    public interface IAudioHandler
    {
        int CreateBuffer(int frequency, int channels, long sampleRate);
        void UpdateBuffer(int buffer,IntPtr data,int size);

        AudioLayout Layout { get; }
    }
}
