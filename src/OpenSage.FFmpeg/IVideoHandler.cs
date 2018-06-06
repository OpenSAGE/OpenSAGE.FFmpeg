using System;

namespace OpenSage.FFmpeg
{
    public interface IVideoHandler
    {
        void CreateTexture(int index, int width, int height);
        void UpdateTexture(int index, IntPtr data, int data_size);

        DataLayout Layout { get; }
    }
}
