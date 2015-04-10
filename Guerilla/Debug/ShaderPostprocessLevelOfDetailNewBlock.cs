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
        public  ShaderPostprocessLevelOfDetailNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 6)]
    public class ShaderPostprocessLevelOfDetailNewBlockBase
    {
        internal int availableLayerFlags;
        internal TagBlockIndexStructBlock layers;
        internal  ShaderPostprocessLevelOfDetailNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            availableLayerFlags = binaryReader.ReadInt32();
            layers = new TagBlockIndexStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(availableLayerFlags);
                layers.Write(binaryWriter);
            }
        }
    };
}
