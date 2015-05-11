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
    public partial class StructureBspPathfindingEdgesBlock : StructureBspPathfindingEdgesBlockBase
    {
        public StructureBspPathfindingEdgesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class StructureBspPathfindingEdgesBlockBase : GuerillaBlock
    {
        internal byte midpoint;

        public override int SerializedSize
        {
            get { return 1; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspPathfindingEdgesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            midpoint = binaryReader.ReadByte();
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
                binaryWriter.Write(midpoint);
                return nextAddress;
            }
        }
    };
}