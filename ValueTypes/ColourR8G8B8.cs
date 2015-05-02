using System.Runtime.InteropServices;
using Moonfish.Graphics;
using Moonfish.Guerilla;

namespace Moonfish.Tags
{
    [GuerillaType( MoonfishFieldType.FieldRealRgbColor )]
    [StructLayout( LayoutKind.Sequential, Size = 12 )]
    public struct ColourR8G8B8
    {
        public readonly float R;
        public readonly float G;
        public readonly float B;

        public ColourR8G8B8( float r, float g, float b )
        {
            R = r.Clamp( 0, 1 );
            G = g.Clamp( 0, 1 );
            B = b.Clamp( 0, 1 );
        }

        public override string ToString()
        {
            return string.Format("R:{0:F} G:{1:F} B:{2:F}", R, G, B);
        }
    }
}