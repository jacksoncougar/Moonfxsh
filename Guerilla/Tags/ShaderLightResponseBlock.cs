// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass SlitClass = (TagClass)"slit";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("slit")]
    public  partial class ShaderLightResponseBlock : ShaderLightResponseBlockBase
    {
        public  ShaderLightResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ShaderLightResponseBlockBase  : IGuerilla
    {
        internal ShaderTemplateCategoryBlock[] categories;
        internal ShaderTemplateLevelOfDetailBlock[] shaderLODs;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  ShaderLightResponseBlockBase(BinaryReader binaryReader)
        {
            categories = Guerilla.ReadBlockArray<ShaderTemplateCategoryBlock>(binaryReader);
            shaderLODs = Guerilla.ReadBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateCategoryBlock>(binaryWriter, categories, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryWriter, shaderLODs, nextAddress);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
