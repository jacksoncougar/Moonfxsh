// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessLevelOfDetailNewBlock : ShaderPostprocessLevelOfDetailNewBlockBase
    {
        public ShaderPostprocessLevelOfDetailNewBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderPostprocessLevelOfDetailNewBlockBase : GuerillaBlock
    {
        internal int availableLayerFlags;
        internal TagBlockIndexStructBlock layers;
        public override int SerializedSize { get { return 6; } }
        public override int Alignment { get { return 4; } }
        public ShaderPostprocessLevelOfDetailNewBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            availableLayerFlags = binaryReader.ReadInt32();
            layers = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(layers.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            layers.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(availableLayerFlags);
                layers.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
