using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldShortBlockIndex2)]
    [StructLayout(LayoutKind.Sequential, Size = 2)]
    public struct ShortBlockIndex2
    {
        private short index;

        public static explicit operator short(ShortBlockIndex2 blockIndex)
        {
            return blockIndex.index;
        }

        public static explicit operator ShortBlockIndex2(short value)
        {
            return new ShortBlockIndex2 {index = value};
        }

        public override string ToString()
        {
            return index.ToString();
        }
    }
}