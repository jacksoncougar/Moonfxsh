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
            this.type = (Type)binaryReader.ReadInt16();
            this.format = (Format)binaryReader.ReadInt16();
            this.usage = (Usage)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.detailFadeFactor01 = binaryReader.ReadSingle();
            this.sharpenAmount01 = binaryReader.ReadSingle();
            this.bumpHeightRepeats = binaryReader.ReadSingle();
            this.spriteSize = (SpriteSize)binaryReader.ReadInt16();
            this.eMPTYSTRING = binaryReader.ReadInt16();
            this.colorPlateWidthPixels = binaryReader.ReadInt16();
            this.colorPlateHeightPixels = binaryReader.ReadInt16();
            this.data = binaryReader.ReadBytes(8);
            this.data0 = binaryReader.ReadBytes(8);
            this.blurFilterSize010Pixels = binaryReader.ReadSingle();
            this.alphaBias11 = binaryReader.ReadSingle();
            this.mipmapCountLevels = binaryReader.ReadInt16();
            this.spriteUsage = (SpriteUsage)binaryReader.ReadInt16();
            this.spriteSpacing = binaryReader.ReadInt16();
            this.forceFormat = (ForceFormat)binaryReader.ReadInt16();
            this.sequences = ReadBitmapGroupSequenceBlockArray(binaryReader);
            this.bitmaps = ReadBitmapDataBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual BitmapGroupSequenceBlock[] ReadBitmapGroupSequenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BitmapGroupSequenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BitmapGroupSequenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
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
            var array = new BitmapDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BitmapDataBlock(binaryReader);
                }
            }
            return array;
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
