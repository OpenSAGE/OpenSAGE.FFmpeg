using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    public interface IAudioHandler
    {
        void CreateBuffer(int index, int frequency, int channels, long sampleRate);
        void UpdateBuffer(IntPtr data,int size);
    }
}
