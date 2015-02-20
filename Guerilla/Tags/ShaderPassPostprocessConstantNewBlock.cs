using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassPostprocessConstantNewBlock : ShaderPassPostprocessConstantNewBlockBase
    {
        public  ShaderPassPostprocessConstantNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 7)]
    public class ShaderPassPostprocessConstantNewBlockBase
    {
        internal Moonfish.Tags.StringID parameterName;
        internal byte componentMask;
        internal byte scaleByTextureStage;
        internal byte functionIndex;
        internal  ShaderPassPostprocessConstantNewBlockBase(BinaryReader binaryReader)
        {
            this.parameterName = binaryReader.ReadStringID();
            this.componentMask = binaryReader.ReadByte();
            this.scaleByTextureStage = binaryReader.ReadByte();
            this.functionIndex = binaryReader.ReadByte();
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
