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
    public partial class ShaderTemplatePostprocessLevelOfDetailNewBlock : ShaderTemplatePostprocessLevelOfDetailNewBlockBase
    {
        public ShaderTemplatePostprocessLevelOfDetailNewBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderTemplatePostprocessLevelOfDetailNewBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock layers;
        internal int availableLayers;
        internal float projectedHeightPercentage;
        public override int SerializedSize { get { return 10; } }
        public override int Alignment { get { return 4; } }
        public ShaderTemplatePostprocessLevelOfDetailNewBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            layers = new TagBlockIndexStructBlock();
            blamPointers.Concat(layers.ReadFields(binaryReader));
            availableLayers = binaryReader.ReadInt32();
            projectedHeightPercentage = binaryReader.ReadSingle();
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
                layers.Write(binaryWriter);
                binaryWriter.Write(availableLayers);
                binaryWriter.Write(projectedHeightPercentage);
                return nextAddress;
            }
        }
    };
}
