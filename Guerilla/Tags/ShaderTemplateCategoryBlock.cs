using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplateCategoryBlock : ShaderTemplateCategoryBlockBase
    {
        public  ShaderTemplateCategoryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ShaderTemplateCategoryBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal ShaderTemplateParameterBlock[] parameters;
        internal  ShaderTemplateCategoryBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.parameters = ReadShaderTemplateParameterBlockArray(binaryReader);
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
        internal  virtual ShaderTemplateParameterBlock[] ReadShaderTemplateParameterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateParameterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateParameterBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
