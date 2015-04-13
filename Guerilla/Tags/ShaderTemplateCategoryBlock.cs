// ReSharper disable All
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
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderTemplateCategoryBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal ShaderTemplateParameterBlock[] parameters;
        internal  ShaderTemplateCategoryBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            parameters = Guerilla.ReadBlockArray<ShaderTemplateParameterBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                Guerilla.WriteBlockArray<ShaderTemplateParameterBlock>(binaryWriter, parameters, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
