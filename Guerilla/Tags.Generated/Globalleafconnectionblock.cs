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
    public partial class GlobalLeafConnectionBlock : GlobalLeafConnectionBlockBase
    {
        public GlobalLeafConnectionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class GlobalLeafConnectionBlockBase : GuerillaBlock
    {
        internal int planeIndex;
        internal int backLeafIndex;
        internal int frontLeafIndex;
        internal LeafConnectionVertexBlock[] vertices;
        internal float area;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalLeafConnectionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            planeIndex = binaryReader.ReadInt32();
            backLeafIndex = binaryReader.ReadInt32();
            frontLeafIndex = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<LeafConnectionVertexBlock>(binaryReader));
            area = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            vertices = ReadBlockArrayData<LeafConnectionVertexBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(planeIndex);
                binaryWriter.Write(backLeafIndex);
                binaryWriter.Write(frontLeafIndex);
                nextAddress = Guerilla.WriteBlockArray<LeafConnectionVertexBlock>(binaryWriter, vertices, nextAddress);
                binaryWriter.Write(area);
                return nextAddress;
            }
        }
    };
}