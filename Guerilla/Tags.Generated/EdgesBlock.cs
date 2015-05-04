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
    public partial class EdgesBlock : EdgesBlockBase
    {
        public EdgesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class EdgesBlockBase : GuerillaBlock
    {
        internal short startVertex;
        internal short endVertex;
        internal short forwardEdge;
        internal short reverseEdge;
        internal short leftSurface;
        internal short rightSurface;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public EdgesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            startVertex = binaryReader.ReadInt16();
            endVertex = binaryReader.ReadInt16();
            forwardEdge = binaryReader.ReadInt16();
            reverseEdge = binaryReader.ReadInt16();
            leftSurface = binaryReader.ReadInt16();
            rightSurface = binaryReader.ReadInt16();
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
                binaryWriter.Write(startVertex);
                binaryWriter.Write(endVertex);
                binaryWriter.Write(forwardEdge);
                binaryWriter.Write(reverseEdge);
                binaryWriter.Write(leftSurface);
                binaryWriter.Write(rightSurface);
                return nextAddress;
            }
        }
    };
}