using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldLongBlockFlags)]
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct BlockFlags32
    {
        public int flags;

        public BlockFlags32(int flags)
        {
            this.flags = flags;
        }

        public override string ToString()
        {
            return flags.ToString();
        }
    }
}