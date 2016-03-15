using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldLongBlockIndex2)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct LongBlockIndex2
    {
        private int index;

        public static explicit operator int(LongBlockIndex2 blockIndex)
        {
            return blockIndex.index;
        }

        public static explicit operator LongBlockIndex2(int value)
        {
            return new LongBlockIndex2 {index = value};
        }

        public override string ToString()
        {
            return index.ToString();
        }
    }
}