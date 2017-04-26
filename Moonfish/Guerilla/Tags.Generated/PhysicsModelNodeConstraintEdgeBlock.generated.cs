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
    [TagBlockOriginalNameAttribute("physics_model_node_constraint_edge_block")]
    public partial class PhysicsModelNodeConstraintEdgeBlock : GuerillaBlock, IWriteDeferrable
    {
        private byte[] fieldpad = new byte[4];
        public Moonfish.Tags.ShortBlockIndex1 NodeA;
        public Moonfish.Tags.ShortBlockIndex1 NodeB;
        public PhysicsModelConstraintEdgeConstraintBlock[] Constraints = new PhysicsModelConstraintEdgeConstraintBlock[0];
        public Moonfish.Tags.StringIdent NodeAMaterial;
        public Moonfish.Tags.StringIdent NodeBMaterial;
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
            this.fieldpad = binaryReader.ReadBytes(4);
            this.NodeA = binaryReader.ReadShortBlockIndex1();
            this.NodeB = binaryReader.ReadShortBlockIndex1();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            this.NodeAMaterial = binaryReader.ReadStringIdent();
            this.NodeBMaterial = binaryReader.ReadStringIdent();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Constraints = base.ReadBlockArrayData<PhysicsModelConstraintEdgeConstraintBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.Constraints);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.NodeA);
            queueableBinaryWriter.Write(this.NodeB);
            queueableBinaryWriter.WritePointer(this.Constraints);
            queueableBinaryWriter.Write(this.NodeAMaterial);
            queueableBinaryWriter.Write(this.NodeBMaterial);
        }
    }
}
