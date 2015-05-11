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
    public partial class RenderModelRegionBlock : RenderModelRegionBlockBase
    {
        public RenderModelRegionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class RenderModelRegionBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal short nodeMapOffsetOLD;
        internal short nodeMapSizeOLD;
        internal RenderModelPermutationBlock[] permutations;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderModelRegionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            nodeMapOffsetOLD = binaryReader.ReadInt16();
            nodeMapSizeOLD = binaryReader.ReadInt16();
            blamPointers.Enqueue(ReadBlockArrayPointer<RenderModelPermutationBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            permutations = ReadBlockArrayData<RenderModelPermutationBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(nodeMapOffsetOLD);
                binaryWriter.Write(nodeMapSizeOLD);
                nextAddress = Guerilla.WriteBlockArray<RenderModelPermutationBlock>(binaryWriter, permutations,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}