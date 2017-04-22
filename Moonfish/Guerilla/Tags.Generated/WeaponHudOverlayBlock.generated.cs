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
    [TagBlockOriginalNameAttribute("weapon_hud_overlay_block")]
    public partial class WeaponHudOverlayBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.Point AnchorOffset;
        public float WidthScale;
        public float HeightScale;
        public ScalingFlags WeaponHudOverlayScalingFlags;
        private byte[] fieldpad = new byte[2];
        private byte[] fieldpad0 = new byte[20];
        public Moonfish.Tags.ColourA1R1G1B1 DefaultColor;
        public Moonfish.Tags.ColourA1R1G1B1 FlashingColor;
        public float FlashPeriod;
        public float FlashDelay;
        public short NumberOfFlashes;
        public FlashFlags WeaponHudOverlayFlashFlags;
        public float FlashLength;
        public Moonfish.Tags.ColourA1R1G1B1 DisabledColor;
        private byte[] fieldpad1 = new byte[4];
        public short FrameRate;
        private byte[] fieldpad2 = new byte[2];
        public short SequenceIndex;
        public Type WeaponHudOverlayType;
        public Flags WeaponHudOverlayFlags;
        private byte[] fieldpad3 = new byte[16];
        private byte[] fieldpad4 = new byte[40];
        public override int SerializedSize
        {
            get
            {
                return 136;
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
            this.AnchorOffset = binaryReader.ReadPoint();
            this.WidthScale = binaryReader.ReadSingle();
            this.HeightScale = binaryReader.ReadSingle();
            this.WeaponHudOverlayScalingFlags = ((ScalingFlags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.fieldpad0 = binaryReader.ReadBytes(20);
            this.DefaultColor = binaryReader.ReadColourA1R1G1B1();
            this.FlashingColor = binaryReader.ReadColourA1R1G1B1();
            this.FlashPeriod = binaryReader.ReadSingle();
            this.FlashDelay = binaryReader.ReadSingle();
            this.NumberOfFlashes = binaryReader.ReadInt16();
            this.WeaponHudOverlayFlashFlags = ((FlashFlags)(binaryReader.ReadInt16()));
            this.FlashLength = binaryReader.ReadSingle();
            this.DisabledColor = binaryReader.ReadColourA1R1G1B1();
            this.fieldpad1 = binaryReader.ReadBytes(4);
            this.FrameRate = binaryReader.ReadInt16();
            this.fieldpad2 = binaryReader.ReadBytes(2);
            this.SequenceIndex = binaryReader.ReadInt16();
            this.WeaponHudOverlayType = ((Type)(binaryReader.ReadInt16()));
            this.WeaponHudOverlayFlags = ((Flags)(binaryReader.ReadInt32()));
            this.fieldpad3 = binaryReader.ReadBytes(16);
            this.fieldpad4 = binaryReader.ReadBytes(40);
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
            queueableBinaryWriter.Write(this.AnchorOffset);
            queueableBinaryWriter.Write(this.WidthScale);
            queueableBinaryWriter.Write(this.HeightScale);
            queueableBinaryWriter.Write(((short)(this.WeaponHudOverlayScalingFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.DefaultColor);
            queueableBinaryWriter.Write(this.FlashingColor);
            queueableBinaryWriter.Write(this.FlashPeriod);
            queueableBinaryWriter.Write(this.FlashDelay);
            queueableBinaryWriter.Write(this.NumberOfFlashes);
            queueableBinaryWriter.Write(((short)(this.WeaponHudOverlayFlashFlags)));
            queueableBinaryWriter.Write(this.FlashLength);
            queueableBinaryWriter.Write(this.DisabledColor);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.FrameRate);
            queueableBinaryWriter.Write(this.fieldpad2);
            queueableBinaryWriter.Write(this.SequenceIndex);
            queueableBinaryWriter.Write(((short)(this.WeaponHudOverlayType)));
            queueableBinaryWriter.Write(((int)(this.WeaponHudOverlayFlags)));
            queueableBinaryWriter.Write(this.fieldpad3);
            queueableBinaryWriter.Write(this.fieldpad4);
        }
        [System.FlagsAttribute()]
        public enum ScalingFlags : short
        {
            None = 0,
            DontScaleOffset = 1,
            DontScaleSize = 2,
        }
        [System.FlagsAttribute()]
        public enum FlashFlags : short
        {
            None = 0,
            ReverseDefaultflashingColors = 1,
        }
        [System.FlagsAttribute()]
        public enum Type : short
        {
            None = 0,
            ShowOnFlashing = 1,
            ShowOnEmpty = 2,
            ShowOnReloadoverheating = 4,
            ShowOnDefault = 8,
            ShowAlways = 16,
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            FlashesWhenActive = 1,
        }
    }
}
