using System;
using System.Linq;
using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldString)]
    [StructLayout(LayoutKind.Sequential, Size = 32)]
    public struct String32
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public char[] value;

        public String32(string stringValue)
        {
            value = new char[32];
            var length = stringValue.Length > 32 ? 32 : stringValue.Length;
            Array.Copy(stringValue.ToArray(), value, length);
        }

        public override string ToString()
        {
            return new string(value);
        }
    }
}