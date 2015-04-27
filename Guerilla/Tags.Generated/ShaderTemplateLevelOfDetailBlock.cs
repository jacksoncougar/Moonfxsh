// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplateLevelOfDetailBlock : ShaderTemplateLevelOfDetailBlockBase
    {
        public  ShaderTemplateLevelOfDetailBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderTemplateLevelOfDetailBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderTemplateLevelOfDetailBlockBase : GuerillaBlock
    {
        internal float projectedDiameterPixels;
        internal ShaderTemplatePassReferenceBlock[] pass;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderTemplateLevelOfDetailBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            projectedDiameterPixels = binaryReader.ReadSingle();
            pass = Guerilla.ReadBlockArray<ShaderTemplatePassReferenceBlock>(binaryReader);
        }
        public  ShaderTemplateLevelOfDetailBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            projectedDiameterPixels = binaryReader.ReadSingle();
            pass = Guerilla.ReadBlockArray<ShaderTemplatePassReferenceBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(projectedDiameterPixels);
                nextAddress = Guerilla.WriteBlockArray<ShaderTemplatePassReferenceBlock>(binaryWriter, pass, nextAddress);
                return nextAddress;
            }
        }
    };
}
