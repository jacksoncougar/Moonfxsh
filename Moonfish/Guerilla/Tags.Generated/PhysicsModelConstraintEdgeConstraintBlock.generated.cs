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
    [TagBlockOriginalNameAttribute("physics_model_constraint_edge_constraint_block")]
    public partial class PhysicsModelConstraintEdgeConstraintBlock : GuerillaBlock, IWriteQueueable
    {
        public TypeEnum Type;
        public Moonfish.Tags.ShortBlockIndex2 Index;
        public Flags PhysicsModelConstraintEdgeConstraintFlags;
        public float Friction;
        public override int SerializedSize
        {
            get
            {
                return 12;
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
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.Index = binaryReader.ReadShortBlockIndex2();
            this.PhysicsModelConstraintEdgeConstraintFlags = ((Flags)(binaryReader.ReadInt32()));
            this.Friction = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.Type)));
            queueableBinaryWriter.Write(this.Index);
            queueableBinaryWriter.Write(((int)(this.PhysicsModelConstraintEdgeConstraintFlags)));
            queueableBinaryWriter.Write(this.Friction);
        }
        public enum TypeEnum : short
        {
            Hinge = 0,
            LimitedHinge = 1,
            Ragdoll = 2,
            StiffSpring = 3,
            BallAndSocket = 4,
            Prismatic = 5,
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            IsRigidthisConstraintMakesTheEdgeRigidUntilItIsLoosenedByDamage = 1,
            DisableEffectsthisConstraintWillNotGenerateImpactEffects = 2,
        }
    }
}
