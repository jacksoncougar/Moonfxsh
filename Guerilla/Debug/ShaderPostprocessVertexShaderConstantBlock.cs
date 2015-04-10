// ReSharper disable All
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
        public  ShaderPostprocessVertexShaderConstantBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPostprocessVertexShaderConstantBlockBase(System.IO.BinaryReader binaryReader)
        {
            registerIndex = binaryReader.ReadByte();
            registerBank = binaryReader.ReadByte();
            data = binaryReader.ReadSingle();
            data0 = binaryReader.ReadSingle();
            data1 = binaryReader.ReadSingle();
            data2 = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(registerIndex);
                binaryWriter.Write(registerBank);
                binaryWriter.Write(data);
                binaryWriter.Write(data0);
                binaryWriter.Write(data1);
                binaryWriter.Write(data2);
            }
        }
    };
}
