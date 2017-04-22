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
    [TagBlockOriginalNameAttribute("structure_bsp_cluster_portal_block")]
    public partial class StructureBspClusterPortalBlock : GuerillaBlock, IWriteQueueable
    {
        public short BackCluster;
        public short FrontCluster;
        public int PlaneIndex;
        public OpenTK.Vector3 Centroid;
        public float BoundingRadius;
        public Flags StructureBspClusterPortalFlags;
        public StructureBspClusterPortalVertexBlock[] Vertices = new StructureBspClusterPortalVertexBlock[0];
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.BackCluster = binaryReader.ReadInt16();
            this.FrontCluster = binaryReader.ReadInt16();
            this.PlaneIndex = binaryReader.ReadInt32();
            this.Centroid = binaryReader.ReadVector3();
            this.BoundingRadius = binaryReader.ReadSingle();
            this.StructureBspClusterPortalFlags = ((Flags)(binaryReader.ReadInt32()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Vertices = base.ReadBlockArrayData<StructureBspClusterPortalVertexBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Vertices);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.BackCluster);
            queueableBinaryWriter.Write(this.FrontCluster);
            queueableBinaryWriter.Write(this.PlaneIndex);
            queueableBinaryWriter.Write(this.Centroid);
            queueableBinaryWriter.Write(this.BoundingRadius);
            queueableBinaryWriter.Write(((int)(this.StructureBspClusterPortalFlags)));
            queueableBinaryWriter.WritePointer(this.Vertices);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            AICannotHearThroughThis = 1,
            OneWay = 2,
            Door = 4,
            NoWay = 8,
            OneWayReversed = 16,
            NoOneCanHearThroughThis = 32,
        }
    }
}
