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
    
    public partial class StructureInstancedGeometryRenderInfoStructBlock : GuerillaBlock, IWriteQueueable
    {
        public GlobalGeometrySectionInfoStructBlock SectionInfo = new GlobalGeometrySectionInfoStructBlock();
        public GlobalGeometryBlockInfoStructBlock GeometryBlockInfo = new GlobalGeometryBlockInfoStructBlock();
        public StructureBspClusterDataBlockNew[] RenderData = new StructureBspClusterDataBlockNew[0];
        public GlobalGeometrySectionStripIndexBlock[] IndexReorderTable = new GlobalGeometrySectionStripIndexBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 92;
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
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.SectionInfo.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GeometryBlockInfo.ReadFields(binaryReader)));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(68));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.SectionInfo.ReadInstances(binaryReader, pointerQueue);
            this.GeometryBlockInfo.ReadInstances(binaryReader, pointerQueue);
            this.RenderData = base.ReadBlockArrayData<StructureBspClusterDataBlockNew>(binaryReader, pointerQueue.Dequeue());
            this.IndexReorderTable = base.ReadBlockArrayData<GlobalGeometrySectionStripIndexBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.SectionInfo.QueueWrites(queueableBinaryWriter);
            this.GeometryBlockInfo.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.RenderData);
            queueableBinaryWriter.QueueWrite(this.IndexReorderTable);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            this.SectionInfo.Write_(queueableBinaryWriter);
            this.GeometryBlockInfo.Write_(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.RenderData);
            queueableBinaryWriter.WritePointer(this.IndexReorderTable);
        }
    }
}
