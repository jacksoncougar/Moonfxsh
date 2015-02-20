using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish
{
    public static class Padding
    {
        public static int Pad(this Stream stream, int alignment = 4)
        {
            return (int)stream.Seek(GetCount(stream.Position, alignment), SeekOrigin.Current);
        }

        public static int Pad(long address, int alignment = 4)
        {
            address += (int)GetCount(address, alignment);
            return (int)address;
        }

        internal static long GetCount(long address, long alignment = 4)
        {
            return (-address) & (alignment - 1);
        }

        internal static byte[] GetBytes(int length, byte value)
        {
            var buffer = new byte[length];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = value;
            }
            return buffer;
        }
    }
}
