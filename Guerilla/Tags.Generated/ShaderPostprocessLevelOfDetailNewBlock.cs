// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessLevelOfDetailNewBlock : ShaderPostprocessLevelOfDetailNewBlockBase
    {
        public  ShaderPostprocessLevelOfDetailNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessLevelOfDetailNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderPostprocessLevelOfDetailNewBlockBase : GuerillaBlock
    {
        internal int availableLayerFlags;
        internal TagBlockIndexStructBlock layers;
        
        public override int SerializedSize{get { return 6; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessLevelOfDetailNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            availableLayerFlags = binaryReader.ReadInt32();
            layers = new TagBlockIndexStructBlock(binaryReader);
        }
        public  ShaderPostprocessLevelOfDetailNewBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            availableLayerFlags = binaryReader.ReadInt32();
            layers = new TagBlockIndexStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
