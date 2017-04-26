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
    [TagBlockOriginalNameAttribute("collision_model_permutation_block")]
    public partial class CollisionModelPermutationBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.StringIdent Name;
        public CollisionModelBspBlock[] Bsps = new CollisionModelBspBlock[0];
        public CollisionBspPhysicsBlock[] BspPhysics = new CollisionBspPhysicsBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 20;
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
            this.Name = binaryReader.ReadStringIdent();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(68));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(112));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Bsps = base.ReadBlockArrayData<CollisionModelBspBlock>(binaryReader, pointerQueue.Dequeue());
            this.BspPhysics = base.ReadBlockArrayData<CollisionBspPhysicsBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.Bsps);
            queueableBinaryWriter.Defer(this.BspPhysics);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.WritePointer(this.Bsps);
            queueableBinaryWriter.WritePointer(this.BspPhysics);
        }
    }
}
