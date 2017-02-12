using System;
using System.IO;
using System.Linq;

namespace Moonfish
{
    public static class Padding
    {
        public static void AssertIsAligned(int alignment = 4, params Stream[] streams)
        {
#if DEBUG
            if (streams.Any(stream => stream.Position % alignment != 0))
            {
                throw new DataMisalignedException();
            }
#endif
        }

        public static int PackLength(this Stream stream, int alignment = 4)
        {
            var count = GetCount(stream.Length, alignment);
            stream.SetLength(stream.Length + count);
            return (int)stream.Length;
        }

        public static int TargetAlign(this Stream stream, long address, int alignment = 4)
        {
            var count = GetCount(address + stream.Length, alignment);
            var bytes = GetBytes((int)count, "\0");
            return stream.CanWrite
                ? new Func<int>(() =>
                {
                    stream.Write(bytes, 0, bytes.Length);
                    return (int)stream.Position;
                })()
                : (int)stream.Seek(count, SeekOrigin.Current);
        }


        public static int Align(this Stream stream, int alignment = 4)
        {
            var count = GetCount(stream.Position, alignment);
            var bytes = GetBytes((int) count, "\0");
            return stream.CanWrite
                ? new Func<int>(() =>
                {
                    stream.Write(bytes, 0, bytes.Length);
                    return (int) stream.Position;
                })()
                : (int) stream.Seek(count, SeekOrigin.Current);
        }

        public static int Align(long address, int alignment = 4)
        {
            return (int)address + (int) GetCount(address, alignment);
        }

        internal static long GetCount(long address, long alignment = 4)
        {
            var count = (-address) & (alignment - 1);
            if(count < 0) throw new Exception();
            return count;
        }

        internal static byte[] GetBytes(int length, string value)
        {
            var buffer = new byte[length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte) value[i % value.Length];
            }
            return buffer;
        }
    }
}