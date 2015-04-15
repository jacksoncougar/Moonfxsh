// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessLevelOfDetailNewBlock : ShaderPostprocessLevelOfDetailNewBlockBase
    {
        public  ShaderPostprocessLevelOfDetailNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderPostprocessLevelOfDetailNewBlockBase  : IGuerilla
    {
        internal int availableLayerFlags;
        internal TagBlockIndexStructBlock layers;
        internal  ShaderPostprocessLevelOfDetailNewBlockBase(BinaryReader binaryReader)
        {
            availableLayerFlags = binaryReader.ReadInt32();
            layers = new TagBlockIndexStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(availableLayerFlags);
                layers.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
