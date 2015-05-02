using System.Runtime.InteropServices;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldArgbColor )]
    [StructLayout( LayoutKind.Sequential, Size = 4 )]
    public struct ColourA1R1G1B1
    {
        public byte A;
        public byte R;
        public byte G;
        public byte B;

        public ColourA1R1G1B1( byte a, byte r, byte g, byte b )
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        public override string ToString()
        {
            return string.Format("R:{0:F} G:{1:F} B:{2:F} A:{3:F}", R, G, B, A);
        }
    }
}