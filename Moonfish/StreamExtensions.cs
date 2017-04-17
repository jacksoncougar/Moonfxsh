using System;
using System.IO;

namespace Moonfish
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Saves the current position in the stream then restores it at the end of the lifetime of return object. 
        /// </summary>
        /// <returns></returns>
        public static IDisposable Pin(this Stream stream)
        {
            return new StreamPositionHandle(stream);
        }

        public static void BufferedCopyBytesTo(this Stream stream, int size, Stream output)
        {
            const int blockSize = 1024*4;

            var buffer = new byte[blockSize];

            var blockCount = size/blockSize;
            var remainder = size%blockSize;

            for (var index = 0; index < blockCount; ++index)
            {
                if (stream.Read(buffer, 0, buffer.Length) < buffer.Length)
                    throw new IOException();
                output.Write(buffer, 0, buffer.Length);
            }
            if (stream.Read(buffer, 0, remainder) < remainder)
                throw new IOException();
            output.Write(buffer, 0, remainder);
        }

        private class StreamPositionHandle : IDisposable
        {
            private readonly long streamPosition;
            private readonly Stream stream;

            public StreamPositionHandle(Stream stream)
            {
                this.stream = stream;
                streamPosition = stream.Position;
            }

            void IDisposable.Dispose()
            {
                stream.Position = streamPosition;
            }
        }
    }
}