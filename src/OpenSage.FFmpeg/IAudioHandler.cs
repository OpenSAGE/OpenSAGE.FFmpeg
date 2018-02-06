using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    public interface IAudioHandler
    {
        void CreateBuffer();
        void UpdateBuffer(byte[] data);
    }
}
