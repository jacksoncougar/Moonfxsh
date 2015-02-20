using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public struct ColorF
    {
        float R { get; set; }
        float G { get; set; }
        float B { get; set; }
        float A { get; set; }

        public ColorF(Color color, bool normalise = true)
            : this()
        {
            this.R = normalise ? color.R / (float)byte.MaxValue : color.R;
            this.G = normalise ? color.G / (float)byte.MaxValue : color.G;
            this.B = normalise ? color.B / (float)byte.MaxValue : color.B;
            this.A = normalise ? color.A / (float)byte.MaxValue : color.A;
        }

        public float[] ToArray()
        {
            return new[] { R, G, B, A };
        }
    }
    public static class ColorExtensions
    {
        public static float[] ToFloatRgba(this  Color color)
        {
            var components = new[] { color.R, color.G, color.B, color.A };
            var floats = Array.ConvertAll(components, x => (float)x / 255f);
            return floats;
        }
        public static float[] ToFloatRgb(this Color color)
        {
            var components = new[] { color.R, color.G, color.B };
            var floats = Array.ConvertAll(components, x => (float)x / 255f);
            return floats;
        }
    }
}
