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
    
    public partial class GlobalWindModelStructBlock : GuerillaBlock, IWriteQueueable
    {
        public float WindTilingScale;
        public OpenTK.Vector3 WindPrimaryHeadingpitchstrength;
        public float PrimaryRateOfChange;
        public float PrimaryMinStrength;
        private byte[] fieldpad = new byte[4];
        private byte[] fieldpad0 = new byte[4];
        private byte[] fieldpad1 = new byte[12];
        public OpenTK.Vector3 WindGustingHeadingpitchstrength;
        public float GustDiretionalRateOfChange;
        public float GustStrengthRateOfChange;
        public float GustConeAngle;
        private byte[] fieldpad2 = new byte[4];
        private byte[] fieldpad3 = new byte[4];
        private byte[] fieldpad4 = new byte[12];
        private byte[] fieldpad5 = new byte[12];
        private byte[] fieldpad6 = new byte[12];
        private byte[] fieldpad7 = new byte[12];
        public float TurbulanceRateOfChange;
        public OpenTK.Vector3 TurbulenceScaleXYZ;
        public float GravityConstant;
        public GloalWindPrimitivesBlock[] WindPirmitives = new GloalWindPrimitivesBlock[0];
        private byte[] fieldpad8 = new byte[4];
        public override int SerializedSize
        {
            get
            {
                return 156;
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
            this.WindTilingScale = binaryReader.ReadSingle();
            this.WindPrimaryHeadingpitchstrength = binaryReader.ReadVector3();
            this.PrimaryRateOfChange = binaryReader.ReadSingle();
            this.PrimaryMinStrength = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.fieldpad0 = binaryReader.ReadBytes(4);
            this.fieldpad1 = binaryReader.ReadBytes(12);
            this.WindGustingHeadingpitchstrength = binaryReader.ReadVector3();
            this.GustDiretionalRateOfChange = binaryReader.ReadSingle();
            this.GustStrengthRateOfChange = binaryReader.ReadSingle();
            this.GustConeAngle = binaryReader.ReadSingle();
            this.fieldpad2 = binaryReader.ReadBytes(4);
            this.fieldpad3 = binaryReader.ReadBytes(4);
            this.fieldpad4 = binaryReader.ReadBytes(12);
            this.fieldpad5 = binaryReader.ReadBytes(12);
            this.fieldpad6 = binaryReader.ReadBytes(12);
            this.fieldpad7 = binaryReader.ReadBytes(12);
            this.TurbulanceRateOfChange = binaryReader.ReadSingle();
            this.TurbulenceScaleXYZ = binaryReader.ReadVector3();
            this.GravityConstant = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            this.fieldpad8 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.WindPirmitives = base.ReadBlockArrayData<GloalWindPrimitivesBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.WindPirmitives);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.WindTilingScale);
            queueableBlamBinaryWriter.Write(this.WindPrimaryHeadingpitchstrength);
            queueableBlamBinaryWriter.Write(this.PrimaryRateOfChange);
            queueableBlamBinaryWriter.Write(this.PrimaryMinStrength);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(this.WindGustingHeadingpitchstrength);
            queueableBlamBinaryWriter.Write(this.GustDiretionalRateOfChange);
            queueableBlamBinaryWriter.Write(this.GustStrengthRateOfChange);
            queueableBlamBinaryWriter.Write(this.GustConeAngle);
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.fieldpad3);
            queueableBlamBinaryWriter.Write(this.fieldpad4);
            queueableBlamBinaryWriter.Write(this.fieldpad5);
            queueableBlamBinaryWriter.Write(this.fieldpad6);
            queueableBlamBinaryWriter.Write(this.fieldpad7);
            queueableBlamBinaryWriter.Write(this.TurbulanceRateOfChange);
            queueableBlamBinaryWriter.Write(this.TurbulenceScaleXYZ);
            queueableBlamBinaryWriter.Write(this.GravityConstant);
            queueableBlamBinaryWriter.WritePointer(this.WindPirmitives);
            queueableBlamBinaryWriter.Write(this.fieldpad8);
        }
    }
}
