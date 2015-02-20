using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VertexShaderConstantBlock : VertexShaderConstantBlockBase
    {
        public  VertexShaderConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class VertexShaderConstantBlockBase
    {
        internal byte registerIndex;
        internal byte parameterIndex;
        internal byte destinationMask;
        internal byte scaleByTextureStage;
        internal  VertexShaderConstantBlockBase(BinaryReader binaryReader)
        {
            this.registerIndex = binaryReader.ReadByte();
            this.parameterIndex = binaryReader.ReadByte();
            this.destinationMask = binaryReader.ReadByte();
            this.scaleByTextureStage = binaryReader.ReadByte();
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
