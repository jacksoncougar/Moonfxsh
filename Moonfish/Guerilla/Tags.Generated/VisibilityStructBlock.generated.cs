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
    
    public partial class VisibilityStructBlock : GuerillaBlock, IWriteQueueable
    {
        public short ProjectionCount;
        public short ClusterCount;
        public short VolumeCount;
        private byte[] fieldpad = new byte[2];
        public byte[] Projections;
        public byte[] VisibilityClusters;
        public byte[] ClusterRemapTable;
        public byte[] VisibilityVolumes;
        public override int SerializedSize
        {
            get
            {
                return 40;
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
            this.ProjectionCount = binaryReader.ReadInt16();
            this.ClusterCount = binaryReader.ReadInt16();
            this.VolumeCount = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Projections = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.VisibilityClusters = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.ClusterRemapTable = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.VisibilityVolumes = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Projections);
            queueableBlamBinaryWriter.QueueWrite(this.VisibilityClusters);
            queueableBlamBinaryWriter.QueueWrite(this.ClusterRemapTable);
            queueableBlamBinaryWriter.QueueWrite(this.VisibilityVolumes);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.ProjectionCount);
            queueableBlamBinaryWriter.Write(this.ClusterCount);
            queueableBlamBinaryWriter.Write(this.VolumeCount);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.WritePointer(this.Projections);
            queueableBlamBinaryWriter.WritePointer(this.VisibilityClusters);
            queueableBlamBinaryWriter.WritePointer(this.ClusterRemapTable);
            queueableBlamBinaryWriter.WritePointer(this.VisibilityVolumes);
        }
    }
}
