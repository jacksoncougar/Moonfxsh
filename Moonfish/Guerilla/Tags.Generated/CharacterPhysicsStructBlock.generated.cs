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
    [TagBlockOriginalNameAttribute("character_physics_struct_block")]
    public partial class CharacterPhysicsStructBlock : GuerillaBlock, IWriteDeferrable
    {
        public Flags CharacterPhysicsStructFlags;
        public float HeightStanding;
        public float HeightCrouching;
        public float Radius;
        public float Mass;
        public Moonfish.Tags.StringIdent LivingMaterialName;
        public Moonfish.Tags.StringIdent DeadMaterialName;
        private byte[] fieldpad = new byte[4];
        public SpheresBlock[] DeadSphereShapes = new SpheresBlock[0];
        public PillsBlock[] PillShapes = new PillsBlock[0];
        public SpheresBlock[] SphereShapes = new SpheresBlock[0];
        public CharacterPhysicsGroundStructBlock GroundPhysics = new CharacterPhysicsGroundStructBlock();
        public CharacterPhysicsFlyingStructBlock FlyingPhysics = new CharacterPhysicsFlyingStructBlock();
        public CharacterPhysicsDeadStructBlock DeadPhysics = new CharacterPhysicsDeadStructBlock();
        public CharacterPhysicsSentinelStructBlock SentinelPhysics = new CharacterPhysicsSentinelStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 148;
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
            this.CharacterPhysicsStructFlags = ((Flags)(binaryReader.ReadInt32()));
            this.HeightStanding = binaryReader.ReadSingle();
            this.HeightCrouching = binaryReader.ReadSingle();
            this.Radius = binaryReader.ReadSingle();
            this.Mass = binaryReader.ReadSingle();
            this.LivingMaterialName = binaryReader.ReadStringIdent();
            this.DeadMaterialName = binaryReader.ReadStringIdent();
            this.fieldpad = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(128));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(80));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(128));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.GroundPhysics.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.FlyingPhysics.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.DeadPhysics.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.SentinelPhysics.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.DeadSphereShapes = base.ReadBlockArrayData<SpheresBlock>(binaryReader, pointerQueue.Dequeue());
            this.PillShapes = base.ReadBlockArrayData<PillsBlock>(binaryReader, pointerQueue.Dequeue());
            this.SphereShapes = base.ReadBlockArrayData<SpheresBlock>(binaryReader, pointerQueue.Dequeue());
            this.GroundPhysics.ReadInstances(binaryReader, pointerQueue);
            this.FlyingPhysics.ReadInstances(binaryReader, pointerQueue);
            this.DeadPhysics.ReadInstances(binaryReader, pointerQueue);
            this.SentinelPhysics.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.DeadSphereShapes);
            queueableBinaryWriter.Defer(this.PillShapes);
            queueableBinaryWriter.Defer(this.SphereShapes);
            this.GroundPhysics.DeferReferences(queueableBinaryWriter);
            this.FlyingPhysics.DeferReferences(queueableBinaryWriter);
            this.DeadPhysics.DeferReferences(queueableBinaryWriter);
            this.SentinelPhysics.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.CharacterPhysicsStructFlags)));
            queueableBinaryWriter.Write(this.HeightStanding);
            queueableBinaryWriter.Write(this.HeightCrouching);
            queueableBinaryWriter.Write(this.Radius);
            queueableBinaryWriter.Write(this.Mass);
            queueableBinaryWriter.Write(this.LivingMaterialName);
            queueableBinaryWriter.Write(this.DeadMaterialName);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.DeadSphereShapes);
            queueableBinaryWriter.WritePointer(this.PillShapes);
            queueableBinaryWriter.WritePointer(this.SphereShapes);
            this.GroundPhysics.Write(queueableBinaryWriter);
            this.FlyingPhysics.Write(queueableBinaryWriter);
            this.DeadPhysics.Write(queueableBinaryWriter);
            this.SentinelPhysics.Write(queueableBinaryWriter);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            CenteredAtOrigin = 1,
            ShapeSpherical = 2,
            UsePlayerPhysics = 4,
            ClimbAnySurface = 8,
            Flying = 16,
            NotPhysical = 32,
            DeadCharacterCollisionGroup = 64,
        }
    }
}
