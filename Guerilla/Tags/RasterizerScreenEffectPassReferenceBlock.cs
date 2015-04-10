using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RasterizerScreenEffectPassReferenceBlock : RasterizerScreenEffectPassReferenceBlockBase
    {
        public  RasterizerScreenEffectPassReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 172)]
    public class RasterizerScreenEffectPassReferenceBlockBase
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
        internal  RasterizerScreenEffectPassReferenceBlockBase(BinaryReader binaryReader)
        {
            this.explanation = ReadData(binaryReader);
            this.layerPassIndexLeaveAs1UnlessDebugging = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.primary0AndSecondary0ImplementationIndex = binaryReader.ReadByte();
            this.primary0AndSecondary0ImplementationIndex0 = binaryReader.ReadByte();
            this.primary0AndSecondary0ImplementationIndex1 = binaryReader.ReadByte();
            this.primary0AndSecondary0ImplementationIndex2 = binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(64);
            this.stage0Mode = (Stage0Mode)binaryReader.ReadInt16();
            this.stage1Mode = (Stage1Mode)binaryReader.ReadInt16();
            this.stage2Mode = (Stage2Mode)binaryReader.ReadInt16();
            this.stage3Mode = (Stage3Mode)binaryReader.ReadInt16();
            this.advancedControl = ReadRasterizerScreenEffectTexcoordGenerationAdvancedControlBlockArray(binaryReader);
            this.target = (Target)binaryReader.ReadInt16();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(64);
            this.convolution = ReadRasterizerScreenEffectConvolutionBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock[] ReadRasterizerScreenEffectTexcoordGenerationAdvancedControlBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RasterizerScreenEffectConvolutionBlock[] ReadRasterizerScreenEffectConvolutionBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RasterizerScreenEffectConvolutionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RasterizerScreenEffectConvolutionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RasterizerScreenEffectConvolutionBlock(binaryReader);
                }
            }
            return array;
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
