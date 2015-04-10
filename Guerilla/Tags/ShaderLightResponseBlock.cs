using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("slit")]
    public  partial class ShaderLightResponseBlock : ShaderLightResponseBlockBase
    {
        public  ShaderLightResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class ShaderLightResponseBlockBase
    {
        internal ShaderTemplateCategoryBlock[] categories;
        internal ShaderTemplateLevelOfDetailBlock[] shaderLODs;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  ShaderLightResponseBlockBase(BinaryReader binaryReader)
        {
            this.categories = ReadShaderTemplateCategoryBlockArray(binaryReader);
            this.shaderLODs = ReadShaderTemplateLevelOfDetailBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ShaderTemplateCategoryBlock[] ReadShaderTemplateCategoryBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateCategoryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateCategoryBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateCategoryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplateLevelOfDetailBlock[] ReadShaderTemplateLevelOfDetailBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateLevelOfDetailBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateLevelOfDetailBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateLevelOfDetailBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
