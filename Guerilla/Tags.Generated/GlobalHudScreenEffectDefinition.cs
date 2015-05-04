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
    public partial class GlobalHudScreenEffectDefinition : GlobalHudScreenEffectDefinitionBase
    {
        public GlobalHudScreenEffectDefinition() : base()
        {
        }
    };
    [LayoutAttribute(Size = 320, Alignment = 4)]
    public class GlobalHudScreenEffectDefinitionBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Flags flags;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference maskFullscreen;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference maskSplitscreen;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal byte[] invalidName_8;
        internal ScreenEffectFlags screenEffectFlags;
        internal byte[] invalidName_9;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference screenEffect;
        internal byte[] invalidName_10;
        internal ScreenEffectFlags screenEffectFlags0;
        internal byte[] invalidName_11;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference screenEffect0;
        internal byte[] invalidName_12;
        public override int SerializedSize { get { return 320; } }
        public override int Alignment { get { return 4; } }
        public GlobalHudScreenEffectDefinitionBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(16);
            maskFullscreen = binaryReader.ReadTagReference();
            maskSplitscreen = binaryReader.ReadTagReference();
            invalidName_2 = binaryReader.ReadBytes(8);
            invalidName_3 = binaryReader.ReadBytes(20);
            invalidName_4 = binaryReader.ReadBytes(24);
            invalidName_5 = binaryReader.ReadBytes(8);
            invalidName_6 = binaryReader.ReadBytes(24);
            invalidName_7 = binaryReader.ReadBytes(20);
            invalidName_8 = binaryReader.ReadBytes(24);
            screenEffectFlags = (ScreenEffectFlags)binaryReader.ReadInt32();
            invalidName_9 = binaryReader.ReadBytes(32);
            screenEffect = binaryReader.ReadTagReference();
            invalidName_10 = binaryReader.ReadBytes(32);
            screenEffectFlags0 = (ScreenEffectFlags)binaryReader.ReadInt32();
            invalidName_11 = binaryReader.ReadBytes(32);
            screenEffect0 = binaryReader.ReadTagReference();
            invalidName_12 = binaryReader.ReadBytes(32);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
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
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            invalidName_3[4].ReadPointers(binaryReader, blamPointers);
            invalidName_3[5].ReadPointers(binaryReader, blamPointers);
            invalidName_3[6].ReadPointers(binaryReader, blamPointers);
            invalidName_3[7].ReadPointers(binaryReader, blamPointers);
            invalidName_3[8].ReadPointers(binaryReader, blamPointers);
            invalidName_3[9].ReadPointers(binaryReader, blamPointers);
            invalidName_3[10].ReadPointers(binaryReader, blamPointers);
            invalidName_3[11].ReadPointers(binaryReader, blamPointers);
            invalidName_3[12].ReadPointers(binaryReader, blamPointers);
            invalidName_3[13].ReadPointers(binaryReader, blamPointers);
            invalidName_3[14].ReadPointers(binaryReader, blamPointers);
            invalidName_3[15].ReadPointers(binaryReader, blamPointers);
            invalidName_3[16].ReadPointers(binaryReader, blamPointers);
            invalidName_3[17].ReadPointers(binaryReader, blamPointers);
            invalidName_3[18].ReadPointers(binaryReader, blamPointers);
            invalidName_3[19].ReadPointers(binaryReader, blamPointers);
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
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_5[1].ReadPointers(binaryReader, blamPointers);
            invalidName_5[2].ReadPointers(binaryReader, blamPointers);
            invalidName_5[3].ReadPointers(binaryReader, blamPointers);
            invalidName_5[4].ReadPointers(binaryReader, blamPointers);
            invalidName_5[5].ReadPointers(binaryReader, blamPointers);
            invalidName_5[6].ReadPointers(binaryReader, blamPointers);
            invalidName_5[7].ReadPointers(binaryReader, blamPointers);
            invalidName_6[0].ReadPointers(binaryReader, blamPointers);
            invalidName_6[1].ReadPointers(binaryReader, blamPointers);
            invalidName_6[2].ReadPointers(binaryReader, blamPointers);
            invalidName_6[3].ReadPointers(binaryReader, blamPointers);
            invalidName_6[4].ReadPointers(binaryReader, blamPointers);
            invalidName_6[5].ReadPointers(binaryReader, blamPointers);
            invalidName_6[6].ReadPointers(binaryReader, blamPointers);
            invalidName_6[7].ReadPointers(binaryReader, blamPointers);
            invalidName_6[8].ReadPointers(binaryReader, blamPointers);
            invalidName_6[9].ReadPointers(binaryReader, blamPointers);
            invalidName_6[10].ReadPointers(binaryReader, blamPointers);
            invalidName_6[11].ReadPointers(binaryReader, blamPointers);
            invalidName_6[12].ReadPointers(binaryReader, blamPointers);
            invalidName_6[13].ReadPointers(binaryReader, blamPointers);
            invalidName_6[14].ReadPointers(binaryReader, blamPointers);
            invalidName_6[15].ReadPointers(binaryReader, blamPointers);
            invalidName_6[16].ReadPointers(binaryReader, blamPointers);
            invalidName_6[17].ReadPointers(binaryReader, blamPointers);
            invalidName_6[18].ReadPointers(binaryReader, blamPointers);
            invalidName_6[19].ReadPointers(binaryReader, blamPointers);
            invalidName_6[20].ReadPointers(binaryReader, blamPointers);
            invalidName_6[21].ReadPointers(binaryReader, blamPointers);
            invalidName_6[22].ReadPointers(binaryReader, blamPointers);
            invalidName_6[23].ReadPointers(binaryReader, blamPointers);
            invalidName_7[0].ReadPointers(binaryReader, blamPointers);
            invalidName_7[1].ReadPointers(binaryReader, blamPointers);
            invalidName_7[2].ReadPointers(binaryReader, blamPointers);
            invalidName_7[3].ReadPointers(binaryReader, blamPointers);
            invalidName_7[4].ReadPointers(binaryReader, blamPointers);
            invalidName_7[5].ReadPointers(binaryReader, blamPointers);
            invalidName_7[6].ReadPointers(binaryReader, blamPointers);
            invalidName_7[7].ReadPointers(binaryReader, blamPointers);
            invalidName_7[8].ReadPointers(binaryReader, blamPointers);
            invalidName_7[9].ReadPointers(binaryReader, blamPointers);
            invalidName_7[10].ReadPointers(binaryReader, blamPointers);
            invalidName_7[11].ReadPointers(binaryReader, blamPointers);
            invalidName_7[12].ReadPointers(binaryReader, blamPointers);
            invalidName_7[13].ReadPointers(binaryReader, blamPointers);
            invalidName_7[14].ReadPointers(binaryReader, blamPointers);
            invalidName_7[15].ReadPointers(binaryReader, blamPointers);
            invalidName_7[16].ReadPointers(binaryReader, blamPointers);
            invalidName_7[17].ReadPointers(binaryReader, blamPointers);
            invalidName_7[18].ReadPointers(binaryReader, blamPointers);
            invalidName_7[19].ReadPointers(binaryReader, blamPointers);
            invalidName_8[0].ReadPointers(binaryReader, blamPointers);
            invalidName_8[1].ReadPointers(binaryReader, blamPointers);
            invalidName_8[2].ReadPointers(binaryReader, blamPointers);
            invalidName_8[3].ReadPointers(binaryReader, blamPointers);
            invalidName_8[4].ReadPointers(binaryReader, blamPointers);
            invalidName_8[5].ReadPointers(binaryReader, blamPointers);
            invalidName_8[6].ReadPointers(binaryReader, blamPointers);
            invalidName_8[7].ReadPointers(binaryReader, blamPointers);
            invalidName_8[8].ReadPointers(binaryReader, blamPointers);
            invalidName_8[9].ReadPointers(binaryReader, blamPointers);
            invalidName_8[10].ReadPointers(binaryReader, blamPointers);
            invalidName_8[11].ReadPointers(binaryReader, blamPointers);
            invalidName_8[12].ReadPointers(binaryReader, blamPointers);
            invalidName_8[13].ReadPointers(binaryReader, blamPointers);
            invalidName_8[14].ReadPointers(binaryReader, blamPointers);
            invalidName_8[15].ReadPointers(binaryReader, blamPointers);
            invalidName_8[16].ReadPointers(binaryReader, blamPointers);
            invalidName_8[17].ReadPointers(binaryReader, blamPointers);
            invalidName_8[18].ReadPointers(binaryReader, blamPointers);
            invalidName_8[19].ReadPointers(binaryReader, blamPointers);
            invalidName_8[20].ReadPointers(binaryReader, blamPointers);
            invalidName_8[21].ReadPointers(binaryReader, blamPointers);
            invalidName_8[22].ReadPointers(binaryReader, blamPointers);
            invalidName_8[23].ReadPointers(binaryReader, blamPointers);
            invalidName_9[0].ReadPointers(binaryReader, blamPointers);
            invalidName_9[1].ReadPointers(binaryReader, blamPointers);
            invalidName_9[2].ReadPointers(binaryReader, blamPointers);
            invalidName_9[3].ReadPointers(binaryReader, blamPointers);
            invalidName_9[4].ReadPointers(binaryReader, blamPointers);
            invalidName_9[5].ReadPointers(binaryReader, blamPointers);
            invalidName_9[6].ReadPointers(binaryReader, blamPointers);
            invalidName_9[7].ReadPointers(binaryReader, blamPointers);
            invalidName_9[8].ReadPointers(binaryReader, blamPointers);
            invalidName_9[9].ReadPointers(binaryReader, blamPointers);
            invalidName_9[10].ReadPointers(binaryReader, blamPointers);
            invalidName_9[11].ReadPointers(binaryReader, blamPointers);
            invalidName_9[12].ReadPointers(binaryReader, blamPointers);
            invalidName_9[13].ReadPointers(binaryReader, blamPointers);
            invalidName_9[14].ReadPointers(binaryReader, blamPointers);
            invalidName_9[15].ReadPointers(binaryReader, blamPointers);
            invalidName_9[16].ReadPointers(binaryReader, blamPointers);
            invalidName_9[17].ReadPointers(binaryReader, blamPointers);
            invalidName_9[18].ReadPointers(binaryReader, blamPointers);
            invalidName_9[19].ReadPointers(binaryReader, blamPointers);
            invalidName_9[20].ReadPointers(binaryReader, blamPointers);
            invalidName_9[21].ReadPointers(binaryReader, blamPointers);
            invalidName_9[22].ReadPointers(binaryReader, blamPointers);
            invalidName_9[23].ReadPointers(binaryReader, blamPointers);
            invalidName_9[24].ReadPointers(binaryReader, blamPointers);
            invalidName_9[25].ReadPointers(binaryReader, blamPointers);
            invalidName_9[26].ReadPointers(binaryReader, blamPointers);
            invalidName_9[27].ReadPointers(binaryReader, blamPointers);
            invalidName_9[28].ReadPointers(binaryReader, blamPointers);
            invalidName_9[29].ReadPointers(binaryReader, blamPointers);
            invalidName_9[30].ReadPointers(binaryReader, blamPointers);
            invalidName_9[31].ReadPointers(binaryReader, blamPointers);
            invalidName_10[0].ReadPointers(binaryReader, blamPointers);
            invalidName_10[1].ReadPointers(binaryReader, blamPointers);
            invalidName_10[2].ReadPointers(binaryReader, blamPointers);
            invalidName_10[3].ReadPointers(binaryReader, blamPointers);
            invalidName_10[4].ReadPointers(binaryReader, blamPointers);
            invalidName_10[5].ReadPointers(binaryReader, blamPointers);
            invalidName_10[6].ReadPointers(binaryReader, blamPointers);
            invalidName_10[7].ReadPointers(binaryReader, blamPointers);
            invalidName_10[8].ReadPointers(binaryReader, blamPointers);
            invalidName_10[9].ReadPointers(binaryReader, blamPointers);
            invalidName_10[10].ReadPointers(binaryReader, blamPointers);
            invalidName_10[11].ReadPointers(binaryReader, blamPointers);
            invalidName_10[12].ReadPointers(binaryReader, blamPointers);
            invalidName_10[13].ReadPointers(binaryReader, blamPointers);
            invalidName_10[14].ReadPointers(binaryReader, blamPointers);
            invalidName_10[15].ReadPointers(binaryReader, blamPointers);
            invalidName_10[16].ReadPointers(binaryReader, blamPointers);
            invalidName_10[17].ReadPointers(binaryReader, blamPointers);
            invalidName_10[18].ReadPointers(binaryReader, blamPointers);
            invalidName_10[19].ReadPointers(binaryReader, blamPointers);
            invalidName_10[20].ReadPointers(binaryReader, blamPointers);
            invalidName_10[21].ReadPointers(binaryReader, blamPointers);
            invalidName_10[22].ReadPointers(binaryReader, blamPointers);
            invalidName_10[23].ReadPointers(binaryReader, blamPointers);
            invalidName_10[24].ReadPointers(binaryReader, blamPointers);
            invalidName_10[25].ReadPointers(binaryReader, blamPointers);
            invalidName_10[26].ReadPointers(binaryReader, blamPointers);
            invalidName_10[27].ReadPointers(binaryReader, blamPointers);
            invalidName_10[28].ReadPointers(binaryReader, blamPointers);
            invalidName_10[29].ReadPointers(binaryReader, blamPointers);
            invalidName_10[30].ReadPointers(binaryReader, blamPointers);
            invalidName_10[31].ReadPointers(binaryReader, blamPointers);
            invalidName_11[0].ReadPointers(binaryReader, blamPointers);
            invalidName_11[1].ReadPointers(binaryReader, blamPointers);
            invalidName_11[2].ReadPointers(binaryReader, blamPointers);
            invalidName_11[3].ReadPointers(binaryReader, blamPointers);
            invalidName_11[4].ReadPointers(binaryReader, blamPointers);
            invalidName_11[5].ReadPointers(binaryReader, blamPointers);
            invalidName_11[6].ReadPointers(binaryReader, blamPointers);
            invalidName_11[7].ReadPointers(binaryReader, blamPointers);
            invalidName_11[8].ReadPointers(binaryReader, blamPointers);
            invalidName_11[9].ReadPointers(binaryReader, blamPointers);
            invalidName_11[10].ReadPointers(binaryReader, blamPointers);
            invalidName_11[11].ReadPointers(binaryReader, blamPointers);
            invalidName_11[12].ReadPointers(binaryReader, blamPointers);
            invalidName_11[13].ReadPointers(binaryReader, blamPointers);
            invalidName_11[14].ReadPointers(binaryReader, blamPointers);
            invalidName_11[15].ReadPointers(binaryReader, blamPointers);
            invalidName_11[16].ReadPointers(binaryReader, blamPointers);
            invalidName_11[17].ReadPointers(binaryReader, blamPointers);
            invalidName_11[18].ReadPointers(binaryReader, blamPointers);
            invalidName_11[19].ReadPointers(binaryReader, blamPointers);
            invalidName_11[20].ReadPointers(binaryReader, blamPointers);
            invalidName_11[21].ReadPointers(binaryReader, blamPointers);
            invalidName_11[22].ReadPointers(binaryReader, blamPointers);
            invalidName_11[23].ReadPointers(binaryReader, blamPointers);
            invalidName_11[24].ReadPointers(binaryReader, blamPointers);
            invalidName_11[25].ReadPointers(binaryReader, blamPointers);
            invalidName_11[26].ReadPointers(binaryReader, blamPointers);
            invalidName_11[27].ReadPointers(binaryReader, blamPointers);
            invalidName_11[28].ReadPointers(binaryReader, blamPointers);
            invalidName_11[29].ReadPointers(binaryReader, blamPointers);
            invalidName_11[30].ReadPointers(binaryReader, blamPointers);
            invalidName_11[31].ReadPointers(binaryReader, blamPointers);
            invalidName_12[0].ReadPointers(binaryReader, blamPointers);
            invalidName_12[1].ReadPointers(binaryReader, blamPointers);
            invalidName_12[2].ReadPointers(binaryReader, blamPointers);
            invalidName_12[3].ReadPointers(binaryReader, blamPointers);
            invalidName_12[4].ReadPointers(binaryReader, blamPointers);
            invalidName_12[5].ReadPointers(binaryReader, blamPointers);
            invalidName_12[6].ReadPointers(binaryReader, blamPointers);
            invalidName_12[7].ReadPointers(binaryReader, blamPointers);
            invalidName_12[8].ReadPointers(binaryReader, blamPointers);
            invalidName_12[9].ReadPointers(binaryReader, blamPointers);
            invalidName_12[10].ReadPointers(binaryReader, blamPointers);
            invalidName_12[11].ReadPointers(binaryReader, blamPointers);
            invalidName_12[12].ReadPointers(binaryReader, blamPointers);
            invalidName_12[13].ReadPointers(binaryReader, blamPointers);
            invalidName_12[14].ReadPointers(binaryReader, blamPointers);
            invalidName_12[15].ReadPointers(binaryReader, blamPointers);
            invalidName_12[16].ReadPointers(binaryReader, blamPointers);
            invalidName_12[17].ReadPointers(binaryReader, blamPointers);
            invalidName_12[18].ReadPointers(binaryReader, blamPointers);
            invalidName_12[19].ReadPointers(binaryReader, blamPointers);
            invalidName_12[20].ReadPointers(binaryReader, blamPointers);
            invalidName_12[21].ReadPointers(binaryReader, blamPointers);
            invalidName_12[22].ReadPointers(binaryReader, blamPointers);
            invalidName_12[23].ReadPointers(binaryReader, blamPointers);
            invalidName_12[24].ReadPointers(binaryReader, blamPointers);
            invalidName_12[25].ReadPointers(binaryReader, blamPointers);
            invalidName_12[26].ReadPointers(binaryReader, blamPointers);
            invalidName_12[27].ReadPointers(binaryReader, blamPointers);
            invalidName_12[28].ReadPointers(binaryReader, blamPointers);
            invalidName_12[29].ReadPointers(binaryReader, blamPointers);
            invalidName_12[30].ReadPointers(binaryReader, blamPointers);
            invalidName_12[31].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 16);
                binaryWriter.Write(maskFullscreen);
                binaryWriter.Write(maskSplitscreen);
                binaryWriter.Write(invalidName_2, 0, 8);
                binaryWriter.Write(invalidName_3, 0, 20);
                binaryWriter.Write(invalidName_4, 0, 24);
                binaryWriter.Write(invalidName_5, 0, 8);
                binaryWriter.Write(invalidName_6, 0, 24);
                binaryWriter.Write(invalidName_7, 0, 20);
                binaryWriter.Write(invalidName_8, 0, 24);
                binaryWriter.Write((Int32)screenEffectFlags);
                binaryWriter.Write(invalidName_9, 0, 32);
                binaryWriter.Write(screenEffect);
                binaryWriter.Write(invalidName_10, 0, 32);
                binaryWriter.Write((Int32)screenEffectFlags0);
                binaryWriter.Write(invalidName_11, 0, 32);
                binaryWriter.Write(screenEffect0);
                binaryWriter.Write(invalidName_12, 0, 32);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            OnlyWhenZoomed = 1,
            MirrorHorizontally = 2,
            MirrorVertically = 4,
            UseNewHotness = 8,
        };
        [FlagsAttribute]
        internal enum ScreenEffectFlags : int
        {
            OnlyWhenZoomed = 1,
        };
        [FlagsAttribute]
        internal enum ScreenEffectFlags0 : int
        {
            OnlyWhenZoomed = 1,
        };
    };
}
