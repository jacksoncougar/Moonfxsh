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
    
    [TagClassAttribute("phys")]
    public partial class PhysicsBlock : GuerillaBlock, IWriteQueueable
    {
        public float Radius;
        public float MomentScale;
        public float Mass;
        public OpenTK.Vector3 CenterOfMass;
        public float Density;
        public float GravityScale;
        public float GroundFriction;
        public float GroundDepth;
        public float GroundDampFraction;
        public float GroundNormalK1;
        public float GroundNormalK0;
        private byte[] fieldpad = new byte[4];
        public float WaterFriction;
        public float WaterDepth;
        public float WaterDensity;
        private byte[] fieldpad0 = new byte[4];
        public float AirFriction;
        private byte[] fieldpad1 = new byte[4];
        public float XxMoment;
        public float YyMoment;
        public float ZzMoment;
        public InertialMatrixBlock[] InertialMatrixAndInverse = new InertialMatrixBlock[0];
        public PoweredMassPointBlock[] PoweredMassPoints = new PoweredMassPointBlock[0];
        public MassPointBlock[] MassPoints = new MassPointBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 116;
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
            this.Radius = binaryReader.ReadSingle();
            this.MomentScale = binaryReader.ReadSingle();
            this.Mass = binaryReader.ReadSingle();
            this.CenterOfMass = binaryReader.ReadVector3();
            this.Density = binaryReader.ReadSingle();
            this.GravityScale = binaryReader.ReadSingle();
            this.GroundFriction = binaryReader.ReadSingle();
            this.GroundDepth = binaryReader.ReadSingle();
            this.GroundDampFraction = binaryReader.ReadSingle();
            this.GroundNormalK1 = binaryReader.ReadSingle();
            this.GroundNormalK0 = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.WaterFriction = binaryReader.ReadSingle();
            this.WaterDepth = binaryReader.ReadSingle();
            this.WaterDensity = binaryReader.ReadSingle();
            this.fieldpad0 = binaryReader.ReadBytes(4);
            this.AirFriction = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(4);
            this.XxMoment = binaryReader.ReadSingle();
            this.YyMoment = binaryReader.ReadSingle();
            this.ZzMoment = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(128));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(128));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.InertialMatrixAndInverse = base.ReadBlockArrayData<InertialMatrixBlock>(binaryReader, pointerQueue.Dequeue());
            this.PoweredMassPoints = base.ReadBlockArrayData<PoweredMassPointBlock>(binaryReader, pointerQueue.Dequeue());
            this.MassPoints = base.ReadBlockArrayData<MassPointBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.InertialMatrixAndInverse);
            queueableBinaryWriter.QueueWrite(this.PoweredMassPoints);
            queueableBinaryWriter.QueueWrite(this.MassPoints);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Radius);
            queueableBinaryWriter.Write(this.MomentScale);
            queueableBinaryWriter.Write(this.Mass);
            queueableBinaryWriter.Write(this.CenterOfMass);
            queueableBinaryWriter.Write(this.Density);
            queueableBinaryWriter.Write(this.GravityScale);
            queueableBinaryWriter.Write(this.GroundFriction);
            queueableBinaryWriter.Write(this.GroundDepth);
            queueableBinaryWriter.Write(this.GroundDampFraction);
            queueableBinaryWriter.Write(this.GroundNormalK1);
            queueableBinaryWriter.Write(this.GroundNormalK0);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.WaterFriction);
            queueableBinaryWriter.Write(this.WaterDepth);
            queueableBinaryWriter.Write(this.WaterDensity);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.AirFriction);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.XxMoment);
            queueableBinaryWriter.Write(this.YyMoment);
            queueableBinaryWriter.Write(this.ZzMoment);
            queueableBinaryWriter.WritePointer(this.InertialMatrixAndInverse);
            queueableBinaryWriter.WritePointer(this.PoweredMassPoints);
            queueableBinaryWriter.WritePointer(this.MassPoints);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Phys = ((TagClass)("phys"));
    }
}
