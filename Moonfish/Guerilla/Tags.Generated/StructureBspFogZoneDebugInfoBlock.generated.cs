//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("structure_bsp_fog_zone_debug_info_block")]
    public partial class StructureBspFogZoneDebugInfoBlock : GuerillaBlock, IWriteQueueable
    {
        public int MediaIndex;
        public int BaseFogPlaneIndex;
        private byte[] fieldpad = new byte[24];
        public StructureBspDebugInfoRenderLineBlock[] Lines = new StructureBspDebugInfoRenderLineBlock[0];
        public StructureBspDebugInfoIndicesBlock[] ImmersedClusterIndices = new StructureBspDebugInfoIndicesBlock[0];
        public StructureBspDebugInfoIndicesBlock[] BoundingFogPlaneIndices = new StructureBspDebugInfoIndicesBlock[0];
        public StructureBspDebugInfoIndicesBlock[] CollisionFogPlaneIndices = new StructureBspDebugInfoIndicesBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 64;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.MediaIndex = binaryReader.ReadInt32();
            this.BaseFogPlaneIndex = binaryReader.ReadInt32();
            this.fieldpad = binaryReader.ReadBytes(24);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Lines = base.ReadBlockArrayData<StructureBspDebugInfoRenderLineBlock>(binaryReader, pointerQueue.Dequeue());
            this.ImmersedClusterIndices = base.ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, pointerQueue.Dequeue());
            this.BoundingFogPlaneIndices = base.ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, pointerQueue.Dequeue());
            this.CollisionFogPlaneIndices = base.ReadBlockArrayData<StructureBspDebugInfoIndicesBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Lines);
            queueableBinaryWriter.QueueWrite(this.ImmersedClusterIndices);
            queueableBinaryWriter.QueueWrite(this.BoundingFogPlaneIndices);
            queueableBinaryWriter.QueueWrite(this.CollisionFogPlaneIndices);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.MediaIndex);
            queueableBinaryWriter.Write(this.BaseFogPlaneIndex);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.Lines);
            queueableBinaryWriter.WritePointer(this.ImmersedClusterIndices);
            queueableBinaryWriter.WritePointer(this.BoundingFogPlaneIndices);
            queueableBinaryWriter.WritePointer(this.CollisionFogPlaneIndices);
        }
    }
}
