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
    
    public partial class GlobalGeometryBlockInfoStructBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public int BlockOffset;
        public int BlockSize;
        public int SectionDataSize;
        public int ResourceDataSize;
        public GlobalGeometryBlockResourceBlock[] Resources = new GlobalGeometryBlockResourceBlock[0];
        private byte[] fieldpad = new byte[4];
        public short OwnerTagSectionOffset;
        private byte[] fieldpad0 = new byte[2];
        private byte[] fieldpad1 = new byte[4];
        public override int SerializedSize
        {
            get
            {
                return 36;
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
            this.BlockOffset = binaryReader.ReadInt32();
            this.BlockSize = binaryReader.ReadInt32();
            this.SectionDataSize = binaryReader.ReadInt32();
            this.ResourceDataSize = binaryReader.ReadInt32();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            this.fieldpad = binaryReader.ReadBytes(4);
            this.OwnerTagSectionOffset = binaryReader.ReadInt16();
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.fieldpad1 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Resources = base.ReadBlockArrayData<GlobalGeometryBlockResourceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Resources);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.BlockOffset);
            queueableBinaryWriter.Write(this.BlockSize);
            queueableBinaryWriter.Write(this.SectionDataSize);
            queueableBinaryWriter.Write(this.ResourceDataSize);
            queueableBinaryWriter.WritePointer(this.Resources);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.OwnerTagSectionOffset);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.fieldpad1);
        }
    }
}
