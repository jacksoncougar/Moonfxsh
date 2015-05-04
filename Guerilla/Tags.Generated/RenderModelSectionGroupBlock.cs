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
    public partial class RenderModelSectionGroupBlock : RenderModelSectionGroupBlockBase
    {
        public RenderModelSectionGroupBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class RenderModelSectionGroupBlockBase : GuerillaBlock
    {
        internal DetailLevels detailLevels;
        internal byte[] invalidName_;
        internal RenderModelCompoundNodeBlock[] compoundNodes;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderModelSectionGroupBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            detailLevels = (DetailLevels) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<RenderModelCompoundNodeBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            compoundNodes = ReadBlockArrayData<RenderModelCompoundNodeBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) detailLevels);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<RenderModelCompoundNodeBlock>(binaryWriter, compoundNodes,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum DetailLevels : short
        {
            L1SuperLow = 1,
            L2Low = 2,
            L3Medium = 4,
            L4High = 8,
            L5SuperHigh = 16,
            L6Hollywood = 32,
        };
    };
}