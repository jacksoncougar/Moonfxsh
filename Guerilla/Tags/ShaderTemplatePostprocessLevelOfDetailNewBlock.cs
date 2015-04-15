// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplatePostprocessLevelOfDetailNewBlock : ShaderTemplatePostprocessLevelOfDetailNewBlockBase
    {
        public  ShaderTemplatePostprocessLevelOfDetailNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderTemplatePostprocessLevelOfDetailNewBlockBase  : IGuerilla
    {
        internal TagBlockIndexStructBlock layers;
        internal int availableLayers;
        internal float projectedHeightPercentage;
        internal  ShaderTemplatePostprocessLevelOfDetailNewBlockBase(BinaryReader binaryReader)
        {
            layers = new TagBlockIndexStructBlock(binaryReader);
            availableLayers = binaryReader.ReadInt32();
            projectedHeightPercentage = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                layers.Write(binaryWriter);
                binaryWriter.Write(availableLayers);
                binaryWriter.Write(projectedHeightPercentage);
                return nextAddress;
            }
        }
    };
}
