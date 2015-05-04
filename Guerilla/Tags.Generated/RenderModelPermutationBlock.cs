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
    public partial class RenderModelPermutationBlock : RenderModelPermutationBlockBase
    {
        public RenderModelPermutationBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class RenderModelPermutationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal short l1SectionIndexSuperLow;
        internal short l2SectionIndexLow;
        internal short l3SectionIndexMedium;
        internal short l4SectionIndexHigh;
        internal short l5SectionIndexSuperHigh;
        internal short l6SectionIndexHollywood;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderModelPermutationBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            l1SectionIndexSuperLow = binaryReader.ReadInt16();
            l2SectionIndexLow = binaryReader.ReadInt16();
            l3SectionIndexMedium = binaryReader.ReadInt16();
            l4SectionIndexHigh = binaryReader.ReadInt16();
            l5SectionIndexSuperHigh = binaryReader.ReadInt16();
            l6SectionIndexHollywood = binaryReader.ReadInt16();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(l1SectionIndexSuperLow);
                binaryWriter.Write(l2SectionIndexLow);
                binaryWriter.Write(l3SectionIndexMedium);
                binaryWriter.Write(l4SectionIndexHigh);
                binaryWriter.Write(l5SectionIndexSuperHigh);
                binaryWriter.Write(l6SectionIndexHollywood);
                return nextAddress;
            }
        }
    };
}