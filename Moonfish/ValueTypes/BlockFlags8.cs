using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldByteBlockFlags)]
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct BlockFlags8
    {
        public byte flags;

        public BlockFlags8(byte flags)
        {
            this.flags = flags;
        }

        public override string ToString()
        {
            return flags.ToString();
        }
    }
}