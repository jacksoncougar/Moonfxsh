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
    
    public partial class CharacterPhysicsFlyingStructBlock : GuerillaBlock, IWriteQueueable
    {
        public float BankAngle;
        public float BankApplyTime;
        public float BankDecayTime;
        public float PitchRatio;
        public float MaxVelocity;
        public float MaxSidestepVelocity;
        public float Acceleration;
        public float Deceleration;
        public float AngularVelocityMaximum;
        public float AngularAccelerationMaximum;
        public float CrouchVelocityModifier;
        public override int SerializedSize
        {
            get
            {
                return 44;
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
            this.BankAngle = binaryReader.ReadSingle();
            this.BankApplyTime = binaryReader.ReadSingle();
            this.BankDecayTime = binaryReader.ReadSingle();
            this.PitchRatio = binaryReader.ReadSingle();
            this.MaxVelocity = binaryReader.ReadSingle();
            this.MaxSidestepVelocity = binaryReader.ReadSingle();
            this.Acceleration = binaryReader.ReadSingle();
            this.Deceleration = binaryReader.ReadSingle();
            this.AngularVelocityMaximum = binaryReader.ReadSingle();
            this.AngularAccelerationMaximum = binaryReader.ReadSingle();
            this.CrouchVelocityModifier = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.BankAngle);
            queueableBlamBinaryWriter.Write(this.BankApplyTime);
            queueableBlamBinaryWriter.Write(this.BankDecayTime);
            queueableBlamBinaryWriter.Write(this.PitchRatio);
            queueableBlamBinaryWriter.Write(this.MaxVelocity);
            queueableBlamBinaryWriter.Write(this.MaxSidestepVelocity);
            queueableBlamBinaryWriter.Write(this.Acceleration);
            queueableBlamBinaryWriter.Write(this.Deceleration);
            queueableBlamBinaryWriter.Write(this.AngularVelocityMaximum);
            queueableBlamBinaryWriter.Write(this.AngularAccelerationMaximum);
            queueableBlamBinaryWriter.Write(this.CrouchVelocityModifier);
        }
    }
}
