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
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [TagClassAttribute("coll")]
    [TagBlockOriginalNameAttribute("collision_model_block")]
    public partial class CollisionModelBlock : GuerillaBlock, IWriteQueueable
    {
        public GlobalTagImportInfoBlock[] ImportInfo = new GlobalTagImportInfoBlock[0];
        public GlobalErrorReportCategoriesBlock[] Errors = new GlobalErrorReportCategoriesBlock[0];
        public Flags CollisionModelFlags;
        public CollisionModelMaterialBlock[] Materials = new CollisionModelMaterialBlock[0];
        public CollisionModelRegionBlock[] Regions = new CollisionModelRegionBlock[0];
        public CollisionModelPathfindingSphereBlock[] PathfindingSpheres = new CollisionModelPathfindingSphereBlock[0];
        public CollisionModelNodeBlock[] Nodes = new CollisionModelNodeBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 52;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(592));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(676));
            this.CollisionModelFlags = ((Flags)(binaryReader.ReadInt32()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ImportInfo = base.ReadBlockArrayData<GlobalTagImportInfoBlock>(binaryReader, pointerQueue.Dequeue());
            this.Errors = base.ReadBlockArrayData<GlobalErrorReportCategoriesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Materials = base.ReadBlockArrayData<CollisionModelMaterialBlock>(binaryReader, pointerQueue.Dequeue());
            this.Regions = base.ReadBlockArrayData<CollisionModelRegionBlock>(binaryReader, pointerQueue.Dequeue());
            this.PathfindingSpheres = base.ReadBlockArrayData<CollisionModelPathfindingSphereBlock>(binaryReader, pointerQueue.Dequeue());
            this.Nodes = base.ReadBlockArrayData<CollisionModelNodeBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.ImportInfo);
            queueableBlamBinaryWriter.QueueWrite(this.Errors);
            queueableBlamBinaryWriter.QueueWrite(this.Materials);
            queueableBlamBinaryWriter.QueueWrite(this.Regions);
            queueableBlamBinaryWriter.QueueWrite(this.PathfindingSpheres);
            queueableBlamBinaryWriter.QueueWrite(this.Nodes);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.WritePointer(this.ImportInfo);
            queueableBlamBinaryWriter.WritePointer(this.Errors);
            queueableBlamBinaryWriter.Write(((int)(this.CollisionModelFlags)));
            queueableBlamBinaryWriter.WritePointer(this.Materials);
            queueableBlamBinaryWriter.WritePointer(this.Regions);
            queueableBlamBinaryWriter.WritePointer(this.PathfindingSpheres);
            queueableBlamBinaryWriter.WritePointer(this.Nodes);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            ContainsOpenEdges = 1,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Coll = ((TagClass)("coll"));
    }
}
