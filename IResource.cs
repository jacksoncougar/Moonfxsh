using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish
{
    public interface IResource
    {
        void CopyFrom(Stream input);
    }

    public static class ResourceExtensions
    {
        public static bool CopyResource(this Stream source, int address, int length, out byte[] data)
        {
            data = new byte[0];
            if (address < 0 || address + length > source.Length) return false;
            source.Position = address;
            data = new byte[length];
            source.Read(data, 0, length);
            return true;
        }
    }
}