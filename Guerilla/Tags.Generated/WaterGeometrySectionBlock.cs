// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class WaterGeometrySectionBlock : WaterGeometrySectionBlockBase
    {
        public WaterGeometrySectionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class WaterGeometrySectionBlockBase : GuerillaBlock
    {
        internal GlobalGeometrySectionStructBlock section;

        public override int SerializedSize
        {
            get { return 68; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public WaterGeometrySectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            section = new GlobalGeometrySectionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(section.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            section.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                section.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}