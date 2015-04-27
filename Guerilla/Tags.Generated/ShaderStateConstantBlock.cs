// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderStateConstantBlock : ShaderStateConstantBlockBase
    {
        public  ShaderStateConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ShaderStateConstantBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID sourceParameter;
        internal byte[] invalidName_;
        internal Constant constant;
        
        public override int SerializedSize{get { return 8; }}
        
        internal  ShaderStateConstantBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sourceParameter = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            constant = (Constant)binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sourceParameter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)constant);
                return nextAddress;
            }
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
