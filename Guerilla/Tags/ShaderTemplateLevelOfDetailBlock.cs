using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplateLevelOfDetailBlock : ShaderTemplateLevelOfDetailBlockBase
    {
        public  ShaderTemplateLevelOfDetailBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ShaderTemplateLevelOfDetailBlockBase
    {
        internal float projectedDiameterPixels;
        internal ShaderTemplatePassReferenceBlock[] pass;
        internal  ShaderTemplateLevelOfDetailBlockBase(BinaryReader binaryReader)
        {
            this.projectedDiameterPixels = binaryReader.ReadSingle();
            this.pass = ReadShaderTemplatePassReferenceBlockArray(binaryReader);
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
        internal  virtual ShaderTemplatePassReferenceBlock[] ReadShaderTemplatePassReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTemplatePassReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTemplatePassReferenceBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTemplatePassReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
