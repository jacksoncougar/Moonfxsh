using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderStateConstantBlock : ShaderStateConstantBlockBase
    {
        public  ShaderStateConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ShaderStateConstantBlockBase
    {
        internal Moonfish.Tags.StringID sourceParameter;
        internal byte[] invalidName_;
        internal Constant constant;
        internal  ShaderStateConstantBlockBase(BinaryReader binaryReader)
        {
            this.sourceParameter = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.constant = (Constant)binaryReader.ReadInt16();
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
        internal enum Constant : short
        
        {
            ConstantBlendColor = 0,
            ConstantBlendAlphaValue = 1,
            AlphaTestRefValue = 2,
            DepthBiasSlopeScaleValue = 3,
            DepthBiasValue = 4,
            LineWidthValue = 5,
            FogColor = 6,
        };
    };
}
