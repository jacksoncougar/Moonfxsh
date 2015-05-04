// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class BitmapDataBlock : BitmapDataBlockBase
    {
        public BitmapDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class BitmapDataBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.TagClass signature;
        internal short widthPixels;
        internal short heightPixels;
        /// <summary>
        /// Depth is 1 for 2D textures and cube maps.
        /// </summary>
        internal byte depthPixels;
        internal MoreFlags moreFlags;
        /// <summary>
        /// Determines bitmap "geometry."
        /// </summary>
        internal TypeDeterminesBitmapGeometry type;
        /// <summary>
        /// Determines how pixels are represented internally.
        /// </summary>
        internal FormatDeterminesHowPixelsAreRepresentedInternally format;
        internal Flags flags;
        internal Moonfish.Tags.Point registrationPoint;
        internal short mipmapCount;
        internal short lowDetailMipmapCount;
        internal int pixelsOffset;
        internal int lOD1TextureDataOffset;
        internal int lOD2TextureDataOffset;
        internal int lOD3TextureDataOffset;
        internal byte[] invalidName_;
        internal int lOD1TextureDataLength;
        internal int lOD2TextureDataLength;
        internal int lOD3TextureDataLength;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 116; } }
        public override int Alignment { get { return 4; } }
        public BitmapDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            signature = binaryReader.ReadTagClass();
            widthPixels = binaryReader.ReadInt16();
            heightPixels = binaryReader.ReadInt16();
            depthPixels = binaryReader.ReadByte();
            moreFlags = (MoreFlags)binaryReader.ReadByte();
            type = (TypeDeterminesBitmapGeometry)binaryReader.ReadInt16();
            format = (FormatDeterminesHowPixelsAreRepresentedInternally)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            registrationPoint = binaryReader.ReadPoint();
            mipmapCount = binaryReader.ReadInt16();
            lowDetailMipmapCount = binaryReader.ReadInt16();
            pixelsOffset = binaryReader.ReadInt32();
            lOD1TextureDataOffset = binaryReader.ReadInt32();
            lOD2TextureDataOffset = binaryReader.ReadInt32();
            lOD3TextureDataOffset = binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(12);
            lOD1TextureDataLength = binaryReader.ReadInt32();
            lOD2TextureDataLength = binaryReader.ReadInt32();
            lOD3TextureDataLength = binaryReader.ReadInt32();
            invalidName_0 = binaryReader.ReadBytes(52);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
            invalidName_0[16].ReadPointers(binaryReader, blamPointers);
            invalidName_0[17].ReadPointers(binaryReader, blamPointers);
            invalidName_0[18].ReadPointers(binaryReader, blamPointers);
            invalidName_0[19].ReadPointers(binaryReader, blamPointers);
            invalidName_0[20].ReadPointers(binaryReader, blamPointers);
            invalidName_0[21].ReadPointers(binaryReader, blamPointers);
            invalidName_0[22].ReadPointers(binaryReader, blamPointers);
            invalidName_0[23].ReadPointers(binaryReader, blamPointers);
            invalidName_0[24].ReadPointers(binaryReader, blamPointers);
            invalidName_0[25].ReadPointers(binaryReader, blamPointers);
            invalidName_0[26].ReadPointers(binaryReader, blamPointers);
            invalidName_0[27].ReadPointers(binaryReader, blamPointers);
            invalidName_0[28].ReadPointers(binaryReader, blamPointers);
            invalidName_0[29].ReadPointers(binaryReader, blamPointers);
            invalidName_0[30].ReadPointers(binaryReader, blamPointers);
            invalidName_0[31].ReadPointers(binaryReader, blamPointers);
            invalidName_0[32].ReadPointers(binaryReader, blamPointers);
            invalidName_0[33].ReadPointers(binaryReader, blamPointers);
            invalidName_0[34].ReadPointers(binaryReader, blamPointers);
            invalidName_0[35].ReadPointers(binaryReader, blamPointers);
            invalidName_0[36].ReadPointers(binaryReader, blamPointers);
            invalidName_0[37].ReadPointers(binaryReader, blamPointers);
            invalidName_0[38].ReadPointers(binaryReader, blamPointers);
            invalidName_0[39].ReadPointers(binaryReader, blamPointers);
            invalidName_0[40].ReadPointers(binaryReader, blamPointers);
            invalidName_0[41].ReadPointers(binaryReader, blamPointers);
            invalidName_0[42].ReadPointers(binaryReader, blamPointers);
            invalidName_0[43].ReadPointers(binaryReader, blamPointers);
            invalidName_0[44].ReadPointers(binaryReader, blamPointers);
            invalidName_0[45].ReadPointers(binaryReader, blamPointers);
            invalidName_0[46].ReadPointers(binaryReader, blamPointers);
            invalidName_0[47].ReadPointers(binaryReader, blamPointers);
            invalidName_0[48].ReadPointers(binaryReader, blamPointers);
            invalidName_0[49].ReadPointers(binaryReader, blamPointers);
            invalidName_0[50].ReadPointers(binaryReader, blamPointers);
            invalidName_0[51].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(signature);
                binaryWriter.Write(widthPixels);
                binaryWriter.Write(heightPixels);
                binaryWriter.Write(depthPixels);
                binaryWriter.Write((Byte)moreFlags);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)format);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(registrationPoint);
                binaryWriter.Write(mipmapCount);
                binaryWriter.Write(lowDetailMipmapCount);
                binaryWriter.Write(pixelsOffset);
                binaryWriter.Write(lOD1TextureDataOffset);
                binaryWriter.Write(lOD2TextureDataOffset);
                binaryWriter.Write(lOD3TextureDataOffset);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(lOD1TextureDataLength);
                binaryWriter.Write(lOD2TextureDataLength);
                binaryWriter.Write(lOD3TextureDataLength);
                binaryWriter.Write(invalidName_0, 0, 52);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum MoreFlags : byte
        {
            DeleteFromCacheFile = 1,
            BitmapCreateAttempted = 2,
            InvalidName = 4,
        };
        internal enum TypeDeterminesBitmapGeometry : short
        {
            Texture2D = 0,
            Texture3D = 1,
            Cubemap = 2,
        };
        internal enum FormatDeterminesHowPixelsAreRepresentedInternally : short
        {
            A8 = 0,
            Y8 = 1,
            Ay8 = 2,
            A8y8 = 3,
            Unused1 = 4,
            Unused2 = 5,
            R5g6b5 = 6,
            Unused3 = 7,
            A1r5g5b5 = 8,
            A4r4g4b4 = 9,
            X8r8g8b8 = 10,
            A8r8g8b8 = 11,
            Unused4 = 12,
            Unused5 = 13,
            Dxt1 = 14,
            Dxt3 = 15,
            Dxt5 = 16,
            P8Bump = 17,
            P8 = 18,
            Argbfp32 = 19,
            Rgbfp32 = 20,
            Rgbfp16 = 21,
            V8u8 = 22,
            G8b8 = 23,
        };
        [FlagsAttribute]
        internal enum Flags : short
        {
            PowerOfTwoDimensions = 1,
            Compressed = 2,
            Palettized = 4,
            Swizzled = 8,
            Linear = 16,
            V16u16 = 32,
            MIPMapDebugLevel = 64,
            PreferStutterPreferLowDetail = 128,
        };
    };
}
