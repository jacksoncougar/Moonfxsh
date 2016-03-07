using System.Drawing;
using OpenTK;

namespace Moonfish.Graphics
{
    public struct ColorF
    {
        private float R { get; set; }
        private float G { get; set; }
        private float B { get; set; }
        private float A { get; set; }

        public ColorF( Color color, bool normalise = true )
            : this( )
        {
            this.R = normalise ? color.R / ( float ) byte.MaxValue : color.R;
            this.G = normalise ? color.G / ( float ) byte.MaxValue : color.G;
            this.B = normalise ? color.B / ( float ) byte.MaxValue : color.B;
            this.A = normalise ? color.A / ( float ) byte.MaxValue : color.A;
        }

        public Vector4 RGBA
        {
            get { return new Vector4( R, G, B, A ); }
        }

        public Vector4 ARGB
        {
            get { return new Vector4( A, R, G, B ); }
        }

        public float[] ToArray( )
        {
            return new[] {R, G, B, A};
        }
    };
}