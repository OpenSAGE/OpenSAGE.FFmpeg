using OpenSage.FFmpegNative;
using System;
using System.Collections.Generic;
using System.IO;

namespace OpenSage.FFmpeg
{
    internal unsafe sealed class AvStream
    {
        private Stream _stream;
        private AVIOContext* _context;
        private byte[] _buffer;
        private const int _bufSize = 32*1024;

        public AvStream(Stream stream)
        {
            _stream = stream;
            _buffer = new byte[_bufSize];

            fixed (byte* bufPtr = _buffer)
            {
                //create an unwritable context
                _context = ffmpeg.avio_alloc_context(bufPtr,
                    _bufSize, 0, null,
                    new avio_alloc_context_read_packet(ReadPacket),
                    null,
                    new avio_alloc_context_seek(SeekFunc));
            }
        }


        public void Attach(AVFormatContext* ctx)
        {
            ctx->pb = _context;
            ctx->flags = ffmpeg.AVFMT_FLAG_CUSTOM_IO;

            int size = _bufSize - ffmpeg.AVPROBE_PADDING_SIZE;
            int readBytes = _stream.Read(_buffer, 0, size);
            _stream.Seek(0, SeekOrigin.Begin);

            AVProbeData probe;
            fixed (byte* bufPtr = _buffer)
            {             
                probe.buf = bufPtr;
                probe.buf_size = readBytes;
                probe.filename = null;
                probe.mime_type = null;
            }

            // Determine the input-format:
            ctx->iformat = ffmpeg.av_probe_input_format(&probe, 1);
        }

        private int ReadPacket(void* opaque, byte* buffer, int bufferSize)
        {
            //we can ignore buffer since we already have that as member variable
            return _stream.Read(_buffer, 0, bufferSize);
        }

        private long SeekFunc(void* opaque, long offset, int whence)
        {
            SeekOrigin origin;

            switch (whence)
            {
                case ffmpeg.AVSEEK_SIZE:
                    return _stream.Length;
                case 0:
                case 1:
                case 2:
                    origin = (SeekOrigin)whence;
                    break;
                default:
                    throw new InvalidOperationException("Invalid whence");
            }

            _stream.Seek(offset, origin);
            return _stream.Position;
        }

        internal AVIOContext* GetContext()
        {
            return _context;
        }
    }
}
