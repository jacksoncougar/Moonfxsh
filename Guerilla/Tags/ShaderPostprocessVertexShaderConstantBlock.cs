using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessVertexShaderConstantBlock : ShaderPostprocessVertexShaderConstantBlockBase
    {
        public  ShaderPostprocessVertexShaderConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 18)]
    public class ShaderPostprocessVertexShaderConstantBlockBase
    {
        internal byte registerIndex;
        internal byte registerBank;
        internal float data;
        internal float data0;
        internal float data1;
        internal float data2;
        internal  ShaderPostprocessVertexShaderConstantBlockBase(BinaryReader binaryReader)
        {
            this.registerIndex = binaryReader.ReadByte();
            this.registerBank = binaryReader.ReadByte();
            this.data = binaryReader.ReadSingle();
            this.data0 = binaryReader.ReadSingle();
            this.data1 = binaryReader.ReadSingle();
            this.data2 = binaryReader.ReadSingle();
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
