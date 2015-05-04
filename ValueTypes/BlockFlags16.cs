using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldWordBlockFlags)]
    [StructLayout(LayoutKind.Sequential, Size = 2)]
    public struct BlockFlags16
    {
        public short flags;

        public BlockFlags16(short flags)
        {
            this.flags = flags;
        }

        public override string ToString()
        {
            return flags.ToString();
        }
    }
}