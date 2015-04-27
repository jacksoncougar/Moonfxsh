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
        public static readonly TagClass Slit = (TagClass)"slit";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("slit")]
    public partial class ShaderLightResponseBlock : ShaderLightResponseBlockBase
    {
        public  ShaderLightResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderLightResponseBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ShaderLightResponseBlockBase : GuerillaBlock
    {
        internal ShaderTemplateCategoryBlock[] categories;
        internal ShaderTemplateLevelOfDetailBlock[] shaderLODs;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderLightResponseBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            categories = Guerilla.ReadBlockArray<ShaderTemplateCategoryBlock>(binaryReader);
            shaderLODs = Guerilla.ReadBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
        }
        public  ShaderLightResponseBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            categories = Guerilla.ReadBlockArray<ShaderTemplateCategoryBlock>(binaryReader);
            shaderLODs = Guerilla.ReadBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateCategoryBlock>(binaryWriter, categories, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplateLevelOfDetailBlock>(binaryWriter, shaderLODs, nextAddress);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress;
            }
        }
    };
}
