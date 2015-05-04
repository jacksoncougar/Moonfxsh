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
    public partial class TagBlockIndexBlock : TagBlockIndexBlockBase
    {
        public TagBlockIndexBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class TagBlockIndexBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock indices;
        public override int SerializedSize { get { return 2; } }
        public override int Alignment { get { return 4; } }
        public TagBlockIndexBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            indices = new TagBlockIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(indices.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            indices.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                indices.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
