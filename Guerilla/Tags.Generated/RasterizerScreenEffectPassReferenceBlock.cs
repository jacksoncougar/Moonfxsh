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
    public partial class RasterizerScreenEffectPassReferenceBlock : RasterizerScreenEffectPassReferenceBlockBase
    {
        public RasterizerScreenEffectPassReferenceBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 172, Alignment = 4)]
    public class RasterizerScreenEffectPassReferenceBlockBase : GuerillaBlock
    {
        internal byte[] explanation;
        internal short layerPassIndexLeaveAs1UnlessDebugging;
        internal byte[] invalidName_;
        internal byte primary0AndSecondary0ImplementationIndex;
        internal byte primary0AndSecondary0ImplementationIndex0;
        internal byte primary0AndSecondary0ImplementationIndex1;
        internal byte primary0AndSecondary0ImplementationIndex2;
        internal byte[] invalidName_0;
        internal Stage0Mode stage0Mode;
        internal Stage1Mode stage1Mode;
        internal Stage2Mode stage2Mode;
        internal Stage3Mode stage3Mode;
        internal RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock[] advancedControl;
        internal Target target;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal RasterizerScreenEffectConvolutionBlock[] convolution;
        public override int SerializedSize { get { return 172; } }
        public override int Alignment { get { return 4; } }
        public RasterizerScreenEffectPassReferenceBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            layerPassIndexLeaveAs1UnlessDebugging = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            primary0AndSecondary0ImplementationIndex = binaryReader.ReadByte();
            primary0AndSecondary0ImplementationIndex0 = binaryReader.ReadByte();
            primary0AndSecondary0ImplementationIndex1 = binaryReader.ReadByte();
            primary0AndSecondary0ImplementationIndex2 = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(64);
            stage0Mode = (Stage0Mode)binaryReader.ReadInt16();
            stage1Mode = (Stage1Mode)binaryReader.ReadInt16();
            stage2Mode = (Stage2Mode)binaryReader.ReadInt16();
            stage3Mode = (Stage3Mode)binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock>(binaryReader));
            target = (Target)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(64);
            blamPointers.Enqueue(ReadBlockArrayPointer<RasterizerScreenEffectConvolutionBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            explanation = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
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
            invalidName_0[32].ReadPointers(binaryReader, blamPointers);
            invalidName_0[33].ReadPointers(binaryReader, blamPointers);
            invalidName_0[34].ReadPointers(binaryReader, blamPointers);
            invalidName_0[35].ReadPointers(binaryReader, blamPointers);
            invalidName_0[36].ReadPointers(binaryReader, blamPointers);
            invalidName_0[37].ReadPointers(binaryReader, blamPointers);
            invalidName_0[38].ReadPointers(binaryReader, blamPointers);
            invalidName_0[39].ReadPointers(binaryReader, blamPointers);
            invalidName_0[40].ReadPointers(binaryReader, blamPointers);
            invalidName_0[41].ReadPointers(binaryReader, blamPointers);
            invalidName_0[42].ReadPointers(binaryReader, blamPointers);
            invalidName_0[43].ReadPointers(binaryReader, blamPointers);
            invalidName_0[44].ReadPointers(binaryReader, blamPointers);
            invalidName_0[45].ReadPointers(binaryReader, blamPointers);
            invalidName_0[46].ReadPointers(binaryReader, blamPointers);
            invalidName_0[47].ReadPointers(binaryReader, blamPointers);
            invalidName_0[48].ReadPointers(binaryReader, blamPointers);
            invalidName_0[49].ReadPointers(binaryReader, blamPointers);
            invalidName_0[50].ReadPointers(binaryReader, blamPointers);
            invalidName_0[51].ReadPointers(binaryReader, blamPointers);
            invalidName_0[52].ReadPointers(binaryReader, blamPointers);
            invalidName_0[53].ReadPointers(binaryReader, blamPointers);
            invalidName_0[54].ReadPointers(binaryReader, blamPointers);
            invalidName_0[55].ReadPointers(binaryReader, blamPointers);
            invalidName_0[56].ReadPointers(binaryReader, blamPointers);
            invalidName_0[57].ReadPointers(binaryReader, blamPointers);
            invalidName_0[58].ReadPointers(binaryReader, blamPointers);
            invalidName_0[59].ReadPointers(binaryReader, blamPointers);
            invalidName_0[60].ReadPointers(binaryReader, blamPointers);
            invalidName_0[61].ReadPointers(binaryReader, blamPointers);
            invalidName_0[62].ReadPointers(binaryReader, blamPointers);
            invalidName_0[63].ReadPointers(binaryReader, blamPointers);
            advancedControl = ReadBlockArrayData<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock>(binaryReader, blamPointers.Dequeue());
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
            invalidName_2[32].ReadPointers(binaryReader, blamPointers);
            invalidName_2[33].ReadPointers(binaryReader, blamPointers);
            invalidName_2[34].ReadPointers(binaryReader, blamPointers);
            invalidName_2[35].ReadPointers(binaryReader, blamPointers);
            invalidName_2[36].ReadPointers(binaryReader, blamPointers);
            invalidName_2[37].ReadPointers(binaryReader, blamPointers);
            invalidName_2[38].ReadPointers(binaryReader, blamPointers);
            invalidName_2[39].ReadPointers(binaryReader, blamPointers);
            invalidName_2[40].ReadPointers(binaryReader, blamPointers);
            invalidName_2[41].ReadPointers(binaryReader, blamPointers);
            invalidName_2[42].ReadPointers(binaryReader, blamPointers);
            invalidName_2[43].ReadPointers(binaryReader, blamPointers);
            invalidName_2[44].ReadPointers(binaryReader, blamPointers);
            invalidName_2[45].ReadPointers(binaryReader, blamPointers);
            invalidName_2[46].ReadPointers(binaryReader, blamPointers);
            invalidName_2[47].ReadPointers(binaryReader, blamPointers);
            invalidName_2[48].ReadPointers(binaryReader, blamPointers);
            invalidName_2[49].ReadPointers(binaryReader, blamPointers);
            invalidName_2[50].ReadPointers(binaryReader, blamPointers);
            invalidName_2[51].ReadPointers(binaryReader, blamPointers);
            invalidName_2[52].ReadPointers(binaryReader, blamPointers);
            invalidName_2[53].ReadPointers(binaryReader, blamPointers);
            invalidName_2[54].ReadPointers(binaryReader, blamPointers);
            invalidName_2[55].ReadPointers(binaryReader, blamPointers);
            invalidName_2[56].ReadPointers(binaryReader, blamPointers);
            invalidName_2[57].ReadPointers(binaryReader, blamPointers);
            invalidName_2[58].ReadPointers(binaryReader, blamPointers);
            invalidName_2[59].ReadPointers(binaryReader, blamPointers);
            invalidName_2[60].ReadPointers(binaryReader, blamPointers);
            invalidName_2[61].ReadPointers(binaryReader, blamPointers);
            invalidName_2[62].ReadPointers(binaryReader, blamPointers);
            invalidName_2[63].ReadPointers(binaryReader, blamPointers);
            convolution = ReadBlockArrayData<RasterizerScreenEffectConvolutionBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, explanation, nextAddress);
                binaryWriter.Write(layerPassIndexLeaveAs1UnlessDebugging);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(primary0AndSecondary0ImplementationIndex);
                binaryWriter.Write(primary0AndSecondary0ImplementationIndex0);
                binaryWriter.Write(primary0AndSecondary0ImplementationIndex1);
                binaryWriter.Write(primary0AndSecondary0ImplementationIndex2);
                binaryWriter.Write(invalidName_0, 0, 64);
                binaryWriter.Write((Int16)stage0Mode);
                binaryWriter.Write((Int16)stage1Mode);
                binaryWriter.Write((Int16)stage2Mode);
                binaryWriter.Write((Int16)stage3Mode);
                nextAddress = Guerilla.WriteBlockArray<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock>(binaryWriter, advancedControl, nextAddress);
                binaryWriter.Write((Int16)target);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 64);
                nextAddress = Guerilla.WriteBlockArray<RasterizerScreenEffectConvolutionBlock>(binaryWriter, convolution, nextAddress);
                return nextAddress;
            }
        }
        internal enum Stage0Mode : short
        {
            Default = 0,
            ViewportNormalized = 1,
            ViewportRelative = 2,
            FramebufferRelative = 3,
            Zero = 4,
        };
        internal enum Stage1Mode : short
        {
            Default = 0,
            ViewportNormalized = 1,
            ViewportRelative = 2,
            FramebufferRelative = 3,
            Zero = 4,
        };
        internal enum Stage2Mode : short
        {
            Default = 0,
            ViewportNormalized = 1,
            ViewportRelative = 2,
            FramebufferRelative = 3,
            Zero = 4,
        };
        internal enum Stage3Mode : short
        {
            Default = 0,
            ViewportNormalized = 1,
            ViewportRelative = 2,
            FramebufferRelative = 3,
            Zero = 4,
        };
        internal enum Target : short
        {
            Framebuffer = 0,
            Texaccum = 1,
            TexaccumSmall = 2,
            TexaccumTiny = 3,
            CopyFbToTexaccum = 4,
        };
    };
}
