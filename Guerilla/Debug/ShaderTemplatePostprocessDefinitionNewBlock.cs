// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplatePostprocessDefinitionNewBlock : ShaderTemplatePostprocessDefinitionNewBlockBase
    {
        public  ShaderTemplatePostprocessDefinitionNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class ShaderTemplatePostprocessDefinitionNewBlockBase
    {
        internal ShaderTemplatePostprocessLevelOfDetailNewBlock[] levelsOfDetail;
        internal TagBlockIndexBlock[] layers;
        internal ShaderTemplatePostprocessPassNewBlock[] passes;
        internal ShaderTemplatePostprocessImplementationNewBlock[] implementations;
        internal ShaderTemplatePostprocessRemappingNewBlock[] remappings;
        internal  ShaderTemplatePostprocessDefinitionNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadShaderTemplatePostprocessLevelOfDetailNewBlockArray(binaryReader);
            ReadTagBlockIndexBlockArray(binaryReader);
            ReadShaderTemplatePostprocessPassNewBlockArray(binaryReader);
            ReadShaderTemplatePostprocessImplementationNewBlockArray(binaryReader);
            ReadShaderTemplatePostprocessRemappingNewBlockArray(binaryReader);
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
        internal  virtual ShaderTemplatePostprocessLevelOfDetailNewBlock[] ReadShaderTemplatePostprocessLevelOfDetailNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplatePostprocessLevelOfDetailNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplatePostprocessLevelOfDetailNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplatePostprocessLevelOfDetailNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TagBlockIndexBlock[] ReadTagBlockIndexBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TagBlockIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TagBlockIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TagBlockIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplatePostprocessPassNewBlock[] ReadShaderTemplatePostprocessPassNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplatePostprocessPassNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplatePostprocessPassNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplatePostprocessPassNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplatePostprocessImplementationNewBlock[] ReadShaderTemplatePostprocessImplementationNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplatePostprocessImplementationNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplatePostprocessImplementationNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplatePostprocessImplementationNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplatePostprocessRemappingNewBlock[] ReadShaderTemplatePostprocessRemappingNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplatePostprocessRemappingNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplatePostprocessRemappingNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplatePostprocessRemappingNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplatePostprocessLevelOfDetailNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTagBlockIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplatePostprocessPassNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplatePostprocessImplementationNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplatePostprocessRemappingNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteShaderTemplatePostprocessLevelOfDetailNewBlockArray(binaryWriter);
                WriteTagBlockIndexBlockArray(binaryWriter);
                WriteShaderTemplatePostprocessPassNewBlockArray(binaryWriter);
                WriteShaderTemplatePostprocessImplementationNewBlockArray(binaryWriter);
                WriteShaderTemplatePostprocessRemappingNewBlockArray(binaryWriter);
            }
        }
    };
}
