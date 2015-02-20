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
        public  ShaderPassBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPassBlockBase(BinaryReader binaryReader)
        {
            this.documentation = ReadData(binaryReader);
            this.parameters = ReadShaderPassParameterBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.implementations = ReadShaderPassImplementationBlockArray(binaryReader);
            this.postprocessDefinition = ReadShaderPassPostprocessDefinitionNewBlockArray(binaryReader);
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
        internal  virtual ShaderPassParameterBlock[] ReadShaderPassParameterBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderPassImplementationBlock[] ReadShaderPassImplementationBlockArray(BinaryReader binaryReader)
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
        internal  virtual ShaderPassPostprocessDefinitionNewBlock[] ReadShaderPassPostprocessDefinitionNewBlockArray(BinaryReader binaryReader)
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
    };
}
