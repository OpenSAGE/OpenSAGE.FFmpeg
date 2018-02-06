using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSage.FFmpeg
{
    public interface IVideoHandler
    {
        void CreateTexture(int index,int width, int height);
        void UpdateTexture(int index,byte[] data);
    }
}
