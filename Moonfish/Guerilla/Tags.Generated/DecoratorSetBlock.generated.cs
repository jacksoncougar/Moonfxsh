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
    
    [TagClassAttribute("DECR")]
    public partial class DecoratorSetBlock : GuerillaBlock, IWriteQueueable
    {
        public DecoratorShaderReferenceBlock[] Shaders = new DecoratorShaderReferenceBlock[0];
        public float LightingMinScale;
        public float LightingMaxScale;
        public DecoratorClassesBlock[] Classes = new DecoratorClassesBlock[0];
        public DecoratorModelsBlock[] Models = new DecoratorModelsBlock[0];
        public DecoratorModelVerticesBlock[] RawVertices = new DecoratorModelVerticesBlock[0];
        public DecoratorModelIndicesBlock[] Indices = new DecoratorModelIndicesBlock[0];
        public CachedDataBlock[] CachedData = new CachedDataBlock[0];
        public GlobalGeometryBlockInfoStructBlock GeometrySectionInfo = new GlobalGeometryBlockInfoStructBlock();
        private byte[] fieldpad = new byte[16];
        public override int SerializedSize
        {
            get
            {
                return 108;
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
            this.LightingMinScale = binaryReader.ReadSingle();
            this.LightingMaxScale = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(2));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(32));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GeometrySectionInfo.ReadFields(binaryReader)));
            this.fieldpad = binaryReader.ReadBytes(16);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Shaders = base.ReadBlockArrayData<DecoratorShaderReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.Classes = base.ReadBlockArrayData<DecoratorClassesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Models = base.ReadBlockArrayData<DecoratorModelsBlock>(binaryReader, pointerQueue.Dequeue());
            this.RawVertices = base.ReadBlockArrayData<DecoratorModelVerticesBlock>(binaryReader, pointerQueue.Dequeue());
            this.Indices = base.ReadBlockArrayData<DecoratorModelIndicesBlock>(binaryReader, pointerQueue.Dequeue());
            this.CachedData = base.ReadBlockArrayData<CachedDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.GeometrySectionInfo.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Shaders);
            queueableBlamBinaryWriter.QueueWrite(this.Classes);
            queueableBlamBinaryWriter.QueueWrite(this.Models);
            queueableBlamBinaryWriter.QueueWrite(this.RawVertices);
            queueableBlamBinaryWriter.QueueWrite(this.Indices);
            queueableBlamBinaryWriter.QueueWrite(this.CachedData);
            this.GeometrySectionInfo.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.WritePointer(this.Shaders);
            queueableBlamBinaryWriter.Write(this.LightingMinScale);
            queueableBlamBinaryWriter.Write(this.LightingMaxScale);
            queueableBlamBinaryWriter.WritePointer(this.Classes);
            queueableBlamBinaryWriter.WritePointer(this.Models);
            queueableBlamBinaryWriter.WritePointer(this.RawVertices);
            queueableBlamBinaryWriter.WritePointer(this.Indices);
            queueableBlamBinaryWriter.WritePointer(this.CachedData);
            this.GeometrySectionInfo.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.fieldpad);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass DECR = ((TagClass)("DECR"));
    }
}
