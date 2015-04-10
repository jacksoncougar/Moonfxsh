// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bitm")]
    public  partial class BitmapBlock : BitmapBlockBase
    {
        public  BitmapBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 76)]
    public class BitmapBlockBase
    {
        internal Type type;
        internal Format format;
        internal Usage usage;
        internal Flags flags;
        /// <summary>
        /// 0 means fade to gray by last mipmap; 1 means fade to gray by first mipmap.
        /// </summary>
        internal float detailFadeFactor01;
        /// <summary>
        /// Sharpens mipmap after downsampling.
        /// </summary>
        internal float sharpenAmount01;
        /// <summary>
        /// tApparent height of the bump map above the triangle onto which it is textured, in texture repeats (i.e., 1.0 would be as high as the texture is wide).
        /// </summary>
        internal float bumpHeightRepeats;
        internal SpriteSize spriteSize;
        internal short eMPTYSTRING;
        internal short colorPlateWidthPixels;
        internal short colorPlateHeightPixels;
        internal byte[] data;
        internal byte[] data0;
        /// <summary>
        /// Blurs the bitmap before generating mipmaps.
        /// </summary>
        internal float blurFilterSize010Pixels;
        /// <summary>
        /// Affects alpha mipmap generation.
        /// </summary>
        internal float alphaBias11;
        /// <summary>
        /// 0 Defaults to all levels.
        /// </summary>
        internal short mipmapCountLevels;
        internal SpriteUsage spriteUsage;
        internal short spriteSpacing;
        internal ForceFormat forceFormat;
        internal BitmapGroupSequenceBlock[] sequences;
        internal BitmapDataBlock[] bitmaps;
        internal  BitmapBlockBase(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            format = (Format)binaryReader.ReadInt16();
            usage = (Usage)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            detailFadeFactor01 = binaryReader.ReadSingle();
            sharpenAmount01 = binaryReader.ReadSingle();
            bumpHeightRepeats = binaryReader.ReadSingle();
            spriteSize = (SpriteSize)binaryReader.ReadInt16();
            eMPTYSTRING = binaryReader.ReadInt16();
            colorPlateWidthPixels = binaryReader.ReadInt16();
            colorPlateHeightPixels = binaryReader.ReadInt16();
            data = binaryReader.ReadBytes(8);
            data0 = binaryReader.ReadBytes(8);
            blurFilterSize010Pixels = binaryReader.ReadSingle();
            alphaBias11 = binaryReader.ReadSingle();
            mipmapCountLevels = binaryReader.ReadInt16();
            spriteUsage = (SpriteUsage)binaryReader.ReadInt16();
            spriteSpacing = binaryReader.ReadInt16();
            forceFormat = (ForceFormat)binaryReader.ReadInt16();
            ReadBitmapGroupSequenceBlockArray(binaryReader);
            ReadBitmapDataBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual BitmapGroupSequenceBlock[] ReadBitmapGroupSequenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BitmapGroupSequenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BitmapGroupSequenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BitmapGroupSequenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BitmapDataBlock[] ReadBitmapDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BitmapDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BitmapDataBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BitmapDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter, System.Byte[] data, ref Int64 nextAddress)
        {
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.BaseStream.Position = nextAddress;
                binaryWriter.BaseStream.Pad(8);
                binaryWriter.Write(data);
                binaryWriter.BaseStream.Pad(4);
                nextAddress = binaryWriter.BaseStream.Position;
            }
        }
        internal  virtual void WriteBitmapGroupSequenceBlockArray(BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBitmapDataBlockArray(BinaryWriter binaryWriter)
        {
            
        }
        public void Write(BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)format);
                binaryWriter.Write((Int16)usage);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(detailFadeFactor01);
                binaryWriter.Write(sharpenAmount01);
                binaryWriter.Write(bumpHeightRepeats);
                binaryWriter.Write((Int16)spriteSize);
                binaryWriter.Write(eMPTYSTRING);
                binaryWriter.Write(colorPlateWidthPixels);
                binaryWriter.Write(colorPlateHeightPixels);
                binaryWriter.Write(data, 0, 8);
                binaryWriter.Write(data0, 0, 8);
                binaryWriter.Write(blurFilterSize010Pixels);
                binaryWriter.Write(alphaBias11);
                binaryWriter.Write(mipmapCountLevels);
                binaryWriter.Write((Int16)spriteUsage);
                binaryWriter.Write(spriteSpacing);
                binaryWriter.Write((Int16)forceFormat);
                WriteBitmapGroupSequenceBlockArray(binaryWriter);
                WriteBitmapDataBlockArray(binaryWriter);
            }
        }
        internal enum Type : short
        
        {
            TextureArray2D = 0,
            TextureArray3D = 1,
            Cubemaps = 2,
            Sprites = 3,
            InterfaceBitmaps = 4,
        };
        internal enum Format : short
        
        {
            CompressedWithColorKeyTransparency = 0,
            CompressedWithExplicitAlpha = 1,
            CompressedWithInterpolatedAlpha = 2,
            Color16Bit = 3,
            Color32Bit = 4,
            Monochrome = 5,
        };
        internal enum Usage : short
        
        {
            AlphaBlend = 0,
            Default = 1,
            HeightMap = 2,
            DetailMap = 3,
            LightMap = 4,
            VectorMap = 5,
            HeightMapBLUE255 = 6,
            Embm = 7,
            HeightMapA8L8 = 8,
            HeightMapG8B8 = 9,
            HeightMapG8B8WAlpha = 10,
        };
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            EnableDiffusionDithering = 1,
            DisableHeightMapCompression = 2,
            UniformSpriteSequences = 4,
            FilthySpriteBugFix = 8,
            UseSharpBumpFilter = 16,
            UNUSED = 32,
            UseClampedMirroredBumpFilter = 64,
            InvertDetailFade = 128,
            SwapXYVectorComponents = 256,
            ConvertFromSigned = 512,
            ConvertToSigned = 1024,
            ImportMipmapChains = 2048,
            IntentionallyTrueColor = 4096,
        };
        internal enum SpriteSize : short
        
        {
            Size32X32 = 0,
            Size64X64 = 1,
            Size128X128 = 2,
            Size256X256 = 3,
            Size512X512 = 4,
            Size1024X1024 = 5,
        };
        internal enum SpriteUsage : short
        
        {
            BlendAddSubtractMax = 0,
            MultiplyMin = 1,
            DoubleMultiply = 2,
        };
        internal enum ForceFormat : short
        
        {
            Default = 0,
            ForceG8B8 = 1,
            ForceDXT1 = 2,
            ForceDXT3 = 3,
            ForceDXT5 = 4,
            ForceALPHALUMINANCE8 = 5,
            ForceA4R4G4B4 = 6,
        };
    };
}
