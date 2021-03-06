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
    
    public partial class WeaponHudCrosshairItemBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.Point AnchorOffset;
        public float WidthScale;
        public float HeightScale;
        public ScalingFlags WeaponHudCrosshairItemScalingFlags;
        private byte[] fieldpad = new byte[2];
        private byte[] fieldpad0 = new byte[20];
        public Moonfish.Tags.ColourA1R1G1B1 DefaultColor;
        public Moonfish.Tags.ColourA1R1G1B1 FlashingColor;
        public float FlashPeriod;
        public float FlashDelay;
        public short NumberOfFlashes;
        public FlashFlags WeaponHudCrosshairItemFlashFlags;
        public float FlashLength;
        public Moonfish.Tags.ColourA1R1G1B1 DisabledColor;
        private byte[] fieldpad1 = new byte[4];
        public short FrameRate;
        public short SequenceIndex;
        public Flags WeaponHudCrosshairItemFlags;
        private byte[] fieldpad2 = new byte[32];
        public override int SerializedSize
        {
            get
            {
                return 108;
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
            this.AnchorOffset = binaryReader.ReadPoint();
            this.WidthScale = binaryReader.ReadSingle();
            this.HeightScale = binaryReader.ReadSingle();
            this.WeaponHudCrosshairItemScalingFlags = ((ScalingFlags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.fieldpad0 = binaryReader.ReadBytes(20);
            this.DefaultColor = binaryReader.ReadColourA1R1G1B1();
            this.FlashingColor = binaryReader.ReadColourA1R1G1B1();
            this.FlashPeriod = binaryReader.ReadSingle();
            this.FlashDelay = binaryReader.ReadSingle();
            this.NumberOfFlashes = binaryReader.ReadInt16();
            this.WeaponHudCrosshairItemFlashFlags = ((FlashFlags)(binaryReader.ReadInt16()));
            this.FlashLength = binaryReader.ReadSingle();
            this.DisabledColor = binaryReader.ReadColourA1R1G1B1();
            this.fieldpad1 = binaryReader.ReadBytes(4);
            this.FrameRate = binaryReader.ReadInt16();
            this.SequenceIndex = binaryReader.ReadInt16();
            this.WeaponHudCrosshairItemFlags = ((Flags)(binaryReader.ReadInt32()));
            this.fieldpad2 = binaryReader.ReadBytes(32);
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
            queueableBinaryWriter.Write(this.AnchorOffset);
            queueableBinaryWriter.Write(this.WidthScale);
            queueableBinaryWriter.Write(this.HeightScale);
            queueableBinaryWriter.Write(((short)(this.WeaponHudCrosshairItemScalingFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.DefaultColor);
            queueableBinaryWriter.Write(this.FlashingColor);
            queueableBinaryWriter.Write(this.FlashPeriod);
            queueableBinaryWriter.Write(this.FlashDelay);
            queueableBinaryWriter.Write(this.NumberOfFlashes);
            queueableBinaryWriter.Write(((short)(this.WeaponHudCrosshairItemFlashFlags)));
            queueableBinaryWriter.Write(this.FlashLength);
            queueableBinaryWriter.Write(this.DisabledColor);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.FrameRate);
            queueableBinaryWriter.Write(this.SequenceIndex);
            queueableBinaryWriter.Write(((int)(this.WeaponHudCrosshairItemFlags)));
            queueableBinaryWriter.Write(this.fieldpad2);
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
        public enum Flags : int
        {
            None = 0,
            FlashesWhenActive = 1,
            NotASprite = 2,
            ShowOnlyWhenZoomed = 4,
            ShowSniperData = 8,
            HideAreaOutsideReticle = 16,
            OneZoomLevel = 32,
            DontShowWhenZoomed = 64,
        }
    }
}
