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
    
    public partial class WeaponHudStaticBlock : GuerillaBlock, IWriteQueueable
    {
        public StateAttachedToEnum StateAttachedTo;
        private byte[] fieldpad = new byte[2];
        public CanUseOnMapTypeEnum CanUseOnMapType;
        private byte[] fieldpad0 = new byte[2];
        private byte[] fieldpad1 = new byte[28];
        public Moonfish.Tags.Point AnchorOffset;
        public float WidthScale;
        public float HeightScale;
        public ScalingFlags WeaponHudStaticScalingFlags;
        private byte[] fieldpad2 = new byte[2];
        private byte[] fieldpad3 = new byte[20];
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference InterfaceBitmap;
        public Moonfish.Tags.ColourA1R1G1B1 DefaultColor;
        public Moonfish.Tags.ColourA1R1G1B1 FlashingColor;
        public float FlashPeriod;
        public float FlashDelay;
        public short NumberOfFlashes;
        public FlashFlags WeaponHudStaticFlashFlags;
        public float FlashLength;
        public Moonfish.Tags.ColourA1R1G1B1 DisabledColor;
        private byte[] fieldpad4 = new byte[4];
        public short SequenceIndex;
        private byte[] fieldpad5 = new byte[2];
        public GlobalHudMultitextureOverlayDefinition[] MultitexOverlay = new GlobalHudMultitextureOverlayDefinition[0];
        private byte[] fieldpad6 = new byte[4];
        private byte[] fieldpad7 = new byte[40];
        public override int SerializedSize
        {
            get
            {
                return 168;
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
            this.StateAttachedTo = ((StateAttachedToEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.CanUseOnMapType = ((CanUseOnMapTypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.fieldpad1 = binaryReader.ReadBytes(28);
            this.AnchorOffset = binaryReader.ReadPoint();
            this.WidthScale = binaryReader.ReadSingle();
            this.HeightScale = binaryReader.ReadSingle();
            this.WeaponHudStaticScalingFlags = ((ScalingFlags)(binaryReader.ReadInt16()));
            this.fieldpad2 = binaryReader.ReadBytes(2);
            this.fieldpad3 = binaryReader.ReadBytes(20);
            this.InterfaceBitmap = binaryReader.ReadTagReference();
            this.DefaultColor = binaryReader.ReadColourA1R1G1B1();
            this.FlashingColor = binaryReader.ReadColourA1R1G1B1();
            this.FlashPeriod = binaryReader.ReadSingle();
            this.FlashDelay = binaryReader.ReadSingle();
            this.NumberOfFlashes = binaryReader.ReadInt16();
            this.WeaponHudStaticFlashFlags = ((FlashFlags)(binaryReader.ReadInt16()));
            this.FlashLength = binaryReader.ReadSingle();
            this.DisabledColor = binaryReader.ReadColourA1R1G1B1();
            this.fieldpad4 = binaryReader.ReadBytes(4);
            this.SequenceIndex = binaryReader.ReadInt16();
            this.fieldpad5 = binaryReader.ReadBytes(2);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(452));
            this.fieldpad6 = binaryReader.ReadBytes(4);
            this.fieldpad7 = binaryReader.ReadBytes(40);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.MultitexOverlay = base.ReadBlockArrayData<GlobalHudMultitextureOverlayDefinition>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.MultitexOverlay);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((short)(this.StateAttachedTo)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(((short)(this.CanUseOnMapType)));
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(this.AnchorOffset);
            queueableBlamBinaryWriter.Write(this.WidthScale);
            queueableBlamBinaryWriter.Write(this.HeightScale);
            queueableBlamBinaryWriter.Write(((short)(this.WeaponHudStaticScalingFlags)));
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.fieldpad3);
            queueableBlamBinaryWriter.Write(this.InterfaceBitmap);
            queueableBlamBinaryWriter.Write(this.DefaultColor);
            queueableBlamBinaryWriter.Write(this.FlashingColor);
            queueableBlamBinaryWriter.Write(this.FlashPeriod);
            queueableBlamBinaryWriter.Write(this.FlashDelay);
            queueableBlamBinaryWriter.Write(this.NumberOfFlashes);
            queueableBlamBinaryWriter.Write(((short)(this.WeaponHudStaticFlashFlags)));
            queueableBlamBinaryWriter.Write(this.FlashLength);
            queueableBlamBinaryWriter.Write(this.DisabledColor);
            queueableBlamBinaryWriter.Write(this.fieldpad4);
            queueableBlamBinaryWriter.Write(this.SequenceIndex);
            queueableBlamBinaryWriter.Write(this.fieldpad5);
            queueableBlamBinaryWriter.WritePointer(this.MultitexOverlay);
            queueableBlamBinaryWriter.Write(this.fieldpad6);
            queueableBlamBinaryWriter.Write(this.fieldpad7);
        }
        public enum StateAttachedToEnum : short
        {
            InventoryAmmo = 0,
            LoadedAmmo = 1,
            Heat = 2,
            Age = 3,
            SecondaryWeaponInventoryAmmo = 4,
            SecondaryWeaponLoadedAmmo = 5,
            DistanceToTarget = 6,
            ElevationToTarget = 7,
        }
        public enum CanUseOnMapTypeEnum : short
        {
            Any = 0,
            Solo = 1,
            Multiplayer = 2,
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
    }
}
