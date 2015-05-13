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
    
    public partial class FrictionPointDefinitionBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent MarkerName;
        public Flags FrictionPointDefinitionFlags;
        public float FractionOfTotalMass;
        public float Radius;
        public float DamagedRadius;
        public FrictionTypeEnum FrictionType;
        private byte[] fieldpad = new byte[2];
        public float MovingFrictionVelocityDiff;
        public float EbrakeMovingFriction;
        public float EbrakeFriction;
        public float EbrakeMovingFrictionVelDiff;
        private byte[] fieldpad0 = new byte[20];
        public Moonfish.Tags.StringIdent CollisionGlobalMaterialName;
        private byte[] fieldpad1 = new byte[2];
        public ModelStateDestroyedEnum ModelStateDestroyed;
        public Moonfish.Tags.StringIdent RegionName;
        private byte[] fieldpad2 = new byte[4];
        public override int SerializedSize
        {
            get
            {
                return 76;
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
            this.MarkerName = binaryReader.ReadStringID();
            this.FrictionPointDefinitionFlags = ((Flags)(binaryReader.ReadInt32()));
            this.FractionOfTotalMass = binaryReader.ReadSingle();
            this.Radius = binaryReader.ReadSingle();
            this.DamagedRadius = binaryReader.ReadSingle();
            this.FrictionType = ((FrictionTypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.MovingFrictionVelocityDiff = binaryReader.ReadSingle();
            this.EbrakeMovingFriction = binaryReader.ReadSingle();
            this.EbrakeFriction = binaryReader.ReadSingle();
            this.EbrakeMovingFrictionVelDiff = binaryReader.ReadSingle();
            this.fieldpad0 = binaryReader.ReadBytes(20);
            this.CollisionGlobalMaterialName = binaryReader.ReadStringID();
            this.fieldpad1 = binaryReader.ReadBytes(2);
            this.ModelStateDestroyed = ((ModelStateDestroyedEnum)(binaryReader.ReadInt16()));
            this.RegionName = binaryReader.ReadStringID();
            this.fieldpad2 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.MarkerName);
            queueableBinaryWriter.Write(((int)(this.FrictionPointDefinitionFlags)));
            queueableBinaryWriter.Write(this.FractionOfTotalMass);
            queueableBinaryWriter.Write(this.Radius);
            queueableBinaryWriter.Write(this.DamagedRadius);
            queueableBinaryWriter.Write(((short)(this.FrictionType)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.MovingFrictionVelocityDiff);
            queueableBinaryWriter.Write(this.EbrakeMovingFriction);
            queueableBinaryWriter.Write(this.EbrakeFriction);
            queueableBinaryWriter.Write(this.EbrakeMovingFrictionVelDiff);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.CollisionGlobalMaterialName);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(((short)(this.ModelStateDestroyed)));
            queueableBinaryWriter.Write(this.RegionName);
            queueableBinaryWriter.Write(this.fieldpad2);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            GetsDamageFromRegion = 1,
            Powered = 2,
            FrontTurning = 4,
            RearTurning = 8,
            AttachedToEbrake = 16,
            CanBeDestroyed = 32,
        }
        public enum FrictionTypeEnum : short
        {
            Point = 0,
            Forward = 1,
        }
        public enum ModelStateDestroyedEnum : short
        {
            Default = 0,
            MinorDamage = 1,
            MediumDamage = 2,
            MajorDamage = 3,
            Destroyed = 4,
        }
    }
}
