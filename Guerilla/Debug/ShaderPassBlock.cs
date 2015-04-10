// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("spas")]
    public  partial class ShaderPassBlock : ShaderPassBlockBase
    {
        public  ShaderPassBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class ShaderPassBlockBase
    {
        internal byte[] documentation;
        internal ShaderPassParameterBlock[] parameters;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal ShaderPassImplementationBlock[] implementations;
        internal ShaderPassPostprocessDefinitionNewBlock[] postprocessDefinition;
        internal  ShaderPassBlockBase(System.IO.BinaryReader binaryReader)
        {
            documentation = ReadData(binaryReader);
            ReadShaderPassParameterBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            ReadShaderPassImplementationBlockArray(binaryReader);
            ReadShaderPassPostprocessDefinitionNewBlockArray(binaryReader);
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
        internal  virtual ShaderPassParameterBlock[] ReadShaderPassParameterBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassParameterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassParameterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassImplementationBlock[] ReadShaderPassImplementationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassImplementationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassImplementationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassImplementationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPassPostprocessDefinitionNewBlock[] ReadShaderPassPostprocessDefinitionNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPassPostprocessDefinitionNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPassPostprocessDefinitionNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPassPostprocessDefinitionNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPassParameterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPassImplementationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPassPostprocessDefinitionNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteData(binaryWriter);
                WriteShaderPassParameterBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                WriteShaderPassImplementationBlockArray(binaryWriter);
                WriteShaderPassPostprocessDefinitionNewBlockArray(binaryWriter);
            }
        }
    };
}
