// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BitmapDataBlock : BitmapDataBlockBase
    {
        public  BitmapDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  BitmapDataBlock(): base()
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
        
        public override int SerializedSize{get { return 116; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  BitmapDataBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
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
        }
        public  BitmapDataBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
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
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
