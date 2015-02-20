using Moonfish.Guerilla.Tags;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Graphics
{
    public class Texture        
    {
        int handle;

        public void Load(BitmapBlock bitmapCollection, MapStream map, TextureUnit textureUnit, 
            TextureMagFilter textureMagFilter = TextureMagFilter.Linear, TextureMinFilter textureMinFilter = TextureMinFilter.Linear)
        {
            handle = GL.GenTexture();
            GL.ActiveTexture(textureUnit);

            var workingBitmap = bitmapCollection.bitmaps[0];
            byte[] buffer = new byte[workingBitmap.lOD1TextureDataLength];

            Stream resourceStream;
            Halo2.TryGettingResourceStream(workingBitmap.lOD1TextureDataOffset, out resourceStream);

            using (resourceStream.Pin())
            {
                resourceStream.Position = workingBitmap.lOD1TextureDataOffset & ~0xC0000000;
                resourceStream.Read(buffer, 0, buffer.Length);
            }

            var width = workingBitmap.widthPixels;
            var height = workingBitmap.heightPixels;
            var bytesPerPixel = ParseBitapPixelDataSize(workingBitmap.format) / 8.0f;

            if(workingBitmap.flags.HasFlag(BitmapDataBlock.Flags.Swizzled))
            {
                buffer = Swizzle(buffer, width, height, 1, (int)bytesPerPixel * 8, true);
            }
            PixelInternalFormat pixelInternalFormat = ParseBitmapPixelInternalFormat(workingBitmap.format);


            switch (workingBitmap.type)
            {
                case BitmapDataBlockBase.TypeDeterminesBitmapGeometry.Texture2D:
                    {
                        GL.BindTexture(TextureTarget.Texture2D, this.handle);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)textureMagFilter);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)textureMinFilter);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat); OpenGL.ReportError();

                        byte[] surfaceData = new byte[(int)(bytesPerPixel * width * height)];
                        Array.Copy(buffer, 0, surfaceData, 0, surfaceData.Length);


                        if (workingBitmap.flags.HasFlag(BitmapDataBlock.Flags.Compressed))
                        {
                            GL.CompressedTexImage2D(
                                TextureTarget.Texture2D, 0, pixelInternalFormat, width, height, 0, (int)(bytesPerPixel * width * height), surfaceData);
                        }
                        else
                        {
                            var pixelFormat = ParseBitapPixelFormat(workingBitmap.format);
                            var pixelType = ParseBitapPixelType(workingBitmap.format);
                            GL.TexImage2D(TextureTarget.Texture2D, 0, pixelInternalFormat, width, height, 0, pixelFormat, pixelType, surfaceData);
                        }
                    } break;
                case BitmapDataBlockBase.TypeDeterminesBitmapGeometry.Cubemap:
                    {
                        GL.BindTexture(TextureTarget.TextureCubeMap, this.handle);
                        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (int)textureMagFilter);
                        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)textureMinFilter);
                        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
                        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
                        GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (int)TextureWrapMode.ClampToEdge); OpenGL.ReportError();

                        TextureTarget[] cube = { 
                                                   TextureTarget.TextureCubeMapPositiveX,
                                                   TextureTarget.TextureCubeMapNegativeX,
                                                   TextureTarget.TextureCubeMapPositiveY,
                                                   TextureTarget.TextureCubeMapNegativeY,
                                                   TextureTarget.TextureCubeMapPositiveZ,
                                                   TextureTarget.TextureCubeMapNegativeZ,
                                               };

                        for (int i = 0; i < 6; ++i)
                        {

                            byte[] surfaceData = new byte[(int)(bytesPerPixel * width * height)];
                            int stride = buffer.Length / 6;
                            Array.Copy(buffer, stride * i, surfaceData, 0, surfaceData.Length);


                            if (workingBitmap.flags.HasFlag(BitmapDataBlock.Flags.Compressed))
                            {
                                GL.CompressedTexImage2D(
                                    cube[i], 0, pixelInternalFormat, width, height, 0, (int)(bytesPerPixel * width * height), surfaceData);
                            }
                            else
                            {
                                var pixelFormat = ParseBitapPixelFormat(workingBitmap.format);
                                var pixelType = ParseBitapPixelType(workingBitmap.format);
                                GL.TexImage2D(cube[i], 0, pixelInternalFormat, width, height, 0, pixelFormat, pixelType, surfaceData);
                            }
                        }
                    } break;
                default: GL.DeleteTexture(this.handle); break;
            }

            OpenGL.ReportError();
        }

        public void Bind(TextureTarget target)
        {
            GL.BindTexture(target, this.handle);
        }

        public static byte[] Swizzle(byte[] raw, int pixOffset, int width, int height, int depth, int bitCount, bool deswizzle)
        {
            bitCount /= 8;
            int a = 0;
            int b = 0;
            byte[] dataArray = new byte[raw.Length]; //width * height * bitCount;

            MaskSet masks = new MaskSet(width, height, depth);
            pixOffset = 0;
            for (int y = 0; y < height * depth; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (deswizzle)
                    {
                        a = ((y * width) + x) * bitCount;
                        b = (Swizzle(x, y, depth, masks)) * bitCount;
                    }
                    else
                    {
                        b = ((y * width) + x) * bitCount;
                        a = (Swizzle(x, y, depth, masks)) * bitCount;
                    }

                    if (a < dataArray.Length && b < raw.Length)
                    {
                        for (int i = pixOffset; i < bitCount + pixOffset; i++)
                            dataArray[a + i] = raw[b + i];
                    }
                    else return null;
                }
            }

            //for(int u = 0; u < offset; u++)
            //data[u] = raw[u];
            //for(int v = offset + (height * width * depth * bitCount); v < data.Length; v++)
            //	data[v] = raw[v];

            return dataArray;
        }

        public static byte[] Swizzle(byte[] raw, int width, int height, int depth, int bitCount, bool deswizzle)
        {
            return Swizzle(raw, 0, width, height, depth, bitCount, deswizzle);
        }

        private static int Swizzle(int x, int y, int z, MaskSet masks)
        {
            return SwizzleAxis(x, masks.x) | SwizzleAxis(y, masks.y) | (z == -1 ? 0 : SwizzleAxis(z, masks.z));
        }

        private static int SwizzleAxis(int val, int mask)
        {
            int bit = 1;
            int result = 0;

            while (bit <= mask)
            {
                int tmp = mask & bit;

                if (tmp != 0) result |= (val & bit);
                else val <<= 1;

                bit <<= 1;
            }

            return result;
        }

        private class MaskSet
        {
            public int x = 0;
            public int y = 0;
            public int z = 0;

            public MaskSet(int w, int h, int d)
            {
                int bit = 1;
                int index = 1;

                while (bit < w || bit < h || bit < d)
                {
                    if (bit < w)
                    {
                        x |= index;
                        index <<= 1;
                    }
                    if (bit < h)
                    {
                        y |= index;
                        index <<= 1;
                    }
                    if (bit < d)
                    {
                        z |= index;
                        index <<= 1;
                    }
                    bit <<= 1;
                }
            }
        }

        private PixelType ParseBitapPixelType(BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format)
        {
            switch (format)
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
                    return PixelType.Byte;

                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8r8g8b8:
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.X8r8g8b8:
                    return PixelType.UnsignedInt;
                default: throw new FormatException("Unsupported Texture Format");
            }
        }

        private PixelFormat ParseBitapPixelFormat(BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format)
        {
            switch (format)
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
                default: throw new FormatException("Unsupported Texture Format");
            }
        }

        private float ParseBitapPixelDataSize(BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format)
        {
            switch (format)
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
                default: throw new FormatException("Unsupported Texture Format");
            }
        }

        internal PixelInternalFormat ParseBitmapPixelInternalFormat(BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally format)
        {
            PixelInternalFormat pixelFormat;
            switch (format)
            {
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A1r5g5b5:
                    pixelFormat = PixelInternalFormat.Rgb5A1; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A4r4g4b4:
                    pixelFormat = PixelInternalFormat.Rgba4; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8:
                    pixelFormat = PixelInternalFormat.Alpha8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8r8g8b8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.A8y8:
                    pixelFormat = PixelInternalFormat.Luminance8Alpha8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Argbfp32:
                    pixelFormat = PixelInternalFormat.Rgba32f; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Ay8:
                    pixelFormat = PixelInternalFormat.Luminance8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt1:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt1Ext; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt3:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt3Ext; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Dxt5:
                    pixelFormat = PixelInternalFormat.CompressedRgbaS3tcDxt5Ext; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.G8b8:
                    pixelFormat = PixelInternalFormat.Rg8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8:
                    pixelFormat = PixelInternalFormat.R8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.P8Bump:
                    pixelFormat = PixelInternalFormat.R8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.R5g6b5:
                    pixelFormat = PixelInternalFormat.R5G6B5IccSgix; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp16:
                    pixelFormat = PixelInternalFormat.Rgb16f; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Rgbfp32:
                    pixelFormat = PixelInternalFormat.Rgb32f; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.V8u8:
                    pixelFormat = PixelInternalFormat.Rg8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.X8r8g8b8:
                    pixelFormat = PixelInternalFormat.Rgba8; break;
                case BitmapDataBlockBase.FormatDeterminesHowPixelsAreRepresentedInternally.Y8:
                    pixelFormat = PixelInternalFormat.Luminance8; break;
                default: throw new FormatException("Unsupported Texture Format");
            }
            return pixelFormat;
        }
    }
}
