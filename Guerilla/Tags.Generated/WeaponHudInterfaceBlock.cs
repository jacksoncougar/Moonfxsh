// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Wphi = (TagClass)"wphi";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wphi")]
    public partial class WeaponHudInterfaceBlock : WeaponHudInterfaceBlockBase
    {
        public WeaponHudInterfaceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 344, Alignment = 4)]
    public class WeaponHudInterfaceBlockBase : GuerillaBlock
    {
        [TagReference("wphi")]
        internal Moonfish.Tags.TagReference childHud;
        internal Flags flags;
        internal byte[] invalidName_;
        internal short inventoryAmmoCutoff;
        internal short loadedAmmoCutoff;
        internal short heatCutoff;
        internal short ageCutoff;
        internal byte[] invalidName_0;
        internal Anchor anchor;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal WeaponHudStaticBlock[] staticElements;
        internal WeaponHudMeterBlock[] meterElements;
        internal WeaponHudNumberBlock[] numberElements;
        internal WeaponHudCrosshairBlock[] crosshairs;
        internal WeaponHudOverlaysBlock[] overlayElements;
        internal byte[] invalidName_3;
        internal GNullBlock[] gNullBlock;
        internal GlobalHudScreenEffectDefinition[] screenEffect;
        internal byte[] invalidName_4;
        /// <summary>
        /// sequenceIndex into the global hud icon bitmap
        /// </summary>
        internal short sequenceIndex;
        /// <summary>
        /// extra spacing beyond bitmap width for text alignment
        /// </summary>
        internal short widthOffset;
        internal Moonfish.Tags.Point offsetFromReferenceCorner;
        internal Moonfish.Tags.ColourA1R1G1B1 overrideIconColor;
        internal byte frameRate030;
        internal Flags flags0;
        internal short textIndex;
        internal byte[] invalidName_5;
        public override int SerializedSize { get { return 344; } }
        public override int Alignment { get { return 4; } }
        public WeaponHudInterfaceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            childHud = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            inventoryAmmoCutoff = binaryReader.ReadInt16();
            loadedAmmoCutoff = binaryReader.ReadInt16();
            heatCutoff = binaryReader.ReadInt16();
            ageCutoff = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(32);
            anchor = (Anchor)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(32);
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponHudStaticBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponHudMeterBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponHudNumberBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponHudCrosshairBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<WeaponHudOverlaysBlock>(binaryReader));
            invalidName_3 = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<GNullBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalHudScreenEffectDefinition>(binaryReader));
            invalidName_4 = binaryReader.ReadBytes(132);
            sequenceIndex = binaryReader.ReadInt16();
            widthOffset = binaryReader.ReadInt16();
            offsetFromReferenceCorner = binaryReader.ReadPoint();
            overrideIconColor = binaryReader.ReadColourA1R1G1B1();
            frameRate030 = binaryReader.ReadByte();
            flags0 = (Flags)binaryReader.ReadInt16();
            textIndex = binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(48);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_0[8].ReadPointers(binaryReader, blamPointers);
            invalidName_0[9].ReadPointers(binaryReader, blamPointers);
            invalidName_0[10].ReadPointers(binaryReader, blamPointers);
            invalidName_0[11].ReadPointers(binaryReader, blamPointers);
            invalidName_0[12].ReadPointers(binaryReader, blamPointers);
            invalidName_0[13].ReadPointers(binaryReader, blamPointers);
            invalidName_0[14].ReadPointers(binaryReader, blamPointers);
            invalidName_0[15].ReadPointers(binaryReader, blamPointers);
            invalidName_0[16].ReadPointers(binaryReader, blamPointers);
            invalidName_0[17].ReadPointers(binaryReader, blamPointers);
            invalidName_0[18].ReadPointers(binaryReader, blamPointers);
            invalidName_0[19].ReadPointers(binaryReader, blamPointers);
            invalidName_0[20].ReadPointers(binaryReader, blamPointers);
            invalidName_0[21].ReadPointers(binaryReader, blamPointers);
            invalidName_0[22].ReadPointers(binaryReader, blamPointers);
            invalidName_0[23].ReadPointers(binaryReader, blamPointers);
            invalidName_0[24].ReadPointers(binaryReader, blamPointers);
            invalidName_0[25].ReadPointers(binaryReader, blamPointers);
            invalidName_0[26].ReadPointers(binaryReader, blamPointers);
            invalidName_0[27].ReadPointers(binaryReader, blamPointers);
            invalidName_0[28].ReadPointers(binaryReader, blamPointers);
            invalidName_0[29].ReadPointers(binaryReader, blamPointers);
            invalidName_0[30].ReadPointers(binaryReader, blamPointers);
            invalidName_0[31].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_2[20].ReadPointers(binaryReader, blamPointers);
            invalidName_2[21].ReadPointers(binaryReader, blamPointers);
            invalidName_2[22].ReadPointers(binaryReader, blamPointers);
            invalidName_2[23].ReadPointers(binaryReader, blamPointers);
            invalidName_2[24].ReadPointers(binaryReader, blamPointers);
            invalidName_2[25].ReadPointers(binaryReader, blamPointers);
            invalidName_2[26].ReadPointers(binaryReader, blamPointers);
            invalidName_2[27].ReadPointers(binaryReader, blamPointers);
            invalidName_2[28].ReadPointers(binaryReader, blamPointers);
            invalidName_2[29].ReadPointers(binaryReader, blamPointers);
            invalidName_2[30].ReadPointers(binaryReader, blamPointers);
            invalidName_2[31].ReadPointers(binaryReader, blamPointers);
            staticElements = ReadBlockArrayData<WeaponHudStaticBlock>(binaryReader, blamPointers.Dequeue());
            meterElements = ReadBlockArrayData<WeaponHudMeterBlock>(binaryReader, blamPointers.Dequeue());
            numberElements = ReadBlockArrayData<WeaponHudNumberBlock>(binaryReader, blamPointers.Dequeue());
            crosshairs = ReadBlockArrayData<WeaponHudCrosshairBlock>(binaryReader, blamPointers.Dequeue());
            overlayElements = ReadBlockArrayData<WeaponHudOverlaysBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            gNullBlock = ReadBlockArrayData<GNullBlock>(binaryReader, blamPointers.Dequeue());
            screenEffect = ReadBlockArrayData<GlobalHudScreenEffectDefinition>(binaryReader, blamPointers.Dequeue());
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            invalidName_4[2].ReadPointers(binaryReader, blamPointers);
            invalidName_4[3].ReadPointers(binaryReader, blamPointers);
            invalidName_4[4].ReadPointers(binaryReader, blamPointers);
            invalidName_4[5].ReadPointers(binaryReader, blamPointers);
            invalidName_4[6].ReadPointers(binaryReader, blamPointers);
            invalidName_4[7].ReadPointers(binaryReader, blamPointers);
            invalidName_4[8].ReadPointers(binaryReader, blamPointers);
            invalidName_4[9].ReadPointers(binaryReader, blamPointers);
            invalidName_4[10].ReadPointers(binaryReader, blamPointers);
            invalidName_4[11].ReadPointers(binaryReader, blamPointers);
            invalidName_4[12].ReadPointers(binaryReader, blamPointers);
            invalidName_4[13].ReadPointers(binaryReader, blamPointers);
            invalidName_4[14].ReadPointers(binaryReader, blamPointers);
            invalidName_4[15].ReadPointers(binaryReader, blamPointers);
            invalidName_4[16].ReadPointers(binaryReader, blamPointers);
            invalidName_4[17].ReadPointers(binaryReader, blamPointers);
            invalidName_4[18].ReadPointers(binaryReader, blamPointers);
            invalidName_4[19].ReadPointers(binaryReader, blamPointers);
            invalidName_4[20].ReadPointers(binaryReader, blamPointers);
            invalidName_4[21].ReadPointers(binaryReader, blamPointers);
            invalidName_4[22].ReadPointers(binaryReader, blamPointers);
            invalidName_4[23].ReadPointers(binaryReader, blamPointers);
            invalidName_4[24].ReadPointers(binaryReader, blamPointers);
            invalidName_4[25].ReadPointers(binaryReader, blamPointers);
            invalidName_4[26].ReadPointers(binaryReader, blamPointers);
            invalidName_4[27].ReadPointers(binaryReader, blamPointers);
            invalidName_4[28].ReadPointers(binaryReader, blamPointers);
            invalidName_4[29].ReadPointers(binaryReader, blamPointers);
            invalidName_4[30].ReadPointers(binaryReader, blamPointers);
            invalidName_4[31].ReadPointers(binaryReader, blamPointers);
            invalidName_4[32].ReadPointers(binaryReader, blamPointers);
            invalidName_4[33].ReadPointers(binaryReader, blamPointers);
            invalidName_4[34].ReadPointers(binaryReader, blamPointers);
            invalidName_4[35].ReadPointers(binaryReader, blamPointers);
            invalidName_4[36].ReadPointers(binaryReader, blamPointers);
            invalidName_4[37].ReadPointers(binaryReader, blamPointers);
            invalidName_4[38].ReadPointers(binaryReader, blamPointers);
            invalidName_4[39].ReadPointers(binaryReader, blamPointers);
            invalidName_4[40].ReadPointers(binaryReader, blamPointers);
            invalidName_4[41].ReadPointers(binaryReader, blamPointers);
            invalidName_4[42].ReadPointers(binaryReader, blamPointers);
            invalidName_4[43].ReadPointers(binaryReader, blamPointers);
            invalidName_4[44].ReadPointers(binaryReader, blamPointers);
            invalidName_4[45].ReadPointers(binaryReader, blamPointers);
            invalidName_4[46].ReadPointers(binaryReader, blamPointers);
            invalidName_4[47].ReadPointers(binaryReader, blamPointers);
            invalidName_4[48].ReadPointers(binaryReader, blamPointers);
            invalidName_4[49].ReadPointers(binaryReader, blamPointers);
            invalidName_4[50].ReadPointers(binaryReader, blamPointers);
            invalidName_4[51].ReadPointers(binaryReader, blamPointers);
            invalidName_4[52].ReadPointers(binaryReader, blamPointers);
            invalidName_4[53].ReadPointers(binaryReader, blamPointers);
            invalidName_4[54].ReadPointers(binaryReader, blamPointers);
            invalidName_4[55].ReadPointers(binaryReader, blamPointers);
            invalidName_4[56].ReadPointers(binaryReader, blamPointers);
            invalidName_4[57].ReadPointers(binaryReader, blamPointers);
            invalidName_4[58].ReadPointers(binaryReader, blamPointers);
            invalidName_4[59].ReadPointers(binaryReader, blamPointers);
            invalidName_4[60].ReadPointers(binaryReader, blamPointers);
            invalidName_4[61].ReadPointers(binaryReader, blamPointers);
            invalidName_4[62].ReadPointers(binaryReader, blamPointers);
            invalidName_4[63].ReadPointers(binaryReader, blamPointers);
            invalidName_4[64].ReadPointers(binaryReader, blamPointers);
            invalidName_4[65].ReadPointers(binaryReader, blamPointers);
            invalidName_4[66].ReadPointers(binaryReader, blamPointers);
            invalidName_4[67].ReadPointers(binaryReader, blamPointers);
            invalidName_4[68].ReadPointers(binaryReader, blamPointers);
            invalidName_4[69].ReadPointers(binaryReader, blamPointers);
            invalidName_4[70].ReadPointers(binaryReader, blamPointers);
            invalidName_4[71].ReadPointers(binaryReader, blamPointers);
            invalidName_4[72].ReadPointers(binaryReader, blamPointers);
            invalidName_4[73].ReadPointers(binaryReader, blamPointers);
            invalidName_4[74].ReadPointers(binaryReader, blamPointers);
            invalidName_4[75].ReadPointers(binaryReader, blamPointers);
            invalidName_4[76].ReadPointers(binaryReader, blamPointers);
            invalidName_4[77].ReadPointers(binaryReader, blamPointers);
            invalidName_4[78].ReadPointers(binaryReader, blamPointers);
            invalidName_4[79].ReadPointers(binaryReader, blamPointers);
            invalidName_4[80].ReadPointers(binaryReader, blamPointers);
            invalidName_4[81].ReadPointers(binaryReader, blamPointers);
            invalidName_4[82].ReadPointers(binaryReader, blamPointers);
            invalidName_4[83].ReadPointers(binaryReader, blamPointers);
            invalidName_4[84].ReadPointers(binaryReader, blamPointers);
            invalidName_4[85].ReadPointers(binaryReader, blamPointers);
            invalidName_4[86].ReadPointers(binaryReader, blamPointers);
            invalidName_4[87].ReadPointers(binaryReader, blamPointers);
            invalidName_4[88].ReadPointers(binaryReader, blamPointers);
            invalidName_4[89].ReadPointers(binaryReader, blamPointers);
            invalidName_4[90].ReadPointers(binaryReader, blamPointers);
            invalidName_4[91].ReadPointers(binaryReader, blamPointers);
            invalidName_4[92].ReadPointers(binaryReader, blamPointers);
            invalidName_4[93].ReadPointers(binaryReader, blamPointers);
            invalidName_4[94].ReadPointers(binaryReader, blamPointers);
            invalidName_4[95].ReadPointers(binaryReader, blamPointers);
            invalidName_4[96].ReadPointers(binaryReader, blamPointers);
            invalidName_4[97].ReadPointers(binaryReader, blamPointers);
            invalidName_4[98].ReadPointers(binaryReader, blamPointers);
            invalidName_4[99].ReadPointers(binaryReader, blamPointers);
            invalidName_4[100].ReadPointers(binaryReader, blamPointers);
            invalidName_4[101].ReadPointers(binaryReader, blamPointers);
            invalidName_4[102].ReadPointers(binaryReader, blamPointers);
            invalidName_4[103].ReadPointers(binaryReader, blamPointers);
            invalidName_4[104].ReadPointers(binaryReader, blamPointers);
            invalidName_4[105].ReadPointers(binaryReader, blamPointers);
            invalidName_4[106].ReadPointers(binaryReader, blamPointers);
            invalidName_4[107].ReadPointers(binaryReader, blamPointers);
            invalidName_4[108].ReadPointers(binaryReader, blamPointers);
            invalidName_4[109].ReadPointers(binaryReader, blamPointers);
            invalidName_4[110].ReadPointers(binaryReader, blamPointers);
            invalidName_4[111].ReadPointers(binaryReader, blamPointers);
            invalidName_4[112].ReadPointers(binaryReader, blamPointers);
            invalidName_4[113].ReadPointers(binaryReader, blamPointers);
            invalidName_4[114].ReadPointers(binaryReader, blamPointers);
            invalidName_4[115].ReadPointers(binaryReader, blamPointers);
            invalidName_4[116].ReadPointers(binaryReader, blamPointers);
            invalidName_4[117].ReadPointers(binaryReader, blamPointers);
            invalidName_4[118].ReadPointers(binaryReader, blamPointers);
            invalidName_4[119].ReadPointers(binaryReader, blamPointers);
            invalidName_4[120].ReadPointers(binaryReader, blamPointers);
            invalidName_4[121].ReadPointers(binaryReader, blamPointers);
            invalidName_4[122].ReadPointers(binaryReader, blamPointers);
            invalidName_4[123].ReadPointers(binaryReader, blamPointers);
            invalidName_4[124].ReadPointers(binaryReader, blamPointers);
            invalidName_4[125].ReadPointers(binaryReader, blamPointers);
            invalidName_4[126].ReadPointers(binaryReader, blamPointers);
            invalidName_4[127].ReadPointers(binaryReader, blamPointers);
            invalidName_4[128].ReadPointers(binaryReader, blamPointers);
            invalidName_4[129].ReadPointers(binaryReader, blamPointers);
            invalidName_4[130].ReadPointers(binaryReader, blamPointers);
            invalidName_4[131].ReadPointers(binaryReader, blamPointers);
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_5[1].ReadPointers(binaryReader, blamPointers);
            invalidName_5[2].ReadPointers(binaryReader, blamPointers);
            invalidName_5[3].ReadPointers(binaryReader, blamPointers);
            invalidName_5[4].ReadPointers(binaryReader, blamPointers);
            invalidName_5[5].ReadPointers(binaryReader, blamPointers);
            invalidName_5[6].ReadPointers(binaryReader, blamPointers);
            invalidName_5[7].ReadPointers(binaryReader, blamPointers);
            invalidName_5[8].ReadPointers(binaryReader, blamPointers);
            invalidName_5[9].ReadPointers(binaryReader, blamPointers);
            invalidName_5[10].ReadPointers(binaryReader, blamPointers);
            invalidName_5[11].ReadPointers(binaryReader, blamPointers);
            invalidName_5[12].ReadPointers(binaryReader, blamPointers);
            invalidName_5[13].ReadPointers(binaryReader, blamPointers);
            invalidName_5[14].ReadPointers(binaryReader, blamPointers);
            invalidName_5[15].ReadPointers(binaryReader, blamPointers);
            invalidName_5[16].ReadPointers(binaryReader, blamPointers);
            invalidName_5[17].ReadPointers(binaryReader, blamPointers);
            invalidName_5[18].ReadPointers(binaryReader, blamPointers);
            invalidName_5[19].ReadPointers(binaryReader, blamPointers);
            invalidName_5[20].ReadPointers(binaryReader, blamPointers);
            invalidName_5[21].ReadPointers(binaryReader, blamPointers);
            invalidName_5[22].ReadPointers(binaryReader, blamPointers);
            invalidName_5[23].ReadPointers(binaryReader, blamPointers);
            invalidName_5[24].ReadPointers(binaryReader, blamPointers);
            invalidName_5[25].ReadPointers(binaryReader, blamPointers);
            invalidName_5[26].ReadPointers(binaryReader, blamPointers);
            invalidName_5[27].ReadPointers(binaryReader, blamPointers);
            invalidName_5[28].ReadPointers(binaryReader, blamPointers);
            invalidName_5[29].ReadPointers(binaryReader, blamPointers);
            invalidName_5[30].ReadPointers(binaryReader, blamPointers);
            invalidName_5[31].ReadPointers(binaryReader, blamPointers);
            invalidName_5[32].ReadPointers(binaryReader, blamPointers);
            invalidName_5[33].ReadPointers(binaryReader, blamPointers);
            invalidName_5[34].ReadPointers(binaryReader, blamPointers);
            invalidName_5[35].ReadPointers(binaryReader, blamPointers);
            invalidName_5[36].ReadPointers(binaryReader, blamPointers);
            invalidName_5[37].ReadPointers(binaryReader, blamPointers);
            invalidName_5[38].ReadPointers(binaryReader, blamPointers);
            invalidName_5[39].ReadPointers(binaryReader, blamPointers);
            invalidName_5[40].ReadPointers(binaryReader, blamPointers);
            invalidName_5[41].ReadPointers(binaryReader, blamPointers);
            invalidName_5[42].ReadPointers(binaryReader, blamPointers);
            invalidName_5[43].ReadPointers(binaryReader, blamPointers);
            invalidName_5[44].ReadPointers(binaryReader, blamPointers);
            invalidName_5[45].ReadPointers(binaryReader, blamPointers);
            invalidName_5[46].ReadPointers(binaryReader, blamPointers);
            invalidName_5[47].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(childHud);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(inventoryAmmoCutoff);
                binaryWriter.Write(loadedAmmoCutoff);
                binaryWriter.Write(heatCutoff);
                binaryWriter.Write(ageCutoff);
                binaryWriter.Write(invalidName_0, 0, 32);
                binaryWriter.Write((Int16)anchor);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 32);
                nextAddress = Guerilla.WriteBlockArray<WeaponHudStaticBlock>(binaryWriter, staticElements, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponHudMeterBlock>(binaryWriter, meterElements, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponHudNumberBlock>(binaryWriter, numberElements, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponHudCrosshairBlock>(binaryWriter, crosshairs, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<WeaponHudOverlaysBlock>(binaryWriter, overlayElements, nextAddress);
                binaryWriter.Write(invalidName_3, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<GNullBlock>(binaryWriter, gNullBlock, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalHudScreenEffectDefinition>(binaryWriter, screenEffect, nextAddress);
                binaryWriter.Write(invalidName_4, 0, 132);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write(widthOffset);
                binaryWriter.Write(offsetFromReferenceCorner);
                binaryWriter.Write(overrideIconColor);
                binaryWriter.Write(frameRate030);
                binaryWriter.Write((Int16)flags0);
                binaryWriter.Write(textIndex);
                binaryWriter.Write(invalidName_5, 0, 48);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            UseParentHudFlashingParameters = 1,
        };
        internal enum Anchor : short
        {
            TopLeft = 0,
            TopRight = 1,
            BottomLeft = 2,
            BottomRight = 3,
            Center = 4,
            Crosshair = 5,
        };
        [FlagsAttribute]
        internal enum Flags0 : byte
        {
            UseTextFromStringListInstead = 1,
            OverrideDefaultColor = 2,
            WidthOffsetIsAbsoluteIconWidth = 4,
        };
    };
}
