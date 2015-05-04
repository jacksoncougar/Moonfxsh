// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalHudMultitextureOverlayDefinition : GlobalHudMultitextureOverlayDefinitionBase
    {
        public GlobalHudMultitextureOverlayDefinition() : base()
        {
        }
    };
    [LayoutAttribute(Size = 452, Alignment = 4)]
    public class GlobalHudMultitextureOverlayDefinitionBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal short type;
        internal FramebufferBlendFunc framebufferBlendFunc;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal PrimaryAnchor primaryAnchor;
        internal SecondaryAnchor secondaryAnchor;
        internal TertiaryAnchor tertiaryAnchor;
        internal InvalidName0To1BlendFunc invalidName_0To1BlendFunc;
        internal InvalidName1To2BlendFunc invalidName_1To2BlendFunc;
        internal byte[] invalidName_2;
        internal OpenTK.Vector2 primaryScale;
        internal OpenTK.Vector2 secondaryScale;
        internal OpenTK.Vector2 tertiaryScale;
        internal OpenTK.Vector2 primaryOffset;
        internal OpenTK.Vector2 secondaryOffset;
        internal OpenTK.Vector2 tertiaryOffset;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference primary;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference secondary;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference tertiary;
        internal PrimaryWrapMode primaryWrapMode;
        internal SecondaryWrapMode secondaryWrapMode;
        internal TertiaryWrapMode tertiaryWrapMode;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal GlobalHudMultitextureOverlayEffectorDefinition[] effectors;
        internal byte[] invalidName_5;
        public override int SerializedSize { get { return 452; } }
        public override int Alignment { get { return 4; } }
        public GlobalHudMultitextureOverlayDefinitionBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(2);
            type = binaryReader.ReadInt16();
            framebufferBlendFunc = (FramebufferBlendFunc)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(32);
            primaryAnchor = (PrimaryAnchor)binaryReader.ReadInt16();
            secondaryAnchor = (SecondaryAnchor)binaryReader.ReadInt16();
            tertiaryAnchor = (TertiaryAnchor)binaryReader.ReadInt16();
            invalidName_0To1BlendFunc = (InvalidName0To1BlendFunc)binaryReader.ReadInt16();
            invalidName_1To2BlendFunc = (InvalidName1To2BlendFunc)binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            primaryScale = binaryReader.ReadVector2();
            secondaryScale = binaryReader.ReadVector2();
            tertiaryScale = binaryReader.ReadVector2();
            primaryOffset = binaryReader.ReadVector2();
            secondaryOffset = binaryReader.ReadVector2();
            tertiaryOffset = binaryReader.ReadVector2();
            primary = binaryReader.ReadTagReference();
            secondary = binaryReader.ReadTagReference();
            tertiary = binaryReader.ReadTagReference();
            primaryWrapMode = (PrimaryWrapMode)binaryReader.ReadInt16();
            secondaryWrapMode = (SecondaryWrapMode)binaryReader.ReadInt16();
            tertiaryWrapMode = (TertiaryWrapMode)binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            invalidName_4 = binaryReader.ReadBytes(184);
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalHudMultitextureOverlayEffectorDefinition>(binaryReader));
            invalidName_5 = binaryReader.ReadBytes(128);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_1[16].ReadPointers(binaryReader, blamPointers);
            invalidName_1[17].ReadPointers(binaryReader, blamPointers);
            invalidName_1[18].ReadPointers(binaryReader, blamPointers);
            invalidName_1[19].ReadPointers(binaryReader, blamPointers);
            invalidName_1[20].ReadPointers(binaryReader, blamPointers);
            invalidName_1[21].ReadPointers(binaryReader, blamPointers);
            invalidName_1[22].ReadPointers(binaryReader, blamPointers);
            invalidName_1[23].ReadPointers(binaryReader, blamPointers);
            invalidName_1[24].ReadPointers(binaryReader, blamPointers);
            invalidName_1[25].ReadPointers(binaryReader, blamPointers);
            invalidName_1[26].ReadPointers(binaryReader, blamPointers);
            invalidName_1[27].ReadPointers(binaryReader, blamPointers);
            invalidName_1[28].ReadPointers(binaryReader, blamPointers);
            invalidName_1[29].ReadPointers(binaryReader, blamPointers);
            invalidName_1[30].ReadPointers(binaryReader, blamPointers);
            invalidName_1[31].ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
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
            invalidName_4[132].ReadPointers(binaryReader, blamPointers);
            invalidName_4[133].ReadPointers(binaryReader, blamPointers);
            invalidName_4[134].ReadPointers(binaryReader, blamPointers);
            invalidName_4[135].ReadPointers(binaryReader, blamPointers);
            invalidName_4[136].ReadPointers(binaryReader, blamPointers);
            invalidName_4[137].ReadPointers(binaryReader, blamPointers);
            invalidName_4[138].ReadPointers(binaryReader, blamPointers);
            invalidName_4[139].ReadPointers(binaryReader, blamPointers);
            invalidName_4[140].ReadPointers(binaryReader, blamPointers);
            invalidName_4[141].ReadPointers(binaryReader, blamPointers);
            invalidName_4[142].ReadPointers(binaryReader, blamPointers);
            invalidName_4[143].ReadPointers(binaryReader, blamPointers);
            invalidName_4[144].ReadPointers(binaryReader, blamPointers);
            invalidName_4[145].ReadPointers(binaryReader, blamPointers);
            invalidName_4[146].ReadPointers(binaryReader, blamPointers);
            invalidName_4[147].ReadPointers(binaryReader, blamPointers);
            invalidName_4[148].ReadPointers(binaryReader, blamPointers);
            invalidName_4[149].ReadPointers(binaryReader, blamPointers);
            invalidName_4[150].ReadPointers(binaryReader, blamPointers);
            invalidName_4[151].ReadPointers(binaryReader, blamPointers);
            invalidName_4[152].ReadPointers(binaryReader, blamPointers);
            invalidName_4[153].ReadPointers(binaryReader, blamPointers);
            invalidName_4[154].ReadPointers(binaryReader, blamPointers);
            invalidName_4[155].ReadPointers(binaryReader, blamPointers);
            invalidName_4[156].ReadPointers(binaryReader, blamPointers);
            invalidName_4[157].ReadPointers(binaryReader, blamPointers);
            invalidName_4[158].ReadPointers(binaryReader, blamPointers);
            invalidName_4[159].ReadPointers(binaryReader, blamPointers);
            invalidName_4[160].ReadPointers(binaryReader, blamPointers);
            invalidName_4[161].ReadPointers(binaryReader, blamPointers);
            invalidName_4[162].ReadPointers(binaryReader, blamPointers);
            invalidName_4[163].ReadPointers(binaryReader, blamPointers);
            invalidName_4[164].ReadPointers(binaryReader, blamPointers);
            invalidName_4[165].ReadPointers(binaryReader, blamPointers);
            invalidName_4[166].ReadPointers(binaryReader, blamPointers);
            invalidName_4[167].ReadPointers(binaryReader, blamPointers);
            invalidName_4[168].ReadPointers(binaryReader, blamPointers);
            invalidName_4[169].ReadPointers(binaryReader, blamPointers);
            invalidName_4[170].ReadPointers(binaryReader, blamPointers);
            invalidName_4[171].ReadPointers(binaryReader, blamPointers);
            invalidName_4[172].ReadPointers(binaryReader, blamPointers);
            invalidName_4[173].ReadPointers(binaryReader, blamPointers);
            invalidName_4[174].ReadPointers(binaryReader, blamPointers);
            invalidName_4[175].ReadPointers(binaryReader, blamPointers);
            invalidName_4[176].ReadPointers(binaryReader, blamPointers);
            invalidName_4[177].ReadPointers(binaryReader, blamPointers);
            invalidName_4[178].ReadPointers(binaryReader, blamPointers);
            invalidName_4[179].ReadPointers(binaryReader, blamPointers);
            invalidName_4[180].ReadPointers(binaryReader, blamPointers);
            invalidName_4[181].ReadPointers(binaryReader, blamPointers);
            invalidName_4[182].ReadPointers(binaryReader, blamPointers);
            invalidName_4[183].ReadPointers(binaryReader, blamPointers);
            effectors = ReadBlockArrayData<GlobalHudMultitextureOverlayEffectorDefinition>(binaryReader, blamPointers.Dequeue());
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
            invalidName_5[48].ReadPointers(binaryReader, blamPointers);
            invalidName_5[49].ReadPointers(binaryReader, blamPointers);
            invalidName_5[50].ReadPointers(binaryReader, blamPointers);
            invalidName_5[51].ReadPointers(binaryReader, blamPointers);
            invalidName_5[52].ReadPointers(binaryReader, blamPointers);
            invalidName_5[53].ReadPointers(binaryReader, blamPointers);
            invalidName_5[54].ReadPointers(binaryReader, blamPointers);
            invalidName_5[55].ReadPointers(binaryReader, blamPointers);
            invalidName_5[56].ReadPointers(binaryReader, blamPointers);
            invalidName_5[57].ReadPointers(binaryReader, blamPointers);
            invalidName_5[58].ReadPointers(binaryReader, blamPointers);
            invalidName_5[59].ReadPointers(binaryReader, blamPointers);
            invalidName_5[60].ReadPointers(binaryReader, blamPointers);
            invalidName_5[61].ReadPointers(binaryReader, blamPointers);
            invalidName_5[62].ReadPointers(binaryReader, blamPointers);
            invalidName_5[63].ReadPointers(binaryReader, blamPointers);
            invalidName_5[64].ReadPointers(binaryReader, blamPointers);
            invalidName_5[65].ReadPointers(binaryReader, blamPointers);
            invalidName_5[66].ReadPointers(binaryReader, blamPointers);
            invalidName_5[67].ReadPointers(binaryReader, blamPointers);
            invalidName_5[68].ReadPointers(binaryReader, blamPointers);
            invalidName_5[69].ReadPointers(binaryReader, blamPointers);
            invalidName_5[70].ReadPointers(binaryReader, blamPointers);
            invalidName_5[71].ReadPointers(binaryReader, blamPointers);
            invalidName_5[72].ReadPointers(binaryReader, blamPointers);
            invalidName_5[73].ReadPointers(binaryReader, blamPointers);
            invalidName_5[74].ReadPointers(binaryReader, blamPointers);
            invalidName_5[75].ReadPointers(binaryReader, blamPointers);
            invalidName_5[76].ReadPointers(binaryReader, blamPointers);
            invalidName_5[77].ReadPointers(binaryReader, blamPointers);
            invalidName_5[78].ReadPointers(binaryReader, blamPointers);
            invalidName_5[79].ReadPointers(binaryReader, blamPointers);
            invalidName_5[80].ReadPointers(binaryReader, blamPointers);
            invalidName_5[81].ReadPointers(binaryReader, blamPointers);
            invalidName_5[82].ReadPointers(binaryReader, blamPointers);
            invalidName_5[83].ReadPointers(binaryReader, blamPointers);
            invalidName_5[84].ReadPointers(binaryReader, blamPointers);
            invalidName_5[85].ReadPointers(binaryReader, blamPointers);
            invalidName_5[86].ReadPointers(binaryReader, blamPointers);
            invalidName_5[87].ReadPointers(binaryReader, blamPointers);
            invalidName_5[88].ReadPointers(binaryReader, blamPointers);
            invalidName_5[89].ReadPointers(binaryReader, blamPointers);
            invalidName_5[90].ReadPointers(binaryReader, blamPointers);
            invalidName_5[91].ReadPointers(binaryReader, blamPointers);
            invalidName_5[92].ReadPointers(binaryReader, blamPointers);
            invalidName_5[93].ReadPointers(binaryReader, blamPointers);
            invalidName_5[94].ReadPointers(binaryReader, blamPointers);
            invalidName_5[95].ReadPointers(binaryReader, blamPointers);
            invalidName_5[96].ReadPointers(binaryReader, blamPointers);
            invalidName_5[97].ReadPointers(binaryReader, blamPointers);
            invalidName_5[98].ReadPointers(binaryReader, blamPointers);
            invalidName_5[99].ReadPointers(binaryReader, blamPointers);
            invalidName_5[100].ReadPointers(binaryReader, blamPointers);
            invalidName_5[101].ReadPointers(binaryReader, blamPointers);
            invalidName_5[102].ReadPointers(binaryReader, blamPointers);
            invalidName_5[103].ReadPointers(binaryReader, blamPointers);
            invalidName_5[104].ReadPointers(binaryReader, blamPointers);
            invalidName_5[105].ReadPointers(binaryReader, blamPointers);
            invalidName_5[106].ReadPointers(binaryReader, blamPointers);
            invalidName_5[107].ReadPointers(binaryReader, blamPointers);
            invalidName_5[108].ReadPointers(binaryReader, blamPointers);
            invalidName_5[109].ReadPointers(binaryReader, blamPointers);
            invalidName_5[110].ReadPointers(binaryReader, blamPointers);
            invalidName_5[111].ReadPointers(binaryReader, blamPointers);
            invalidName_5[112].ReadPointers(binaryReader, blamPointers);
            invalidName_5[113].ReadPointers(binaryReader, blamPointers);
            invalidName_5[114].ReadPointers(binaryReader, blamPointers);
            invalidName_5[115].ReadPointers(binaryReader, blamPointers);
            invalidName_5[116].ReadPointers(binaryReader, blamPointers);
            invalidName_5[117].ReadPointers(binaryReader, blamPointers);
            invalidName_5[118].ReadPointers(binaryReader, blamPointers);
            invalidName_5[119].ReadPointers(binaryReader, blamPointers);
            invalidName_5[120].ReadPointers(binaryReader, blamPointers);
            invalidName_5[121].ReadPointers(binaryReader, blamPointers);
            invalidName_5[122].ReadPointers(binaryReader, blamPointers);
            invalidName_5[123].ReadPointers(binaryReader, blamPointers);
            invalidName_5[124].ReadPointers(binaryReader, blamPointers);
            invalidName_5[125].ReadPointers(binaryReader, blamPointers);
            invalidName_5[126].ReadPointers(binaryReader, blamPointers);
            invalidName_5[127].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(type);
                binaryWriter.Write((Int16)framebufferBlendFunc);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 32);
                binaryWriter.Write((Int16)primaryAnchor);
                binaryWriter.Write((Int16)secondaryAnchor);
                binaryWriter.Write((Int16)tertiaryAnchor);
                binaryWriter.Write((Int16)invalidName_0To1BlendFunc);
                binaryWriter.Write((Int16)invalidName_1To2BlendFunc);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(primaryScale);
                binaryWriter.Write(secondaryScale);
                binaryWriter.Write(tertiaryScale);
                binaryWriter.Write(primaryOffset);
                binaryWriter.Write(secondaryOffset);
                binaryWriter.Write(tertiaryOffset);
                binaryWriter.Write(primary);
                binaryWriter.Write(secondary);
                binaryWriter.Write(tertiary);
                binaryWriter.Write((Int16)primaryWrapMode);
                binaryWriter.Write((Int16)secondaryWrapMode);
                binaryWriter.Write((Int16)tertiaryWrapMode);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(invalidName_4, 0, 184);
                nextAddress = Guerilla.WriteBlockArray<GlobalHudMultitextureOverlayEffectorDefinition>(binaryWriter, effectors, nextAddress);
                binaryWriter.Write(invalidName_5, 0, 128);
                return nextAddress;
            }
        }
        internal enum FramebufferBlendFunc : short
        {
            AlphaBlend = 0,
            Multiply = 1,
            DoubleMultiply = 2,
            Add = 3,
            Subtract = 4,
            ComponentMin = 5,
            ComponentMax = 6,
            AlphaMultiplyAdd = 7,
            ConstantColorBlend = 8,
            InverseConstantColorBlend = 9,
            None = 10,
        };
        internal enum PrimaryAnchor : short
        {
            Texture = 0,
            Screen = 1,
        };
        internal enum SecondaryAnchor : short
        {
            Texture = 0,
            Screen = 1,
        };
        internal enum TertiaryAnchor : short
        {
            Texture = 0,
            Screen = 1,
        };
        internal enum InvalidName0To1BlendFunc : short
        {
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Multiply2x = 3,
            Dot = 4,
        };
        internal enum InvalidName1To2BlendFunc : short
        {
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Multiply2x = 3,
            Dot = 4,
        };
        internal enum PrimaryWrapMode : short
        {
            Clamp = 0,
            Wrap = 1,
        };
        internal enum SecondaryWrapMode : short
        {
            Clamp = 0,
            Wrap = 1,
        };
        internal enum TertiaryWrapMode : short
        {
            Clamp = 0,
            Wrap = 1,
        };
    };
}
