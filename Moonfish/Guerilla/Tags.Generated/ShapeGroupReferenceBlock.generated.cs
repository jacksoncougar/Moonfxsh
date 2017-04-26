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
    [TagBlockOriginalNameAttribute("shape_group_reference_block")]
    public partial class ShapeGroupReferenceBlock : GuerillaBlock, IWriteDeferrable
    {
        public ShapeBlockReferenceBlock[] Shapes = new ShapeBlockReferenceBlock[0];
        public UiModelSceneReferenceBlock[] ModelSceneBlocks = new UiModelSceneReferenceBlock[0];
        public BitmapBlockReferenceBlock[] BitmapBlocks = new BitmapBlockReferenceBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 24;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(48));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(76));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Shapes = base.ReadBlockArrayData<ShapeBlockReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.ModelSceneBlocks = base.ReadBlockArrayData<UiModelSceneReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.BitmapBlocks = base.ReadBlockArrayData<BitmapBlockReferenceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.Shapes);
            queueableBinaryWriter.Defer(this.ModelSceneBlocks);
            queueableBinaryWriter.Defer(this.BitmapBlocks);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.Shapes);
            queueableBinaryWriter.WritePointer(this.ModelSceneBlocks);
            queueableBinaryWriter.WritePointer(this.BitmapBlocks);
        }
    }
}
