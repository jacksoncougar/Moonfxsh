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
        public  ShaderTemplatePostprocessDefinitionNewBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderTemplatePostprocessDefinitionNewBlockBase(BinaryReader binaryReader)
        {
            this.levelsOfDetail = ReadShaderTemplatePostprocessLevelOfDetailNewBlockArray(binaryReader);
            this.layers = ReadTagBlockIndexBlockArray(binaryReader);
            this.passes = ReadShaderTemplatePostprocessPassNewBlockArray(binaryReader);
            this.implementations = ReadShaderTemplatePostprocessImplementationNewBlockArray(binaryReader);
            this.remappings = ReadShaderTemplatePostprocessRemappingNewBlockArray(binaryReader);
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
        internal  virtual ShaderTemplatePostprocessLevelOfDetailNewBlock[] ReadShaderTemplatePostprocessLevelOfDetailNewBlockArray(BinaryReader binaryReader)
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
        internal  virtual TagBlockIndexBlock[] ReadTagBlockIndexBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderTemplatePostprocessPassNewBlock[] ReadShaderTemplatePostprocessPassNewBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderTemplatePostprocessImplementationNewBlock[] ReadShaderTemplatePostprocessImplementationNewBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderTemplatePostprocessRemappingNewBlock[] ReadShaderTemplatePostprocessRemappingNewBlockArray(BinaryReader binaryReader)
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
    };
}
