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
    
    public partial class PlayerControlBlock : GuerillaBlock, IWriteQueueable
    {
        public float MagnetismFriction;
        public float MagnetismAdhesion;
        public float InconsequentialTargetScale;
        private byte[] fieldpad = new byte[12];
        public OpenTK.Vector2 CrosshairLocation;
        public float SecondsToStart;
        public float SecondsToFullSpeed;
        public float DecayRate;
        public float FullSpeedMultiplier;
        public float PeggedMagnitude;
        public float PeggedAngularThreshold;
        private byte[] fieldpad0 = new byte[8];
        public float LookDefaultPitchRate;
        public float LookDefaultYawRate;
        public float LookPegThreshold01;
        public float LookYawAccelerationTime;
        public float LookYawAccelerationScale;
        public float LookPitchAccelerationTime;
        public float LookPitchAccelerationScale;
        public float LookAutolevellingScale;
        private byte[] fieldpad1 = new byte[8];
        public float GravityScale;
        private byte[] fieldpad2 = new byte[2];
        public short MinimumAutolevellingTicks;
        public float MinimumAngleForVehicleFlipping;
        public LookFunctionBlock[] LookFunction = new LookFunctionBlock[0];
        public float MinimumActionHoldTime;
        public override int SerializedSize
        {
            get
            {
                return 128;
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
            this.MagnetismFriction = binaryReader.ReadSingle();
            this.MagnetismAdhesion = binaryReader.ReadSingle();
            this.InconsequentialTargetScale = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(12);
            this.CrosshairLocation = binaryReader.ReadVector2();
            this.SecondsToStart = binaryReader.ReadSingle();
            this.SecondsToFullSpeed = binaryReader.ReadSingle();
            this.DecayRate = binaryReader.ReadSingle();
            this.FullSpeedMultiplier = binaryReader.ReadSingle();
            this.PeggedMagnitude = binaryReader.ReadSingle();
            this.PeggedAngularThreshold = binaryReader.ReadSingle();
            this.fieldpad0 = binaryReader.ReadBytes(8);
            this.LookDefaultPitchRate = binaryReader.ReadSingle();
            this.LookDefaultYawRate = binaryReader.ReadSingle();
            this.LookPegThreshold01 = binaryReader.ReadSingle();
            this.LookYawAccelerationTime = binaryReader.ReadSingle();
            this.LookYawAccelerationScale = binaryReader.ReadSingle();
            this.LookPitchAccelerationTime = binaryReader.ReadSingle();
            this.LookPitchAccelerationScale = binaryReader.ReadSingle();
            this.LookAutolevellingScale = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(8);
            this.GravityScale = binaryReader.ReadSingle();
            this.fieldpad2 = binaryReader.ReadBytes(2);
            this.MinimumAutolevellingTicks = binaryReader.ReadInt16();
            this.MinimumAngleForVehicleFlipping = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            this.MinimumActionHoldTime = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.LookFunction = base.ReadBlockArrayData<LookFunctionBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.LookFunction);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.MagnetismFriction);
            queueableBinaryWriter.Write(this.MagnetismAdhesion);
            queueableBinaryWriter.Write(this.InconsequentialTargetScale);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.CrosshairLocation);
            queueableBinaryWriter.Write(this.SecondsToStart);
            queueableBinaryWriter.Write(this.SecondsToFullSpeed);
            queueableBinaryWriter.Write(this.DecayRate);
            queueableBinaryWriter.Write(this.FullSpeedMultiplier);
            queueableBinaryWriter.Write(this.PeggedMagnitude);
            queueableBinaryWriter.Write(this.PeggedAngularThreshold);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.LookDefaultPitchRate);
            queueableBinaryWriter.Write(this.LookDefaultYawRate);
            queueableBinaryWriter.Write(this.LookPegThreshold01);
            queueableBinaryWriter.Write(this.LookYawAccelerationTime);
            queueableBinaryWriter.Write(this.LookYawAccelerationScale);
            queueableBinaryWriter.Write(this.LookPitchAccelerationTime);
            queueableBinaryWriter.Write(this.LookPitchAccelerationScale);
            queueableBinaryWriter.Write(this.LookAutolevellingScale);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.GravityScale);
            queueableBinaryWriter.Write(this.fieldpad2);
            queueableBinaryWriter.Write(this.MinimumAutolevellingTicks);
            queueableBinaryWriter.Write(this.MinimumAngleForVehicleFlipping);
            queueableBinaryWriter.WritePointer(this.LookFunction);
            queueableBinaryWriter.Write(this.MinimumActionHoldTime);
        }
    }
}
