// ReSharper disable All
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
        public  ShaderPassPostprocessConstantNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPassPostprocessConstantNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            parameterName = binaryReader.ReadStringID();
            componentMask = binaryReader.ReadByte();
            scaleByTextureStage = binaryReader.ReadByte();
            functionIndex = binaryReader.ReadByte();
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
                binaryWriter.Write(parameterName);
                binaryWriter.Write(componentMask);
                binaryWriter.Write(scaleByTextureStage);
                binaryWriter.Write(functionIndex);
            }
        }
    };
}
