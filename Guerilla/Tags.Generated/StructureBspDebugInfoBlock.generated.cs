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
    
    public partial class StructureBspDebugInfoBlock : GuerillaBlock, IWriteQueueable
    {
        private byte[] fieldpad = new byte[64];
        public StructureBspClusterDebugInfoBlock[] Clusters = new StructureBspClusterDebugInfoBlock[0];
        public StructureBspFogPlaneDebugInfoBlock[] FogPlanes = new StructureBspFogPlaneDebugInfoBlock[0];
        public StructureBspFogZoneDebugInfoBlock[] FogZones = new StructureBspFogZoneDebugInfoBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 88;
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
            this.fieldpad = binaryReader.ReadBytes(64);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(72));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(64));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Clusters = base.ReadBlockArrayData<StructureBspClusterDebugInfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.FogPlanes = base.ReadBlockArrayData<StructureBspFogPlaneDebugInfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.FogZones = base.ReadBlockArrayData<StructureBspFogZoneDebugInfoBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Clusters);
            queueableBinaryWriter.QueueWrite(this.FogPlanes);
            queueableBinaryWriter.QueueWrite(this.FogZones);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.Clusters);
            queueableBinaryWriter.WritePointer(this.FogPlanes);
            queueableBinaryWriter.WritePointer(this.FogZones);
        }
    }
}
