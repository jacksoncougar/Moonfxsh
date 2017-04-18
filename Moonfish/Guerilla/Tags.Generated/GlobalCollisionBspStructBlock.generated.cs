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
    
    [TagBlockOriginalNameAttribute("global_collision_bsp_struct_block")]
    public partial class GlobalCollisionBspStructBlock : GuerillaBlock, IWriteQueueable
    {
        public Bsp3dNodesBlock[] BSP3DNodes = new Bsp3dNodesBlock[0];
        public PlanesBlock[] Planes = new PlanesBlock[0];
        public LeavesBlock[] Leaves = new LeavesBlock[0];
        public Bsp2dReferencesBlock[] BSP2DReferences = new Bsp2dReferencesBlock[0];
        public Bsp2dNodesBlock[] BSP2DNodes = new Bsp2dNodesBlock[0];
        public SurfacesBlock[] Surfaces = new SurfacesBlock[0];
        public EdgesBlock[] Edges = new EdgesBlock[0];
        public VerticesBlock[] Vertices = new VerticesBlock[0];
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.BSP3DNodes = base.ReadBlockArrayData<Bsp3dNodesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Planes = base.ReadBlockArrayData<PlanesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Leaves = base.ReadBlockArrayData<LeavesBlock>(binaryReader, pointerQueue.Dequeue());
            this.BSP2DReferences = base.ReadBlockArrayData<Bsp2dReferencesBlock>(binaryReader, pointerQueue.Dequeue());
            this.BSP2DNodes = base.ReadBlockArrayData<Bsp2dNodesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Surfaces = base.ReadBlockArrayData<SurfacesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Edges = base.ReadBlockArrayData<EdgesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Vertices = base.ReadBlockArrayData<VerticesBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.BSP3DNodes);
            queueableBlamBinaryWriter.QueueWrite(this.Planes);
            queueableBlamBinaryWriter.QueueWrite(this.Leaves);
            queueableBlamBinaryWriter.QueueWrite(this.BSP2DReferences);
            queueableBlamBinaryWriter.QueueWrite(this.BSP2DNodes);
            queueableBlamBinaryWriter.QueueWrite(this.Surfaces);
            queueableBlamBinaryWriter.QueueWrite(this.Edges);
            queueableBlamBinaryWriter.QueueWrite(this.Vertices);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.WritePointer(this.BSP3DNodes);
            queueableBlamBinaryWriter.WritePointer(this.Planes);
            queueableBlamBinaryWriter.WritePointer(this.Leaves);
            queueableBlamBinaryWriter.WritePointer(this.BSP2DReferences);
            queueableBlamBinaryWriter.WritePointer(this.BSP2DNodes);
            queueableBlamBinaryWriter.WritePointer(this.Surfaces);
            queueableBlamBinaryWriter.WritePointer(this.Edges);
            queueableBlamBinaryWriter.WritePointer(this.Vertices);
        }
    }
}
