using System;
using System.Linq;
using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldLongString )]
    [StructLayout( LayoutKind.Sequential, Size = 256 )]
    public struct String256
    {
        [MarshalAs( UnmanagedType.ByValArray, SizeConst = 256 )] 
        public char[] value;

        public String256( string stringValue )
        {
            value = new char[256];
            var length = stringValue.Length > 256 ? 256 : stringValue.Length;
            Array.Copy( stringValue.ToArray( ), value, length );
        }

        public override string ToString()
        {
            return new string(value);
        }
    }
}