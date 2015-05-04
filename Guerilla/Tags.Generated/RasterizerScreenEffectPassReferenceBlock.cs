// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RasterizerScreenEffectPassReferenceBlock : RasterizerScreenEffectPassReferenceBlockBase
    {
        public  RasterizerScreenEffectPassReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RasterizerScreenEffectPassReferenceBlock(): base()
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
        
        public override int SerializedSize{get { return 172; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RasterizerScreenEffectPassReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            explanation = Guerilla.ReadData(binaryReader);
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
            advancedControl = Guerilla.ReadBlockArray<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock>(binaryReader);
            target = (Target)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(64);
            convolution = Guerilla.ReadBlockArray<RasterizerScreenEffectConvolutionBlock>(binaryReader);
        }
        public  RasterizerScreenEffectPassReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            explanation = Guerilla.ReadData(binaryReader);
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
            advancedControl = Guerilla.ReadBlockArray<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock>(binaryReader);
            target = (Target)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(64);
            convolution = Guerilla.ReadBlockArray<RasterizerScreenEffectConvolutionBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
