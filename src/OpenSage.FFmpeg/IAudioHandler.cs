using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    public interface IAudioHandler
    {
        int CreateBuffer(int frequency, int channels, long sampleRate);
        void UpdateBuffer(int buffer,IntPtr data,int size);

        DataLayout Layout { get; }
    }
}
