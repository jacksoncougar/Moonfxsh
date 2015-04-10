using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassPostprocessConstantInfoNewBlock : ShaderPassPostprocessConstantInfoNewBlockBase
    {
        public  ShaderPassPostprocessConstantInfoNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 7)]
    public class ShaderPassPostprocessConstantInfoNewBlockBase
    {
        internal Moonfish.Tags.StringID parameterName;
        internal byte[] invalidName_;
        internal  ShaderPassPostprocessConstantInfoNewBlockBase(BinaryReader binaryReader)
        {
            this.parameterName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(3);
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
    };
}
