using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderStateAlphaBlendStateBlock : ShaderStateAlphaBlendStateBlockBase
    {
        public  ShaderStateAlphaBlendStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ShaderStateAlphaBlendStateBlockBase
    {
        internal BlendFunction blendFunction;
        internal BlendSrcFactor blendSrcFactor;
        internal BlendDstFactor blendDstFactor;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ColourA1R1G1B1 blendColor;
        internal LogicOpFlags logicOpFlags;
        internal byte[] invalidName_0;
        internal  ShaderStateAlphaBlendStateBlockBase(BinaryReader binaryReader)
        {
            this.blendFunction = (BlendFunction)binaryReader.ReadInt16();
            this.blendSrcFactor = (BlendSrcFactor)binaryReader.ReadInt16();
            this.blendDstFactor = (BlendDstFactor)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.blendColor = binaryReader.ReadColourA1R1G1B1();
            this.logicOpFlags = (LogicOpFlags)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
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
