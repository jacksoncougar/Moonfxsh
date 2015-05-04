using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldCharBlockIndex1)]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct ByteBlockIndex1
    {
        private byte index;

        public static explicit operator byte(ByteBlockIndex1 byteBlockIndex)
        {
            return byteBlockIndex.index;
        }

        public static explicit operator ByteBlockIndex1(byte value)
        {
            return new ByteBlockIndex1 {index = value};
        }

        public override string ToString()
        {
            return index.ToString();
        }
    }
}