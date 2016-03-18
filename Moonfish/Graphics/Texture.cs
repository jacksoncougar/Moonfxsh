using System;
using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    /// <summary>
    /// Controls blam texture buffering and handling
    /// </summary>
    public sealed class TextureHandle : IDisposable
    {
        #region Palette Data

        /// <summary>
        ///     This is the colour palette of the P8 texture
        /// </summary>
        private static readonly byte[] P8ColourBytes =
        {
            #region bytes
            255, 126, 126, 255, 255, 127, 126, 255, 255, 128, 126, 255, 255, 129, 126, 255, 255, 126,
            127, 255, 255, 127, 127, 255, 255, 128, 127, 255, 255, 129, 127, 255, 255, 126, 128, 255,
            255, 127, 128, 255, 255, 128, 128, 255, 255, 129, 128, 255, 255, 126, 129, 255, 255, 127,
            129, 255, 255, 128, 129, 255, 255, 129, 129, 255, 255, 130, 127, 255, 255, 127, 131, 255,
            255, 127, 125, 255, 255, 131, 129, 255, 255, 124, 129, 255, 255, 130, 124, 255, 255, 129,
            132, 255, 255, 124, 125, 255, 255, 133, 127, 255, 255, 125, 132, 255, 255, 128, 122, 255,
            255, 132, 132, 255, 255, 122, 128, 255, 255, 133, 124, 255, 255, 127, 135, 255, 255, 124,
            122, 255, 255, 136, 130, 255, 255, 121, 132, 255, 255, 131, 120, 255, 255, 132, 136, 255,
            255, 119, 124, 255, 255, 137, 125, 255, 255, 123, 137, 255, 255, 125, 118, 255, 255, 137,
            134, 255, 255, 117, 130, 255, 255, 135, 119, 255, 255, 129, 140, 255, 255, 119, 120, 255,
            255, 141, 128, 255, 255, 119, 137, 255, 255, 129, 115, 255, 255, 136, 139, 255, 255, 114,
            126, 255, 255, 140, 120, 255, 255, 124, 142, 255, 255, 121, 115, 255, 255, 142, 133, 255,
            255, 113, 134, 255, 254, 135, 113, 255, 254, 133, 144, 255, 254, 113, 120, 255, 254, 145,
            124, 255, 254, 118, 142, 255, 254, 126, 110, 255, 254, 142, 140, 255, 254, 109, 129, 255,
            254, 142, 114, 255, 254, 127, 147, 255, 254, 115, 113, 255, 254, 148, 131, 255, 254, 111,
            140, 255, 254, 133, 107, 255, 254, 139, 147, 255, 254, 107, 121, 255, 254, 148, 119, 255,
            253, 119, 149, 255, 253, 120, 106, 255, 253, 149, 139, 255, 253, 105, 134, 255, 253, 141,
            108, 255, 253, 132, 152, 255, 253, 108, 113, 255, 253, 153, 126, 255, 253, 111, 147, 255,
            253, 128, 102, 255, 253, 146, 147, 255, 253, 101, 126, 255, 253, 150, 111, 255, 252, 123,
            155, 255, 252, 113, 104, 255, 252, 155, 135, 255, 252, 103, 141, 255, 252, 138, 101, 255,
            252, 139, 155, 255, 252, 101, 115, 255, 252, 157, 119, 255, 252, 113, 155, 255, 252, 121,
            98, 255, 252, 154, 146, 255, 251, 96, 132, 255, 251, 149, 103, 255, 251, 129, 161, 255,
            251, 105, 105, 255, 251, 161, 129, 255, 251, 102, 150, 255, 251, 132, 94, 255, 251, 148,
            156, 255, 251, 94, 120, 255, 251, 159, 110, 255, 250, 117, 162, 255, 250, 113, 95, 255,
            250, 162, 142, 255, 250, 93, 141, 255, 250, 145, 95, 255, 250, 138, 164, 255, 250, 96,
            108, 255, 250, 166, 121, 255, 249, 104, 159, 255, 249, 125, 89, 255, 249, 157, 155, 255,
            249, 88, 128, 255, 249, 158, 101, 255, 249, 124, 169, 255, 249, 103, 95, 255, 248, 169,
            135, 255, 248, 92, 151, 255, 248, 139, 87, 255, 248, 148, 166, 255, 248, 87, 113, 255,
            248, 168, 111, 255, 248, 109, 168, 255, 247, 115, 86, 255, 247, 167, 150, 255, 247, 84,
            138, 255, 247, 154, 91, 255, 247, 134, 174, 255, 247, 92, 98, 255, 247, 175, 126, 255,
            246, 94, 162, 255, 246, 130, 80, 255, 246, 159, 165, 255, 246, 80, 122, 255, 246, 168,
            100, 255, 246, 117, 176, 255, 245, 103, 85, 255, 245, 176, 143, 255, 245, 82, 149, 255,
            245, 148, 81, 255, 245, 146, 176, 255, 244, 82, 104, 255, 244, 178, 114, 255, 244, 100,
            172, 255, 244, 119, 76, 255, 244, 170, 161, 255, 244, 74, 133, 255, 243, 165, 88, 255,
            243, 128, 183, 255, 243, 91, 87, 255, 243, 183, 133, 255, 243, 84, 162, 255, 242, 138,
            73, 255, 242, 158, 176, 255, 242, 73, 113, 255, 242, 179, 101, 255, 242, 108, 182, 255,
            241, 106, 74, 255, 241, 181, 153, 255, 241, 72, 146, 255, 241, 158, 76, 255, 240, 141,
            187, 255, 240, 79, 93, 255, 240, 188, 120, 255, 240, 89, 175, 255, 240, 125, 66, 255,
            239, 172, 172, 255, 239, 66, 125, 255, 239, 176, 88, 255, 239, 120, 191, 255, 238, 92,
            76, 255, 238, 191, 142, 255, 238, 72, 160, 255, 238, 148, 66, 255, 237, 156, 187, 255,
            237, 67, 103, 255, 237, 190, 105, 255, 237, 97, 187, 255, 237, 111, 63, 255, 236, 185,
            164, 255, 236, 61, 140, 255, 236, 170, 74, 255, 235, 134, 196, 255, 235, 77, 81, 255,
            235, 197, 128, 255, 235, 77, 175, 255, 234, 134, 58, 255, 234, 171, 184, 255, 234, 58,
            116, 255, 234, 188, 90, 255, 233, 109, 197, 255, 233, 95, 64, 255, 233, 196, 153, 255,
            233, 61, 156, 255, 232, 159, 62, 255, 232, 150, 198, 255, 232, 64, 91, 255, 231, 201,
            112, 255, 231, 85, 189, 255, 231, 118, 53, 255, 231, 186, 177, 255, 230, 52, 131, 255,
            230, 182, 74, 255, 230, 125, 205, 255, 229, 78, 69, 255, 229, 205, 138, 255, 229, 64,
            173, 255, 228, 145, 51, 255, 228, 167, 196, 255, 228, 52, 104, 255, 227, 200, 94, 255,
            227, 97, 202, 255, 227, 101, 52, 255, 227, 200, 165, 255, 226, 49, 149, 255, 226, 172,
            59, 255, 226, 142, 209, 255, 225, 63, 78, 255, 225, 211, 121, 255, 225, 72, 189, 255,
            224, 128, 44, 255, 224, 185, 190, 255, 224, 44, 121, 255, 223, 195, 76, 255, 223, 113,
            212, 255, 223, 82, 56, 255, 222, 211, 150, 255, 222, 51, 168, 255, 221, 158, 47, 255,
            221, 161, 209, 255, 221, 49, 91, 255, 220, 212, 102, 255, 220, 84, 204, 255, 220, 109,
            41, 255, 219, 201, 179, 255, 219, 39, 140, 255, 219, 186, 59, 255, 218, 132, 218, 255,
            218, 64, 64, 255, 217, 219, 132, 255, 217, 58, 187, 255, 217, 140, 37, 255, 216, 181,
            203, 255, 216, 38, 108, 255, 216, 208, 82, 255, 215, 100, 217, 255, 215, 89, 43, 255,
            214, 215, 164, 255, 214, 39, 160, 255, 214, 172, 44, 255, 255, 128, 128, 0
            #endregion
        };

        #endregion

        private readonly int _handle;
        private bool _disposed;
        private TextureTarget _textureTarget;

        public TextureHandle( )
        {
            _handle = GL.GenTexture( );
        }

        /// <summary>
        /// Deletes the texture data from GPU
        /// </summary>
        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }

        /// <summary>
        /// Binds texture data to GPU target
        /// </summary>
        public void Bind( )
        {
            if ( Enum.IsDefined( typeof ( TextureTarget ), _textureTarget ) )
                GL.BindTexture( _textureTarget, _handle );
        }

        /// <summary>
        /// Creates a texture on the GPU with the chosen parameters
        /// </summary>
        /// <param name="bitmapBlock"></param>
        /// <param name="textureMagFilter"></param>
        /// <param name="textureMinFilter"></param>
        public void Load( BitmapDataBlock bitmapBlock,
            TextureMagFilter textureMagFilter = TextureMagFilter.Linear,
            TextureMinFilter textureMinFilter = TextureMinFilter.Linear )
        {
            var buffer = bitmapBlock.GetResourceData( );
            if ( buffer == null ) return;
            var width = bitmapBlock.Width;
            var height = bitmapBlock.Height;

            var bytesPerPixel = GetBitSize( bitmapBlock.Format ) / 8.0f;

            if ( bitmapBlock.BitmapDataFlags.HasFlag( BitmapDataBlock.Flags.Palettized ) )
            {
                LoadPalettedTexture( bitmapBlock, P8ColourBytes, textureMagFilter, textureMinFilter );
                return;
            }

            if ( bitmapBlock.BitmapDataFlags.HasFlag( BitmapDataBlock.Flags.Swizzled ) )
            {
                buffer = Swizzler.Swizzle( buffer, ( int ) bytesPerPixel, width, height );
            }

            var pixelInternalFormat = GetPixelInternalFormat( bitmapBlock.Format );

            switch ( bitmapBlock.Type )
            {
                case BitmapDataBlock.TypeEnum.Texture2D:
                {
                    LoadTexture2D( textureMagFilter, textureMinFilter, bytesPerPixel, width, height, buffer,
                        bitmapBlock, pixelInternalFormat );
                }

                    break;
                case BitmapDataBlock.TypeEnum.Cubemap:
                {
                    LoadCubemap( textureMagFilter, textureMinFilter, bytesPerPixel, width, height, buffer, bitmapBlock,
                        pixelInternalFormat );
                }

                    break;
                case BitmapDataBlock.TypeEnum.Texture3D:
                {
                    LoadTexture2D( textureMagFilter, textureMinFilter, bytesPerPixel, width, height, buffer,
                        bitmapBlock, pixelInternalFormat );
                }
                    break;
                default:
                {
                    GL.DeleteTexture( _handle );
                }
                    break;
            }
        }

        private void LoadPalettedTexture( BitmapDataBlock bitmapBlock, byte[] paletteData, TextureMagFilter textureMagFilter, TextureMinFilter textureMinFilter )
        {
            if ( bitmapBlock.Format != BitmapDataBlock.FormatEnum.P8 &&
                 bitmapBlock.Format != BitmapDataBlock.FormatEnum.P8bump )
                return;
            _textureTarget = TextureTarget.Texture2D;

            GL.BindTexture( TextureTarget.Texture2D, _handle );
            GL.TexParameter( _textureTarget, TextureParameterName.TextureMagFilter,
                ( int ) textureMagFilter );
            GL.TexParameter( _textureTarget, TextureParameterName.TextureMinFilter,
                ( int ) textureMinFilter );
            GL.TexParameter( _textureTarget, TextureParameterName.TextureWrapS,
                ( int ) TextureWrapMode.Repeat );
            GL.TexParameter( _textureTarget, TextureParameterName.TextureWrapT,
                ( int ) TextureWrapMode.Repeat );

            GL.TexStorage2D( ( TextureTarget2d ) _textureTarget, 1, SizedInternalFormat.Rgba8, bitmapBlock.Width,
                bitmapBlock.Height );

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
                texelData = Swizzler.Swizzle( texelData, 4,
                    bitmapBlock.Width, bitmapBlock.Height );
            }

            GL.TexSubImage2D( _textureTarget, 0, 0, 0, bitmapBlock.Width, bitmapBlock.Height, PixelFormat.Bgra,
                PixelType.UnsignedByte, texelData );

            GL.GenerateMipmap( GenerateMipmapTarget.Texture2D );
            return;
        }

        private void Dispose( bool disposing )
        {
            if ( _disposed ) return;
            if ( disposing )
            {
                GL.DeleteTexture( _handle );
            }
            _disposed = true;
        }

        private static int GetBitSize( BitmapDataBlock.FormatEnum format )
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

        private static PixelFormat GetPixelFormat( BitmapDataBlock.FormatEnum format )
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

        private PixelInternalFormat GetPixelInternalFormat(
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

        private static PixelType GetPixelType( BitmapDataBlock.FormatEnum format )
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

        private void LoadCubemap( TextureMagFilter textureMagFilter, TextureMinFilter textureMinFilter,
            float bytesPerPixel,
            short width, short height, byte[] buffer, BitmapDataBlock workingBitmap,
            PixelInternalFormat pixelInternalFormat )
        {
            _textureTarget = TextureTarget.TextureCubeMap;
            GL.BindTexture( TextureTarget.TextureCubeMap, _handle );
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
                    var pixelFormat = GetPixelFormat( workingBitmap.Format );
                    var pixelType = GetPixelType( workingBitmap.Format );
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
            _textureTarget = TextureTarget.Texture2D;
            GL.BindTexture( TextureTarget.Texture2D, _handle );
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
                var pixelFormat = GetPixelFormat( workingBitmap.Format );
                var pixelType = GetPixelType( workingBitmap.Format );
                GL.TexImage2D( TextureTarget.Texture2D, 0, pixelInternalFormat, width, height, 0, pixelFormat,
                    pixelType, surfaceData );
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                    (int)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                    (int)TextureMinFilter.LinearMipmapLinear);
            }
        }
    };
}