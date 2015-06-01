using System;
using System.Collections.Generic;
using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class Texture : IDisposable
    {
        private readonly int handle;
        private bool disposed;
        private TextureTarget textureTarget;

        public Texture( )
        {
            handle = GL.GenTexture( );
        }

        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        public void Load( BitmapDataBlock workingBitmap,
            TextureMagFilter textureMagFilter = TextureMagFilter.Linear,
            TextureMinFilter textureMinFilter = TextureMinFilter.Linear )
        {
            var buffer = workingBitmap.GetResourceData( );

            var width = workingBitmap.Width;
            var height = workingBitmap.Height;
            var bytesPerPixel = ParseBitapPixelDataSize( workingBitmap.Format ) / 8.0f;

            if ( workingBitmap.BitmapDataFlags.HasFlag( BitmapDataBlock.Flags.Palettized ) )
            {
                textureMagFilter = TextureMagFilter.Nearest;
                textureMinFilter = TextureMinFilter.Nearest;
            }
            if ( workingBitmap.BitmapDataFlags.HasFlag( BitmapDataBlock.Flags.Swizzled ) )
            {
                buffer = Swizzler.Swizzle( buffer, ( int ) bytesPerPixel, width, height );
            }
            var pixelInternalFormat = ParseBitmapPixelInternalFormat( workingBitmap.Format );

            switch ( workingBitmap.Type )
            {
                case BitmapDataBlock.TypeEnum.Texture2D:

                    LoadTexture2D( textureMagFilter, textureMinFilter, bytesPerPixel, width, height, buffer,
                        workingBitmap, pixelInternalFormat );

                    break;
                case BitmapDataBlock.TypeEnum.Cubemap:

                    LoadCubemap( textureMagFilter, textureMinFilter, bytesPerPixel, width, height, buffer, workingBitmap,
                        pixelInternalFormat );

                    break;
                default:
                    GL.DeleteTexture( handle );
                    break;
            }
        }

        private void LoadCubemap( TextureMagFilter textureMagFilter, TextureMinFilter textureMinFilter,
            float bytesPerPixel,
            short width, short height, byte[] buffer, BitmapDataBlock workingBitmap,
            PixelInternalFormat pixelInternalFormat )
        {
            textureTarget = TextureTarget.TextureCubeMap;
            GL.BindTexture( TextureTarget.TextureCubeMap, handle );
            GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter,
                ( int ) textureMagFilter );
            GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter,
                ( int ) textureMinFilter );
            GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS,
                ( int ) TextureWrapMode.ClampToEdge );
            GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT,
                ( int ) TextureWrapMode.ClampToEdge );
            GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR,
                ( int ) TextureWrapMode.ClampToEdge );

            TextureTarget[] cube =
            {
                TextureTarget.TextureCubeMapPositiveX,
                TextureTarget.TextureCubeMapNegativeX,
                TextureTarget.TextureCubeMapPositiveY,
                TextureTarget.TextureCubeMapNegativeY,
                TextureTarget.TextureCubeMapPositiveZ,
                TextureTarget.TextureCubeMapNegativeZ
            };

            for ( var i = 0; i < 6; ++i )
            {
                var surfaceData = new byte[( int ) ( bytesPerPixel * width * height )];
                var stride = buffer.Length / 6;
                Array.Copy( buffer, stride * i, surfaceData, 0, surfaceData.Length );


                if ( workingBitmap.BitmapDataFlags.HasFlag( BitmapDataBlock.Flags.Compressed ) )
                {
                    GL.CompressedTexImage2D(
                        cube[ i ], 0, pixelInternalFormat, width, height, 0,
                        ( int ) ( bytesPerPixel * width * height ), surfaceData );
                }
                else
                {
                    var pixelFormat = ParseBitapPixelFormat( workingBitmap.Format );
                    var pixelType = ParseBitapPixelType( workingBitmap.Format );
                    GL.TexImage2D( cube[ i ], 0, pixelInternalFormat, width, height, 0, pixelFormat, pixelType,
                        surfaceData );
                }
            }
        }

        private void LoadTexture2D( TextureMagFilter textureMagFilter, TextureMinFilter textureMinFilter,
            float bytesPerPixel,
            short width, short height, byte[] buffer, BitmapDataBlock workingBitmap,
            PixelInternalFormat pixelInternalFormat )
        {
            textureTarget = TextureTarget.Texture2D;
            GL.BindTexture( TextureTarget.Texture2D, handle );
            GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                ( int ) textureMagFilter );
            GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                ( int ) textureMinFilter );
            GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
                ( int ) TextureWrapMode.Repeat );
            GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
                ( int ) TextureWrapMode.Repeat );

            var surfaceData = new byte[( int ) ( bytesPerPixel * width * height )];
            Array.Copy( buffer, 0, surfaceData, 0, surfaceData.Length );

            if ( workingBitmap.BitmapDataFlags.HasFlag( BitmapDataBlock.Flags.Compressed ) )
            {
                GL.CompressedTexImage2D(
                    TextureTarget.Texture2D, 0, pixelInternalFormat, width, height, 0,
                    ( int ) ( bytesPerPixel * width * height ), surfaceData );
                GL.GenerateMipmap( GenerateMipmapTarget.Texture2D );
                GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                    ( int ) TextureMagFilter.Linear );
                GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                    ( int ) TextureMinFilter.LinearMipmapLinear );
            }
            else
            {
                var pixelFormat = ParseBitapPixelFormat( workingBitmap.Format );
                var pixelType = ParseBitapPixelType( workingBitmap.Format );
                GL.TexImage2D( TextureTarget.Texture2D, 0, pixelInternalFormat, width, height, 0, pixelFormat,
                    pixelType, surfaceData );
            }
        }

        public void Bind( )
        {
            GL.BindTexture( textureTarget, handle );
        }

        private PixelType ParseBitapPixelType(
            BitmapDataBlock.FormatEnum format )
        {
            switch ( format )
            {
                case BitmapDataBlock.FormatEnum.A1r5g5b5:
                    return PixelType.UnsignedShort5551;

                case BitmapDataBlock.FormatEnum.A4r4g4b4:
                    return PixelType.UnsignedShort4444;

                case BitmapDataBlock.FormatEnum.R5g6b5:
                    return PixelType.UnsignedShort565;

                case BitmapDataBlock.FormatEnum.A8y8:
                case BitmapDataBlock.FormatEnum.V8u8:
                case BitmapDataBlock.FormatEnum.G8b8:
                    return PixelType.UnsignedByte;

                case BitmapDataBlock.FormatEnum.A8:
                case BitmapDataBlock.FormatEnum.P8:
                case BitmapDataBlock.FormatEnum.Y8:
                case BitmapDataBlock.FormatEnum.P8bump:
                case BitmapDataBlock.FormatEnum.Ay8:
                    return PixelType.UnsignedByte;

                case BitmapDataBlock.FormatEnum.A8r8g8b8:
                case BitmapDataBlock.FormatEnum.X8r8g8b8:
                    return PixelType.UnsignedByte;
                default:
                    throw new FormatException( "Unsupported Texture Format" );
            }
        }

        private PixelFormat ParseBitapPixelFormat(
            BitmapDataBlock.FormatEnum format )
        {
            switch ( format )
            {
                case BitmapDataBlock.FormatEnum.A1r5g5b5:
                case BitmapDataBlock.FormatEnum.A4r4g4b4:
                case BitmapDataBlock.FormatEnum.Argbfp32:
                case BitmapDataBlock.FormatEnum.A8r8g8b8:
                case BitmapDataBlock.FormatEnum.X8r8g8b8:
                    return PixelFormat.Rgba;
                case BitmapDataBlock.FormatEnum.R5g6b5:
                case BitmapDataBlock.FormatEnum.Rgbfp16:
                case BitmapDataBlock.FormatEnum.Rgbfp32:
                    return PixelFormat.Rgb;

                case BitmapDataBlock.FormatEnum.A8y8:
                    return PixelFormat.Rg;

                case BitmapDataBlock.FormatEnum.V8u8:
                case BitmapDataBlock.FormatEnum.G8b8:
                    return PixelFormat.Rg;

                case BitmapDataBlock.FormatEnum.A8:
                    return PixelFormat.Red;

                case BitmapDataBlock.FormatEnum.P8:
                case BitmapDataBlock.FormatEnum.P8bump:
                    return PixelFormat.Red;

                case BitmapDataBlock.FormatEnum.Y8:
                case BitmapDataBlock.FormatEnum.Ay8:
                    return PixelFormat.Red;
                default:
                    throw new FormatException( "Unsupported Texture Format" );
            }
        }

        private float ParseBitapPixelDataSize(
            BitmapDataBlock.FormatEnum format )
        {
            switch ( format )
            {
                case BitmapDataBlock.FormatEnum.A1r5g5b5:
                case BitmapDataBlock.FormatEnum.A4r4g4b4:
                case BitmapDataBlock.FormatEnum.R5g6b5:
                case BitmapDataBlock.FormatEnum.A8y8:
                case BitmapDataBlock.FormatEnum.V8u8:
                case BitmapDataBlock.FormatEnum.G8b8:
                    return 16;

                case BitmapDataBlock.FormatEnum.A8:
                case BitmapDataBlock.FormatEnum.P8:
                case BitmapDataBlock.FormatEnum.P8bump:
                case BitmapDataBlock.FormatEnum.Y8:
                case BitmapDataBlock.FormatEnum.Ay8:
                case BitmapDataBlock.FormatEnum.Dxt3:
                case BitmapDataBlock.FormatEnum.Dxt5:
                    return 8;

                case BitmapDataBlock.FormatEnum.Dxt1:
                    return 4;

                case BitmapDataBlock.FormatEnum.A8r8g8b8:
                case BitmapDataBlock.FormatEnum.X8r8g8b8:
                    return 32;

                case BitmapDataBlock.FormatEnum.Argbfp32:
                    return 128;

                case BitmapDataBlock.FormatEnum.Rgbfp16:
                    return 48;

                case BitmapDataBlock.FormatEnum.Rgbfp32:
                    return 96;
                default:
                    throw new FormatException( "Unsupported Texture Format" );
            }
        }

        internal PixelInternalFormat ParseBitmapPixelInternalFormat(
            BitmapDataBlock.FormatEnum format )
        {
            PixelInternalFormat pixelFormat;
            switch ( format )
            {
                case BitmapDataBlock.FormatEnum.A1r5g5b5:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.A4r4g4b4:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.A8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.A8r8g8b8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.A8y8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.Argbfp32:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.Ay8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.Dxt1:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext;
                    break;
                case BitmapDataBlock.FormatEnum.Dxt3:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext;
                    break;
                case BitmapDataBlock.FormatEnum.Dxt5:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt5Ext;
                    break;
                case BitmapDataBlock.FormatEnum.G8b8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.P8:
                    pixelFormat = PixelInternalFormat.R8;
                    break;
                case BitmapDataBlock.FormatEnum.P8bump:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.R5g6b5:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.Rgbfp16:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.Rgbfp32:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.V8u8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.X8r8g8b8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                case BitmapDataBlock.FormatEnum.Y8:
                    pixelFormat = PixelInternalFormat.Rgba;
                    break;
                default:
                    throw new FormatException( "Unsupported Texture Format" );
            }
            return pixelFormat;
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( disposed ) return;
            if ( disposing )
            {
                GL.DeleteTexture( handle );
            }
            disposed = true;
        }

        public bool LoadPalettedTexture( BitmapDataBlock bitmapBlock, byte[] paletteData,
            TextureMagFilter textureMagFilter, TextureMinFilter textureMinFilter )
        {
            if ( bitmapBlock.Format != BitmapDataBlock.FormatEnum.P8 &&
                 bitmapBlock.Format != BitmapDataBlock.FormatEnum.P8bump )
                return false;
            textureTarget = TextureTarget.Texture2D;

            GL.BindTexture( TextureTarget.Texture2D, handle );
            OpenGL.GetError( );

            GL.TexParameter( textureTarget, TextureParameterName.TextureMagFilter,
                ( int ) textureMagFilter );
            OpenGL.GetError( );

            GL.TexParameter( textureTarget, TextureParameterName.TextureMinFilter,
                ( int ) textureMinFilter );
            OpenGL.GetError( );

            GL.TexParameter( textureTarget, TextureParameterName.TextureWrapS,
                ( int ) TextureWrapMode.Repeat );
            OpenGL.GetError( );

            GL.TexParameter( textureTarget, TextureParameterName.TextureWrapT,
                ( int ) TextureWrapMode.Repeat );
            OpenGL.GetError( );


            GL.TexStorage2D( ( TextureTarget2d ) textureTarget, 1, SizedInternalFormat.Rgba8, bitmapBlock.Width,
                bitmapBlock.Height );
            OpenGL.GetError( );

            var indexData = bitmapBlock.GetResourceData( 0 );
            var texelData = new byte[indexData.Length * 4];

            for ( var i = 0; i < indexData.Length; ++i )
            {
                var paletteIndex = indexData[ i ] * 4;
                var texelIndex = i * 4;
                texelData[ texelIndex + 0 ] = paletteData[ paletteIndex + 0 ];
                texelData[ texelIndex + 1 ] = paletteData[ paletteIndex + 1 ];
                texelData[ texelIndex + 2 ] = paletteData[ paletteIndex + 2 ];
                texelData[ texelIndex + 3 ] = paletteData[ paletteIndex + 3 ];
            }
            if ( bitmapBlock.BitmapDataFlags.HasFlag( BitmapDataBlock.Flags.Swizzled ) )
            {
                texelData = Swizzler.Swizzle( texelData, ( int ) ( 4 ),
                    bitmapBlock.Width, bitmapBlock.Height );
            }

            GL.TexSubImage2D( textureTarget, 0, 0, 0, bitmapBlock.Width, bitmapBlock.Height, PixelFormat.Bgra,
                PixelType.UnsignedByte, texelData );
            OpenGL.GetError( );

            GL.GenerateMipmap( GenerateMipmapTarget.Texture2D );
            OpenGL.GetError( );
            return true;
        }
    };
}