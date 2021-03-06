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
    
    public partial class GlobalGeometryBlockResourceBlock : GuerillaBlock, IWriteQueueable
    {
        public TypeEnum Type;
        private byte[] fieldpad = new byte[3];
        public short PrimaryLocator;
        public short SecondaryLocator;
        public int ResourceDataSize;
        public int ResourceDataOffset;
        public override int SerializedSize
        {
            get
            {
                return 16;
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
            this.Type = ((TypeEnum)(binaryReader.ReadByte()));
            this.fieldpad = binaryReader.ReadBytes(3);
            this.PrimaryLocator = binaryReader.ReadInt16();
            this.SecondaryLocator = binaryReader.ReadInt16();
            this.ResourceDataSize = binaryReader.ReadInt32();
            this.ResourceDataOffset = binaryReader.ReadInt32();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((byte)(this.Type)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.PrimaryLocator);
            queueableBinaryWriter.Write(this.SecondaryLocator);
            queueableBinaryWriter.Write(this.ResourceDataSize);
            queueableBinaryWriter.Write(this.ResourceDataOffset);
        }
        public enum TypeEnum : byte
        {
            TagBlock = 0,
            TagData = 1,
            VertexBuffer = 2,
        }
    }
}
