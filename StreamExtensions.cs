using System;
using System.IO;

namespace Moonfish
{
    public static class StreamExtensions
    {
        public static IDisposable Pin(this Stream stream)
        {
            return new StreamPositionHandle(stream);
        }

        public static long Seek(this Stream stream, int address)
        {
            return stream.Seek(address, SeekOrigin.Begin);
        }

        public static void BufferedCopyBytesTo(this Stream stream, int size, Stream output)
        {
            const int blockSize = 1024 * 4;

            var buffer0 = new byte[blockSize];

            var blockCount = size / blockSize;
            var remainder = size % blockSize;

            for (var index = 0; index < blockCount; ++index)
            {
                if (stream.Read(buffer0, 0, buffer0.Length) < buffer0.Length) throw new IOException();
                output.Write(buffer0, 0, buffer0.Length);
            }
            if (stream.Read(buffer0, 0, remainder) < remainder) throw new IOException();
            output.Write(buffer0, 0, remainder);
        }

        private class StreamPositionHandle : IDisposable
        {
            private readonly long _streamPosition;
            private readonly Stream _stream;

            public StreamPositionHandle(Stream stream)
            {
                _stream = stream;
                _streamPosition = stream.Position;
            }

            void IDisposable.Dispose()
            {
                _stream.Position = _streamPosition;
            }
        }
    }
}