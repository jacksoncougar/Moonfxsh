// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderStateAlphaBlendStateBlock : ShaderStateAlphaBlendStateBlockBase
    {
        public  ShaderStateAlphaBlendStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ShaderStateAlphaBlendStateBlockBase : GuerillaBlock
    {
        internal BlendFunction blendFunction;
        internal BlendSrcFactor blendSrcFactor;
        internal BlendDstFactor blendDstFactor;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ColourA1R1G1B1 blendColor;
        internal LogicOpFlags logicOpFlags;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 16; }}
        
        internal  ShaderStateAlphaBlendStateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            blendFunction = (BlendFunction)binaryReader.ReadInt16();
            blendSrcFactor = (BlendSrcFactor)binaryReader.ReadInt16();
            blendDstFactor = (BlendDstFactor)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blendColor = binaryReader.ReadColourA1R1G1B1();
            logicOpFlags = (LogicOpFlags)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)blendFunction);
                binaryWriter.Write((Int16)blendSrcFactor);
                binaryWriter.Write((Int16)blendDstFactor);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(blendColor);
                binaryWriter.Write((Int16)logicOpFlags);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress;
            }
        }
        internal enum BlendFunction : short
        {
            Add = 0,
            Subtract = 1,
            ReverseSubtract = 2,
            Min = 3,
            Max = 4,
            AddSigned = 5,
            ReverseSubtractSigned = 6,
            LogicOp = 7,
        };
        internal enum BlendSrcFactor : short
        {
            Zero = 0,
            One = 1,
            Srccolor = 2,
            SrccolorInverse = 3,
            Srcalpha = 4,
            SrcalphaInverse = 5,
            Dstcolor = 6,
            DstcolorInverse = 7,
            Dstalpha = 8,
            DstalphaInverse = 9,
            SrcalphaSaturate = 10,
            ConstantColor = 11,
            ConstantColorInverse = 12,
            ConstantAlpha = 13,
            ConstantAlphaInverse = 14,
        };
        internal enum BlendDstFactor : short
        {
            Zero = 0,
            One = 1,
            Srccolor = 2,
            SrccolorInverse = 3,
            Srcalpha = 4,
            SrcalphaInverse = 5,
            Dstcolor = 6,
            DstcolorInverse = 7,
            Dstalpha = 8,
            DstalphaInverse = 9,
            SrcalphaSaturate = 10,
            ConstantColor = 11,
            ConstantColorInverse = 12,
            ConstantAlpha = 13,
            ConstantAlphaInverse = 14,
        };
        [FlagsAttribute]
        internal enum LogicOpFlags : short
        {
            Src0Dst0 = 1,
            Src0Dst1 = 2,
            Src1Dst0 = 4,
            Src1Dst1 = 8,
        };
    };
}
