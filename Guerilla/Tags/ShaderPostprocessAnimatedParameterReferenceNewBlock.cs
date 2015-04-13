// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessAnimatedParameterReferenceNewBlock : ShaderPostprocessAnimatedParameterReferenceNewBlockBase
    {
        public  ShaderPostprocessAnimatedParameterReferenceNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPostprocessAnimatedParameterReferenceNewBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal byte parameterIndex;
        internal  ShaderPostprocessAnimatedParameterReferenceNewBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(3);
            parameterIndex = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 3);
                binaryWriter.Write(parameterIndex);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
