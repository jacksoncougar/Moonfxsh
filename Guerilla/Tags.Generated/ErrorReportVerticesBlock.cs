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
    public partial class ErrorReportVerticesBlock : ErrorReportVerticesBlockBase
    {
        public ErrorReportVerticesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ErrorReportVerticesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;
        internal OpenTK.Vector4 color;
        internal float screenSize;
        public override int SerializedSize { get { return 52; } }
        public override int Alignment { get { return 4; } }
        public ErrorReportVerticesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            nodeIndices = new []{ new NodeIndices(), new NodeIndices(), new NodeIndices(), new NodeIndices() };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[3].ReadFields(binaryReader)));
            nodeWeights = new []{ new NodeWeights(), new NodeWeights(), new NodeWeights(), new NodeWeights() };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[3].ReadFields(binaryReader)));
            color = binaryReader.ReadVector4();
            screenSize = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            nodeIndices = ReadBlockArrayData<NodeIndices>(binaryReader, blamPointers.Dequeue());
            nodeWeights = ReadBlockArrayData<NodeWeights>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                nodeIndices[0].Write(binaryWriter);
                nodeIndices[1].Write(binaryWriter);
                nodeIndices[2].Write(binaryWriter);
                nodeIndices[3].Write(binaryWriter);
                nodeWeights[0].Write(binaryWriter);
                nodeWeights[1].Write(binaryWriter);
                nodeWeights[2].Write(binaryWriter);
                nodeWeights[3].Write(binaryWriter);
                binaryWriter.Write(color);
                binaryWriter.Write(screenSize);
                return nextAddress;
            }
        }
        [LayoutAttribute(Size = 1, Alignment = 1)]
        public class NodeIndices : GuerillaBlock
        {
            internal byte nodeIndex;
            public override int SerializedSize { get { return 1; } }
            public override int Alignment { get { return 1; } }
            public NodeIndices() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                nodeIndex = binaryReader.ReadByte();
                return blamPointers;
            }
            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }
            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeIndex);
                    return nextAddress;
                }
            }
        };
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class NodeWeights : GuerillaBlock
        {
            internal float nodeWeight;
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
            public NodeWeights() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                nodeWeight = binaryReader.ReadSingle();
                return blamPointers;
            }
            public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
            {
                base.ReadPointers(binaryReader, blamPointers);
            }
            public override int Write(BinaryWriter binaryWriter, int nextAddress)
            {
                base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeWeight);
                    return nextAddress;
                }
            }
        };
    };
}
