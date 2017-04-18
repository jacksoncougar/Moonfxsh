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
    
    public partial class MultiplayerConstantsBlock : GuerillaBlock, IWriteQueueable
    {
        public float MaximumRandomSpawnBias;
        public float TeleporterRechargeTime;
        public float GrenadeDangerWeight;
        public float GrenadeDangerInnerRadius;
        public float GrenadeDangerOuterRadius;
        public float GrenadeDangerLeadTime;
        public float VehicleDangerMinSpeed;
        public float VehicleDangerWeight;
        public float VehicleDangerRadius;
        public float VehicleDangerLeadTime;
        public float VehicleNearbyPlayerDist;
        private byte[] fieldpad = new byte[84];
        private byte[] fieldpad0 = new byte[32];
        private byte[] fieldpad1 = new byte[32];
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference HillShader;
        private byte[] fieldpad2 = new byte[16];
        public float FlagResetStopDistance;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference BombExplodeEffect;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference BombExplodeDmgEffect;
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference BombDefuseEffect;
        public Moonfish.Tags.StringIdent BombDefusalString;
        public Moonfish.Tags.StringIdent BlockedTeleporterString;
        private byte[] fieldpad3 = new byte[4];
        private byte[] fieldpad4 = new byte[32];
        private byte[] fieldpad5 = new byte[32];
        private byte[] fieldpad6 = new byte[32];
        public override int SerializedSize
        {
            get
            {
                return 352;
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
            this.MaximumRandomSpawnBias = binaryReader.ReadSingle();
            this.TeleporterRechargeTime = binaryReader.ReadSingle();
            this.GrenadeDangerWeight = binaryReader.ReadSingle();
            this.GrenadeDangerInnerRadius = binaryReader.ReadSingle();
            this.GrenadeDangerOuterRadius = binaryReader.ReadSingle();
            this.GrenadeDangerLeadTime = binaryReader.ReadSingle();
            this.VehicleDangerMinSpeed = binaryReader.ReadSingle();
            this.VehicleDangerWeight = binaryReader.ReadSingle();
            this.VehicleDangerRadius = binaryReader.ReadSingle();
            this.VehicleDangerLeadTime = binaryReader.ReadSingle();
            this.VehicleNearbyPlayerDist = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(84);
            this.fieldpad0 = binaryReader.ReadBytes(32);
            this.fieldpad1 = binaryReader.ReadBytes(32);
            this.HillShader = binaryReader.ReadTagReference();
            this.fieldpad2 = binaryReader.ReadBytes(16);
            this.FlagResetStopDistance = binaryReader.ReadSingle();
            this.BombExplodeEffect = binaryReader.ReadTagReference();
            this.BombExplodeDmgEffect = binaryReader.ReadTagReference();
            this.BombDefuseEffect = binaryReader.ReadTagReference();
            this.BombDefusalString = binaryReader.ReadStringIdent();
            this.BlockedTeleporterString = binaryReader.ReadStringIdent();
            this.fieldpad3 = binaryReader.ReadBytes(4);
            this.fieldpad4 = binaryReader.ReadBytes(32);
            this.fieldpad5 = binaryReader.ReadBytes(32);
            this.fieldpad6 = binaryReader.ReadBytes(32);
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
            queueableBlamBinaryWriter.Write(this.MaximumRandomSpawnBias);
            queueableBlamBinaryWriter.Write(this.TeleporterRechargeTime);
            queueableBlamBinaryWriter.Write(this.GrenadeDangerWeight);
            queueableBlamBinaryWriter.Write(this.GrenadeDangerInnerRadius);
            queueableBlamBinaryWriter.Write(this.GrenadeDangerOuterRadius);
            queueableBlamBinaryWriter.Write(this.GrenadeDangerLeadTime);
            queueableBlamBinaryWriter.Write(this.VehicleDangerMinSpeed);
            queueableBlamBinaryWriter.Write(this.VehicleDangerWeight);
            queueableBlamBinaryWriter.Write(this.VehicleDangerRadius);
            queueableBlamBinaryWriter.Write(this.VehicleDangerLeadTime);
            queueableBlamBinaryWriter.Write(this.VehicleNearbyPlayerDist);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(this.HillShader);
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.FlagResetStopDistance);
            queueableBlamBinaryWriter.Write(this.BombExplodeEffect);
            queueableBlamBinaryWriter.Write(this.BombExplodeDmgEffect);
            queueableBlamBinaryWriter.Write(this.BombDefuseEffect);
            queueableBlamBinaryWriter.Write(this.BombDefusalString);
            queueableBlamBinaryWriter.Write(this.BlockedTeleporterString);
            queueableBlamBinaryWriter.Write(this.fieldpad3);
            queueableBlamBinaryWriter.Write(this.fieldpad4);
            queueableBlamBinaryWriter.Write(this.fieldpad5);
            queueableBlamBinaryWriter.Write(this.fieldpad6);
        }
    }
}
