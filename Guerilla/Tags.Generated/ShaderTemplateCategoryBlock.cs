// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplateCategoryBlock : ShaderTemplateCategoryBlockBase
    {
        public  ShaderTemplateCategoryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderTemplateCategoryBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal ShaderTemplateParameterBlock[] parameters;
        
        public override int SerializedSize{get { return 12; }}
        
        internal  ShaderTemplateCategoryBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            parameters = Guerilla.ReadBlockArray<ShaderTemplateParameterBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateParameterBlock>(binaryWriter, parameters, nextAddress);
                return nextAddress;
            }
        }
    };
}
