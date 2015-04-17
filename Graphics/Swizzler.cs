using System;

namespace Moonfish.Graphics
{
    public class Swizzler
    {
        public static byte[] Swizzle( byte[] pixelData, int pixelSizeInBytes, int pixelWidth, int pixelHeight,
            int pixelDepth = 1, int pixelDataOffset = 0, bool deswizzle = true )
        {
            byte[] pixelDataCopy = new byte[pixelData.Length];

            MaskSet masks = new MaskSet( pixelWidth, pixelHeight, pixelDepth );
            var s = masks.ToString( );
            for ( int u = 0; u < pixelWidth * pixelHeight * pixelDepth; ++u )
            {
                var x = u % pixelWidth;
                var y = u / pixelWidth;

                var sourceAddress = deswizzle
                    ? masks.Swizzle( x, y, pixelDepth ) * pixelSizeInBytes
                    : u * pixelSizeInBytes;

                var destinationAddress = deswizzle
                    ? u * pixelSizeInBytes
                    : masks.Swizzle( x, y, pixelDepth ) * pixelSizeInBytes;

                for ( int i = pixelDataOffset; i < pixelSizeInBytes + pixelDataOffset; ++i )
                {
                    pixelDataCopy[ destinationAddress + i ] = pixelData[ sourceAddress + i ];
                }
            }

            return pixelDataCopy;
        }

        private class MaskSet
        {
            public readonly int WidthMask;
            public readonly int HeightMask;
            public readonly int DepthMask;

            private MaskSet( )
            {
                WidthMask = 0;
                HeightMask = 0;
                DepthMask = 0;
            }

            public MaskSet( int width, int height, int depth )
                : this( )
            {
                for ( int bit = 1, index = 1; bit < width || bit < height || bit < depth; bit <<= 1 )
                {
                    WidthMask |= bit < width ? ( index <<= 1 ) : 0;
                    HeightMask |= bit < height ? ( index <<= 1 ) : 0;
                    DepthMask |= bit < depth ? ( index <<= 1 ) : 0;
                }
                WidthMask >>= 1;
                HeightMask >>= 1;
                DepthMask >>= 1;
            }

            public int Swizzle( int x, int y, int z )
            {
                return SwizzleAxis( x, WidthMask ) | SwizzleAxis( y, HeightMask ) | SwizzleAxis( z, DepthMask );
            }

            /// <summary>
            /// Moves the sequential bits from val into the enabled bits of mask </summary>
            private int SwizzleAxis( int value, int mask )
            {
                int result = 0;

                for ( int bit = 1; bit <= mask; bit <<= 1 )
                {
                    if ( ( mask & bit ) != 0 ) result |= ( value & bit );
                    else value <<= 1;
                }

                return result;
            }

            public override string ToString( )
            {
                int mask = WidthMask ^ HeightMask ^ DepthMask;
                char[] bitValues = new char[32];
                Array.ForEach( bitValues, i => bitValues[ i ] = '0' );

                for ( int bit = 1, index = 0; bit < mask; bit <<= 1, ++index )
                {
                    if ( ( WidthMask & bit ) != 0 )
                        bitValues[ index ] = 'w';
                    if ( ( HeightMask & bit ) != 0 )
                        bitValues[ index ] = 'h';
                    if ( ( DepthMask & bit ) != 0 )
                        bitValues[ index ] = 'd';
                }

                return new string( bitValues );
            }
        }
    }
}