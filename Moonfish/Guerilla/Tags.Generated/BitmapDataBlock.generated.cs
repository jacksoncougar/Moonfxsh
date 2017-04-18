//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class BitmapDataBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.TagClass Signature;
        public short Width;
        public short Height;
        public byte Depth;
        public MoreFlags BitmapDataMoreFlags;
        public TypeEnum Type;
        public FormatEnum Format;
        public Flags BitmapDataFlags;
        public Moonfish.Tags.Point RegistrationPoint;
        public short MipmapCount;
        public short LowDetailMipmapCount;
        public int PixelsOffset;
        public int LOD1TextureDataOffset;
        public int LOD2TextureDataOffset;
        public int LOD3TextureDataOffset;
        private byte[] fieldskip = new byte[12];
        public int LOD1TextureDataLength;
        public int LOD2TextureDataLength;
        public int LOD3TextureDataLength;
        private byte[] fieldskip0 = new byte[52];
        public override int SerializedSize
        {
            get
            {
                return 116;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Signature = binaryReader.ReadTagClass();
            this.Width = binaryReader.ReadInt16();
            this.Height = binaryReader.ReadInt16();
            this.Depth = binaryReader.ReadByte();
            this.BitmapDataMoreFlags = ((MoreFlags)(binaryReader.ReadByte()));
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.Format = ((FormatEnum)(binaryReader.ReadInt16()));
            this.BitmapDataFlags = ((Flags)(binaryReader.ReadInt16()));
            this.RegistrationPoint = binaryReader.ReadPoint();
            this.MipmapCount = binaryReader.ReadInt16();
            this.LowDetailMipmapCount = binaryReader.ReadInt16();
            this.PixelsOffset = binaryReader.ReadInt32();
            this.LOD1TextureDataOffset = binaryReader.ReadInt32();
            this.LOD2TextureDataOffset = binaryReader.ReadInt32();
            this.LOD3TextureDataOffset = binaryReader.ReadInt32();
            this.fieldskip = binaryReader.ReadBytes(12);
            this.LOD1TextureDataLength = binaryReader.ReadInt32();
            this.LOD2TextureDataLength = binaryReader.ReadInt32();
            this.LOD3TextureDataLength = binaryReader.ReadInt32();
            this.fieldskip0 = binaryReader.ReadBytes(52);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.Signature);
            queueableBlamBinaryWriter.Write(this.Width);
            queueableBlamBinaryWriter.Write(this.Height);
            queueableBlamBinaryWriter.Write(this.Depth);
            queueableBlamBinaryWriter.Write(((byte)(this.BitmapDataMoreFlags)));
            queueableBlamBinaryWriter.Write(((short)(this.Type)));
            queueableBlamBinaryWriter.Write(((short)(this.Format)));
            queueableBlamBinaryWriter.Write(((short)(this.BitmapDataFlags)));
            queueableBlamBinaryWriter.Write(this.RegistrationPoint);
            queueableBlamBinaryWriter.Write(this.MipmapCount);
            queueableBlamBinaryWriter.Write(this.LowDetailMipmapCount);
            queueableBlamBinaryWriter.Write(this.PixelsOffset);
            queueableBlamBinaryWriter.Write(this.LOD1TextureDataOffset);
            queueableBlamBinaryWriter.Write(this.LOD2TextureDataOffset);
            queueableBlamBinaryWriter.Write(this.LOD3TextureDataOffset);
            queueableBlamBinaryWriter.Write(this.fieldskip);
            queueableBlamBinaryWriter.Write(this.LOD1TextureDataLength);
            queueableBlamBinaryWriter.Write(this.LOD2TextureDataLength);
            queueableBlamBinaryWriter.Write(this.LOD3TextureDataLength);
            queueableBlamBinaryWriter.Write(this.fieldskip0);
        }
        [System.FlagsAttribute()]
        public enum MoreFlags : byte
        {
            None = 0,
            DeleteFromCacheFile = 1,
            BitmapCreateAttempted = 2,
        }
        public enum TypeEnum : short
        {
            Texture2D = 0,
            Texture3D = 1,
            Cubemap = 2,
        }
        public enum FormatEnum : short
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
            P8bump = 17,
            P8 = 18,
            Argbfp32 = 19,
            Rgbfp32 = 20,
            Rgbfp16 = 21,
            V8u8 = 22,
            G8b8 = 23,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            PowerOfTwoDimensions = 1,
            Compressed = 2,
            Palettized = 4,
            Swizzled = 8,
            Linear = 16,
            V16u16 = 32,
            MIPMapDebugLevel = 64,
            PreferStutterPreferLowDetail = 128,
        }
    }
}
