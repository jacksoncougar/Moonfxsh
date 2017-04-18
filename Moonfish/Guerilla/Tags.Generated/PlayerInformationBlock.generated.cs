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
    
    public partial class PlayerInformationBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("unit")]
        public Moonfish.Tags.TagReference Unused;
        private byte[] fieldpad = new byte[28];
        public float WalkingSpeed;
        private byte[] fieldpad0 = new byte[4];
        public float RunForward;
        public float RunBackward;
        public float RunSideways;
        public float RunAcceleration;
        public float SneakForward;
        public float SneakBackward;
        public float SneakSideways;
        public float SneakAcceleration;
        public float AirborneAcceleration;
        private byte[] fieldpad1 = new byte[16];
        public OpenTK.Vector3 GrenadeOrigin;
        private byte[] fieldpad2 = new byte[12];
        public float StunMovementPenalty;
        public float StunTurningPenalty;
        public float StunJumpingPenalty;
        public float MinimumStunTime;
        public float MaximumStunTime;
        private byte[] fieldpad3 = new byte[8];
        public Moonfish.Model.Range FirstPersonIdleTime;
        public float FirstPersonSkipFraction;
        private byte[] fieldpad4 = new byte[16];
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference CoopRespawnEffect;
        public int BinocularsZoomCount;
        public Moonfish.Model.Range BinocularsZoomRange;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference BinocularsZoomInSound;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference BinocularsZoomOutSound;
        private byte[] fieldpad5 = new byte[16];
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference ActiveCamouflageOn;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference ActiveCamouflageOff;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference ActiveCamouflageError;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference ActiveCamouflageReady;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference FlashlightOn;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference FlashlightOff;
        [Moonfish.Tags.TagReferenceAttribute("snd!")]
        public Moonfish.Tags.TagReference IceCream;
        public override int SerializedSize
        {
            get
            {
                return 284;
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
            this.Unused = binaryReader.ReadTagReference();
            this.fieldpad = binaryReader.ReadBytes(28);
            this.WalkingSpeed = binaryReader.ReadSingle();
            this.fieldpad0 = binaryReader.ReadBytes(4);
            this.RunForward = binaryReader.ReadSingle();
            this.RunBackward = binaryReader.ReadSingle();
            this.RunSideways = binaryReader.ReadSingle();
            this.RunAcceleration = binaryReader.ReadSingle();
            this.SneakForward = binaryReader.ReadSingle();
            this.SneakBackward = binaryReader.ReadSingle();
            this.SneakSideways = binaryReader.ReadSingle();
            this.SneakAcceleration = binaryReader.ReadSingle();
            this.AirborneAcceleration = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(16);
            this.GrenadeOrigin = binaryReader.ReadVector3();
            this.fieldpad2 = binaryReader.ReadBytes(12);
            this.StunMovementPenalty = binaryReader.ReadSingle();
            this.StunTurningPenalty = binaryReader.ReadSingle();
            this.StunJumpingPenalty = binaryReader.ReadSingle();
            this.MinimumStunTime = binaryReader.ReadSingle();
            this.MaximumStunTime = binaryReader.ReadSingle();
            this.fieldpad3 = binaryReader.ReadBytes(8);
            this.FirstPersonIdleTime = binaryReader.ReadRange();
            this.FirstPersonSkipFraction = binaryReader.ReadSingle();
            this.fieldpad4 = binaryReader.ReadBytes(16);
            this.CoopRespawnEffect = binaryReader.ReadTagReference();
            this.BinocularsZoomCount = binaryReader.ReadInt32();
            this.BinocularsZoomRange = binaryReader.ReadRange();
            this.BinocularsZoomInSound = binaryReader.ReadTagReference();
            this.BinocularsZoomOutSound = binaryReader.ReadTagReference();
            this.fieldpad5 = binaryReader.ReadBytes(16);
            this.ActiveCamouflageOn = binaryReader.ReadTagReference();
            this.ActiveCamouflageOff = binaryReader.ReadTagReference();
            this.ActiveCamouflageError = binaryReader.ReadTagReference();
            this.ActiveCamouflageReady = binaryReader.ReadTagReference();
            this.FlashlightOn = binaryReader.ReadTagReference();
            this.FlashlightOff = binaryReader.ReadTagReference();
            this.IceCream = binaryReader.ReadTagReference();
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
            queueableBlamBinaryWriter.Write(this.Unused);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.WalkingSpeed);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.RunForward);
            queueableBlamBinaryWriter.Write(this.RunBackward);
            queueableBlamBinaryWriter.Write(this.RunSideways);
            queueableBlamBinaryWriter.Write(this.RunAcceleration);
            queueableBlamBinaryWriter.Write(this.SneakForward);
            queueableBlamBinaryWriter.Write(this.SneakBackward);
            queueableBlamBinaryWriter.Write(this.SneakSideways);
            queueableBlamBinaryWriter.Write(this.SneakAcceleration);
            queueableBlamBinaryWriter.Write(this.AirborneAcceleration);
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(this.GrenadeOrigin);
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.StunMovementPenalty);
            queueableBlamBinaryWriter.Write(this.StunTurningPenalty);
            queueableBlamBinaryWriter.Write(this.StunJumpingPenalty);
            queueableBlamBinaryWriter.Write(this.MinimumStunTime);
            queueableBlamBinaryWriter.Write(this.MaximumStunTime);
            queueableBlamBinaryWriter.Write(this.fieldpad3);
            queueableBlamBinaryWriter.Write(this.FirstPersonIdleTime);
            queueableBlamBinaryWriter.Write(this.FirstPersonSkipFraction);
            queueableBlamBinaryWriter.Write(this.fieldpad4);
            queueableBlamBinaryWriter.Write(this.CoopRespawnEffect);
            queueableBlamBinaryWriter.Write(this.BinocularsZoomCount);
            queueableBlamBinaryWriter.Write(this.BinocularsZoomRange);
            queueableBlamBinaryWriter.Write(this.BinocularsZoomInSound);
            queueableBlamBinaryWriter.Write(this.BinocularsZoomOutSound);
            queueableBlamBinaryWriter.Write(this.fieldpad5);
            queueableBlamBinaryWriter.Write(this.ActiveCamouflageOn);
            queueableBlamBinaryWriter.Write(this.ActiveCamouflageOff);
            queueableBlamBinaryWriter.Write(this.ActiveCamouflageError);
            queueableBlamBinaryWriter.Write(this.ActiveCamouflageReady);
            queueableBlamBinaryWriter.Write(this.FlashlightOn);
            queueableBlamBinaryWriter.Write(this.FlashlightOff);
            queueableBlamBinaryWriter.Write(this.IceCream);
        }
    }
}
