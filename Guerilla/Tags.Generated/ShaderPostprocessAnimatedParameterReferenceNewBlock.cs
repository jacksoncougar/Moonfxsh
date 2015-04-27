// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessAnimatedParameterReferenceNewBlock : ShaderPostprocessAnimatedParameterReferenceNewBlockBase
    {
        public  ShaderPostprocessAnimatedParameterReferenceNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessAnimatedParameterReferenceNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPostprocessAnimatedParameterReferenceNewBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal byte parameterIndex;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessAnimatedParameterReferenceNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(3);
            parameterIndex = binaryReader.ReadByte();
        }
        public  ShaderPostprocessAnimatedParameterReferenceNewBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(3);
            parameterIndex = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(parameterIndex);
                return nextAddress;
            }
        }
    };
}
