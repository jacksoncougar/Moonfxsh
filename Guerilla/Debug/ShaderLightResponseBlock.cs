// ReSharper disable All
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
        public  ShaderLightResponseBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderLightResponseBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadShaderTemplateCategoryBlockArray(binaryReader);
            ReadShaderTemplateLevelOfDetailBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
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
        internal  virtual ShaderTemplateCategoryBlock[] ReadShaderTemplateCategoryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateCategoryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateCategoryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateCategoryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTemplateLevelOfDetailBlock[] ReadShaderTemplateLevelOfDetailBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplateLevelOfDetailBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplateLevelOfDetailBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplateLevelOfDetailBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplateCategoryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTemplateLevelOfDetailBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteShaderTemplateCategoryBlockArray(binaryWriter);
                WriteShaderTemplateLevelOfDetailBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
            }
        }
    };
}
