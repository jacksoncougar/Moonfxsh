// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPassPostprocessConstantInfoNewBlock : ShaderPassPostprocessConstantInfoNewBlockBase
    {
        public  ShaderPassPostprocessConstantInfoNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 7, Alignment = 4)]
    public class ShaderPassPostprocessConstantInfoNewBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID parameterName;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 7; }}
        
        internal  ShaderPassPostprocessConstantInfoNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parameterName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(3);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterName);
                binaryWriter.Write(invalidName_, 0, 3);
                return nextAddress;
            }
        }
    };
}
