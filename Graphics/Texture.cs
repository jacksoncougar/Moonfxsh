using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace Moonfish.Graphics
{
    public class Texture : IDisposable
    {
        bool disposed = false;
        int handle;
        TextureTarget textureTarget;

        public Texture( )
        {
            handle = GL.GenTexture();
        }

        public void Load( BitmapBlock bitmapCollection, MapStream map,
            TextureUnit textureUnit = TextureUnit.Texture0,
            TextureMagFilter textureMagFilter = TextureMagFilter.Linear,
            TextureMinFilter textureMinFilter = TextureMinFilter.Linear )
        {
            GL.ActiveTexture( textureUnit );
            OpenGL.ReportError();

            var workingBitmap = bitmapCollection.bitmaps[ 0 ];
            byte[] buffer = new byte[ workingBitmap.lOD1TextureDataLength ];

            Stream resourceStream;
            if ( !Halo2.TryGettingResourceStream( workingBitmap.lOD1TextureDataOffset, out resourceStream ) )
            {
                return;
            }

            using ( resourceStream.Pin() )
            {
                resourceStream.Position = workingBitmap.lOD1TextureDataOffset & ~0xC0000000;
                resourceStream.Read( buffer, 0, buffer.Length );
            }

            var width = workingBitmap.widthPixels;
            var height = workingBitmap.heightPixels;
            var bytesPerPixel = ParseBitapPixelDataSize( workingBitmap.format ) / 8.0f;

            if ( workingBitmap.flags.HasFlag( BitmapDataBlock.Flags.Palettized ) )
            {
                textureMagFilter = TextureMagFilter.Nearest;
                textureMinFilter = TextureMinFilter.Nearest;
            }
            if ( workingBitmap.flags.HasFlag( BitmapDataBlock.Flags.Swizzled ) )
            {
                buffer = Swizzler.Swizzle( buffer, ( int )bytesPerPixel, width, height, 1 );
            }
            PixelInternalFormat pixelInternalFormat = ParseBitmapPixelInternalFormat( workingBitmap.format );


            switch ( workingBitmap.type )
            {
                case BitmapDataBlockBase.TypeDeterminesBitmapGeometry.Texture2D:
                    {
                        textureTarget = TextureTarget.Texture2D;
                        GL.BindTexture( TextureTarget.Texture2D, this.handle );
                        OpenGL.ReportError();
                        GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, ( int )textureMagFilter );
                        OpenGL.ReportError();
                        GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, ( int )textureMinFilter );
                        OpenGL.ReportError();
                        GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapS, ( int )TextureWrapMode.Repeat );
                        OpenGL.ReportError();
                        GL.TexParameter( TextureTarget.Texture2D, TextureParameterName.TextureWrapT, ( int )TextureWrapMode.Repeat ); 
                        OpenGL.ReportError();

                        byte[] surfaceData = new byte[ ( int )( bytesPerPixel * width * height ) ];
                        Array.Copy( buffer, 0, surfaceData, 0, surfaceData.Length );

                        if ( workingBitmap.flags.HasFlag( BitmapDataBlock.Flags.Compressed ) )
                        {
                            GL.CompressedTexImage2D(
                                TextureTarget.Texture2D, 0, pixelInternalFormat, width, height, 0, ( int )( bytesPerPixel * width * height ), surfaceData );

                            OpenGL.ReportError();
                        }
                        else
                        {
                            var pixelFormat = ParseBitapPixelFormat( workingBitmap.format );
                            var pixelType = ParseBitapPixelType( workingBitmap.format );
                            GL.TexImage2D( TextureTarget.Texture2D, 0, pixelInternalFormat, width, height, 0, pixelFormat, pixelType, surfaceData );

                            OpenGL.ReportError();
                        }
                    } break;
                case BitmapDataBlockBase.TypeDeterminesBitmapGeometry.Cubemap:
                    {
                        textureTarget = TextureTarget.TextureCubeMap;
                        GL.BindTexture( TextureTarget.TextureCubeMap, this.handle );
                        GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, ( int )textureMagFilter );
                        GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, ( int )textureMinFilter );
                        GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, ( int )TextureWrapMode.ClampToEdge );
                        GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, ( int )TextureWrapMode.ClampToEdge );
                        GL.TexParameter( TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, ( int )TextureWrapMode.ClampToEdge ); OpenGL.ReportError();

                        TextureTarget[] cube = { 
                                                   TextureTarget.TextureCubeMapPositiveX,
                                                   TextureTarget.TextureCubeMapNegativeX,
                                                   TextureTarget.TextureCubeMapPositiveY,
                                                   TextureTarget.TextureCubeMapNegativeY,
                                                   TextureTarget.TextureCubeMapPositiveZ,
                                                   TextureTarget.TextureCubeMapNegativeZ,
                                               };
                        OpenGL.ReportError();

                        for ( int i = 0; i < 6; ++i )
                        {

                            byte[] surfaceData = new byte[ ( int )( bytesPerPixel * width * height ) ];
                            int stride = buffer.Length / 6;
                            Array.Copy( buffer, stride * i, surfaceData, 0, surfaceData.Length );


                            if ( workingBitmap.flags.HasFlag( BitmapDataBlock.Flags.Compressed ) )
                            {
                                GL.CompressedTexImage2D(
                                    cube[ i ], 0, pixelInternalFormat, width, height, 0, ( int )( bytesPerPixel * width * height ), surfaceData );

                                OpenGL.ReportError();
                            }
                            else
                            {
                                var pixelFormat = ParseBitapPixelFormat( workingBitmap.format );
                                var pixelType = ParseBitapPixelType( workingBitmap.format );
                                GL.TexImage2D( cube[ i ], 0, pixelInternalFormat, width, height, 0, pixelFormat, pixelType, surfaceData );

                                OpenGL.ReportError();
                            }
                        }
                    } break;
                default: GL.DeleteTexture( this.handle ); break;
            }

            OpenGL.ReportError();
        }
        public void Bind( )
        {
            if ( textureTarget == TextureTarget.Texture2D || textureTarget == TextureTarget.TextureCubeMap )
                GL.BindTexture( this.textureTarget, this.handle );
        }

        private PixelType ParseBitapPixelType( BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format )
        {
            switch ( format )
            {
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A1r5g5b5:
                    return PixelType.UnsignedShort5551;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A4r4g4b4:
                    return PixelType.UnsignedShort4444;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.R5g6b5:
                    return PixelType.UnsignedShort565;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8y8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.V8u8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.G8b8:
                    return PixelType.UnsignedShort;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Y8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8Bump:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Ay8:
                    return PixelType.UnsignedByte;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8r8g8b8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.X8r8g8b8:
                    return PixelType.UnsignedInt;
                default: throw new FormatException( "Unsupported Texture Format" );
            }
        }

        private PixelFormat ParseBitapPixelFormat( BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format )
        {
            switch ( format )
            {
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A1r5g5b5:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A4r4g4b4:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Argbfp32:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8r8g8b8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.X8r8g8b8:
                    return PixelFormat.Rgba;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.R5g6b5:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp16:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp32:
                    return PixelFormat.Rgb;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8y8:
                    return PixelFormat.LuminanceAlpha;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.V8u8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.G8b8:
                    return PixelFormat.Rg;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8:
                    return PixelFormat.Alpha;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8Bump:
                    return PixelFormat.Red;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Y8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Ay8:
                    return PixelFormat.Luminance;
                default: throw new FormatException( "Unsupported Texture Format" );
            }
        }

        private float ParseBitapPixelDataSize( BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format )
        {
            switch ( format )
            {
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A1r5g5b5:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A4r4g4b4:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.R5g6b5:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8y8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.V8u8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.G8b8:
                    return 16;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8Bump:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Y8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Ay8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt3:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt5:
                    return 8;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt1:
                    return 4;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8r8g8b8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.X8r8g8b8:
                    return 32;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Argbfp32:
                    return 128;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp16:
                    return 48;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp32:
                    return 96;
                default: throw new FormatException( "Unsupported Texture Format" );
            }
        }

        internal PixelInternalFormat ParseBitmapPixelInternalFormat( BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format )
        {
            PixelInternalFormat pixelFormat;
            switch ( format )
            {
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A1r5g5b5:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A4r4g4b4:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8r8g8b8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8y8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Argbfp32:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Ay8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt1:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt3:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt5:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt5Ext; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.G8b8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8Bump:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.R5g6b5:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp16:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp32:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.V8u8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.X8r8g8b8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Y8:
                    pixelFormat = PixelInternalFormat.Luminance8; break;
                default: throw new FormatException( "Unsupported Texture Format" );
            }
            return pixelFormat;
        }

        public void Dispose( )
        {
            Dispose( true );
            GC.SuppressFinalize( this );    
        }

        protected virtual void Dispose( bool disposing )
        {
            if ( disposed ) return;
            if ( disposing )
            {
                GL.DeleteTexture( this.handle );
            }
            disposed = true;
        }
    }
}
