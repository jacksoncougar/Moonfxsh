// ReSharper disable All
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
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderTemplateLevelOfDetailBlockBase  : IGuerilla
    {
        internal float projectedDiameterPixels;
        internal ShaderTemplatePassReferenceBlock[] pass;
        internal  ShaderTemplateLevelOfDetailBlockBase(BinaryReader binaryReader)
        {
            projectedDiameterPixels = binaryReader.ReadSingle();
            pass = Guerilla.ReadBlockArray<ShaderTemplatePassReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(projectedDiameterPixels);
                Guerilla.WriteBlockArray<ShaderTemplatePassReferenceBlock>(binaryWriter, pass, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
