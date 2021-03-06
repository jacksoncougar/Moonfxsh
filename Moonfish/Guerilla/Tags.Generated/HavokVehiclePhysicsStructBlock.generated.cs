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
    
    public partial class HavokVehiclePhysicsStructBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags HavokVehiclePhysicsStructFlags;
        public float GroundFriction;
        public float GroundDepth;
        public float GroundDampFactor;
        public float GroundMovingFriction;
        public float GroundMaximumSlope0;
        public float GroundMaximumSlope1;
        private byte[] fieldpad = new byte[16];
        public float AntiGravityBankLift;
        public float SteeringBankReactionScale;
        public float GravityScale;
        public float Radius;
        public AntiGravityPointDefinitionBlock[] AntiGravityPoints = new AntiGravityPointDefinitionBlock[0];
        public FrictionPointDefinitionBlock[] FrictionPoints = new FrictionPointDefinitionBlock[0];
        public VehiclePhantomShapeBlock[] shapePhantomShape = new VehiclePhantomShapeBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 84;
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
            this.HavokVehiclePhysicsStructFlags = ((Flags)(binaryReader.ReadInt32()));
            this.GroundFriction = binaryReader.ReadSingle();
            this.GroundDepth = binaryReader.ReadSingle();
            this.GroundDampFactor = binaryReader.ReadSingle();
            this.GroundMovingFriction = binaryReader.ReadSingle();
            this.GroundMaximumSlope0 = binaryReader.ReadSingle();
            this.GroundMaximumSlope1 = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(16);
            this.AntiGravityBankLift = binaryReader.ReadSingle();
            this.SteeringBankReactionScale = binaryReader.ReadSingle();
            this.GravityScale = binaryReader.ReadSingle();
            this.Radius = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(76));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(76));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(672));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.AntiGravityPoints = base.ReadBlockArrayData<AntiGravityPointDefinitionBlock>(binaryReader, pointerQueue.Dequeue());
            this.FrictionPoints = base.ReadBlockArrayData<FrictionPointDefinitionBlock>(binaryReader, pointerQueue.Dequeue());
            this.shapePhantomShape = base.ReadBlockArrayData<VehiclePhantomShapeBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.AntiGravityPoints);
            queueableBinaryWriter.QueueWrite(this.FrictionPoints);
            queueableBinaryWriter.QueueWrite(this.shapePhantomShape);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.HavokVehiclePhysicsStructFlags)));
            queueableBinaryWriter.Write(this.GroundFriction);
            queueableBinaryWriter.Write(this.GroundDepth);
            queueableBinaryWriter.Write(this.GroundDampFactor);
            queueableBinaryWriter.Write(this.GroundMovingFriction);
            queueableBinaryWriter.Write(this.GroundMaximumSlope0);
            queueableBinaryWriter.Write(this.GroundMaximumSlope1);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.AntiGravityBankLift);
            queueableBinaryWriter.Write(this.SteeringBankReactionScale);
            queueableBinaryWriter.Write(this.GravityScale);
            queueableBinaryWriter.Write(this.Radius);
            queueableBinaryWriter.WritePointer(this.AntiGravityPoints);
            queueableBinaryWriter.WritePointer(this.FrictionPoints);
            queueableBinaryWriter.WritePointer(this.shapePhantomShape);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Invalid = 1,
        }
    }
}
