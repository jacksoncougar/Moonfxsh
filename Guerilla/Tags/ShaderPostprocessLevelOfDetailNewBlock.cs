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
    [LayoutAttribute(Size = 6)]
    public class ShaderPostprocessLevelOfDetailNewBlockBase
    {
        internal int availableLayerFlags;
        internal TagBlockIndexStructBlock layers;
        internal  ShaderPostprocessLevelOfDetailNewBlockBase(BinaryReader binaryReader)
        {
            this.availableLayerFlags = binaryReader.ReadInt32();
            this.layers = new TagBlockIndexStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
