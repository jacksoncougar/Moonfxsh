using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType(MoonfishFieldType.FieldRgbColor)]
    [StructLayout(LayoutKind.Sequential, Size = 3)]
    public struct ColourR1G1B1
    {
        public byte R;
        public byte G;
        public byte B;

        public ColourR1G1B1(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return string.Format("R:{0:F} G:{1:F} B:{2:F}",
                R/byte.MaxValue, G/byte.MaxValue, B/byte.MaxValue);
        }
    }
}