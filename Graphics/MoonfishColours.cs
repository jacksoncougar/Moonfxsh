using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    static class Colours
    {
        public static Color Blue = Color.FromArgb( 18, 56, 166 );
        public static Color Green = Color.FromArgb( 90, 157, 1 );
        public static Color Red = Color.FromArgb( 166, 39, 18 );
        public static Color Selection = Color.FromArgb( 222, 204, 2 );
        public static Color ClearColour = Color.FromArgb( 33, 33, 33 );

        static float seed = new Random( ).Next( 0, 255 ) / 255;
        const float GoldenAngleConjugate = 0.618033988749895f;
        public static Color LinearRandomDiffuseColor
        {
            get
            {
                seed += GoldenAngleConjugate;
                seed %= 1;
                return ColorFromHSV( seed * 60f + 150, 0, 1 );
            }
        }
        public static Color ColorFromHSV( double hue, double saturation, double value )
        {
            int hi = Convert.ToInt32( Math.Floor( hue / 60 ) ) % 6;
            double f = hue / 60 - Math.Floor( hue / 60 );

            value = value * 255;
            int v = Convert.ToInt32( value );
            int p = Convert.ToInt32( value * ( 1 - saturation ) );
            int q = Convert.ToInt32( value * ( 1 - f * saturation ) );
            int t = Convert.ToInt32( value * ( 1 - ( 1 - f ) * saturation ) );

            if( hi == 0 )
                return Color.FromArgb( 255, v, t, p );
            else if( hi == 1 )
                return Color.FromArgb( 255, q, v, p );
            else if( hi == 2 )
                return Color.FromArgb( 255, p, v, t );
            else if( hi == 3 )
                return Color.FromArgb( 255, p, q, v );
            else if( hi == 4 )
                return Color.FromArgb( 255, t, p, v );
            else
                return Color.FromArgb( 255, v, p, q );
        }
    }
}
