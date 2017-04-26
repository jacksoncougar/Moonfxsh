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
    using Moonfish.Guerilla;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagClassAttribute("wphi")]
    [TagBlockOriginalNameAttribute("weapon_hud_interface_block")]
    public partial class WeaponHudInterfaceBlock : GuerillaBlock, IWriteDeferrable
    {
        [Moonfish.Tags.TagReferenceAttribute("wphi")]
        public Moonfish.Tags.TagReference ChildHud;
        public Flags WeaponHudInterfaceFlags;
        private byte[] fieldpad = new byte[2];
        public short InventoryAmmoCutoff;
        public short LoadedAmmoCutoff;
        public short HeatCutoff;
        public short AgeCutoff;
        private byte[] fieldpad0 = new byte[32];
        public AnchorEnum Anchor;
        private byte[] fieldpad1 = new byte[2];
        private byte[] fieldpad2 = new byte[32];
        public WeaponHudStaticBlock[] StaticElements = new WeaponHudStaticBlock[0];
        public WeaponHudMeterBlock[] MeterElements = new WeaponHudMeterBlock[0];
        public WeaponHudNumberBlock[] NumberElements = new WeaponHudNumberBlock[0];
        public WeaponHudCrosshairBlock[] Crosshairs = new WeaponHudCrosshairBlock[0];
        public WeaponHudOverlaysBlock[] OverlayElements = new WeaponHudOverlaysBlock[0];
        private byte[] fieldpad3 = new byte[4];
        public GNullBlock[] GNullBlock = new GNullBlock[0];
        public GlobalHudScreenEffectDefinition[] ScreenEffect = new GlobalHudScreenEffectDefinition[0];
        private byte[] fieldpad4 = new byte[132];
        public short SequenceIndex;
        public short WidthOffset;
        public Moonfish.Tags.Point OffsetFromReferenceCorner;
        public Moonfish.Tags.ColourA1R1G1B1 OverrideIconColor;
        public byte FrameRate030;
        public WeaponHudInterfaceFlags0 WeaponHudInterfaceWeaponHudInterfaceFlags0;
        public short TextIndex;
        private byte[] fieldpad5 = new byte[48];
        public override int SerializedSize
        {
            get
            {
                return 344;
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
            this.ChildHud = binaryReader.ReadTagReference();
            this.WeaponHudInterfaceFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.InventoryAmmoCutoff = binaryReader.ReadInt16();
            this.LoadedAmmoCutoff = binaryReader.ReadInt16();
            this.HeatCutoff = binaryReader.ReadInt16();
            this.AgeCutoff = binaryReader.ReadInt16();
            this.fieldpad0 = binaryReader.ReadBytes(32);
            this.Anchor = ((AnchorEnum)(binaryReader.ReadInt16()));
            this.fieldpad1 = binaryReader.ReadBytes(2);
            this.fieldpad2 = binaryReader.ReadBytes(32);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(168));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(165));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(160));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(92));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(92));
            this.fieldpad3 = binaryReader.ReadBytes(4);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(0));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(320));
            this.fieldpad4 = binaryReader.ReadBytes(132);
            this.SequenceIndex = binaryReader.ReadInt16();
            this.WidthOffset = binaryReader.ReadInt16();
            this.OffsetFromReferenceCorner = binaryReader.ReadPoint();
            this.OverrideIconColor = binaryReader.ReadColourA1R1G1B1();
            this.FrameRate030 = binaryReader.ReadByte();
            this.WeaponHudInterfaceWeaponHudInterfaceFlags0 = ((WeaponHudInterfaceFlags0)(binaryReader.ReadByte()));
            this.TextIndex = binaryReader.ReadInt16();
            this.fieldpad5 = binaryReader.ReadBytes(48);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.StaticElements = base.ReadBlockArrayData<WeaponHudStaticBlock>(binaryReader, pointerQueue.Dequeue());
            this.MeterElements = base.ReadBlockArrayData<WeaponHudMeterBlock>(binaryReader, pointerQueue.Dequeue());
            this.NumberElements = base.ReadBlockArrayData<WeaponHudNumberBlock>(binaryReader, pointerQueue.Dequeue());
            this.Crosshairs = base.ReadBlockArrayData<WeaponHudCrosshairBlock>(binaryReader, pointerQueue.Dequeue());
            this.OverlayElements = base.ReadBlockArrayData<WeaponHudOverlaysBlock>(binaryReader, pointerQueue.Dequeue());
            this.GNullBlock = base.ReadBlockArrayData<GNullBlock>(binaryReader, pointerQueue.Dequeue());
            this.ScreenEffect = base.ReadBlockArrayData<GlobalHudScreenEffectDefinition>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.DeferReferences(writer);
            writer.Defer(this.StaticElements);
            writer.Defer(this.MeterElements);
            writer.Defer(this.NumberElements);
            writer.Defer(this.Crosshairs);
            writer.Defer(this.OverlayElements);
            writer.Defer(this.GNullBlock);
            writer.Defer(this.ScreenEffect);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(this.ChildHud);
            writer.Write(((short)(this.WeaponHudInterfaceFlags)));
            writer.Write(this.fieldpad);
            writer.Write(this.InventoryAmmoCutoff);
            writer.Write(this.LoadedAmmoCutoff);
            writer.Write(this.HeatCutoff);
            writer.Write(this.AgeCutoff);
            writer.Write(this.fieldpad0);
            writer.Write(((short)(this.Anchor)));
            writer.Write(this.fieldpad1);
            writer.Write(this.fieldpad2);
            writer.WritePointer(this.StaticElements);
            writer.WritePointer(this.MeterElements);
            writer.WritePointer(this.NumberElements);
            writer.WritePointer(this.Crosshairs);
            writer.WritePointer(this.OverlayElements);
            writer.Write(this.fieldpad3);
            writer.WritePointer(this.GNullBlock);
            writer.WritePointer(this.ScreenEffect);
            writer.Write(this.fieldpad4);
            writer.Write(this.SequenceIndex);
            writer.Write(this.WidthOffset);
            writer.Write(this.OffsetFromReferenceCorner);
            writer.Write(this.OverrideIconColor);
            writer.Write(this.FrameRate030);
            writer.Write(((byte)(this.WeaponHudInterfaceWeaponHudInterfaceFlags0)));
            writer.Write(this.TextIndex);
            writer.Write(this.fieldpad5);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            UseParentHudFlashingParameters = 1,
        }
        public enum AnchorEnum : short
        {
            TopLeft = 0,
            TopRight = 1,
            BottomLeft = 2,
            BottomRight = 3,
            Center = 4,
            Crosshair = 5,
        }
        [System.FlagsAttribute()]
        public enum WeaponHudInterfaceFlags0 : byte
        {
            None = 0,
            UseTextFromStringListInstead = 1,
            OverrideDefaultColor = 2,
            WidthOffsetIsAbsoluteIconWidth = 4,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Wphi = ((TagClass)("wphi"));
    }
}
