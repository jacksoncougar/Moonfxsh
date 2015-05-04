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
    public partial class ErrorReportCommentsBlock : ErrorReportCommentsBlockBase
    {
        public ErrorReportCommentsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ErrorReportCommentsBlockBase : GuerillaBlock
    {
        internal byte[] text;
        internal OpenTK.Vector3 position;
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;
        internal OpenTK.Vector4 color;
        public override int SerializedSize { get { return 56; } }
        public override int Alignment { get { return 4; } }
        public ErrorReportCommentsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            position = binaryReader.ReadVector3();
            nodeIndices = new []{ new NodeIndices(), new NodeIndices(), new NodeIndices(), new NodeIndices() };
            blamPointers.Concat(nodeIndices[0].ReadFields(binaryReader));
            blamPointers.Concat(nodeIndices[1].ReadFields(binaryReader));
            blamPointers.Concat(nodeIndices[2].ReadFields(binaryReader));
            blamPointers.Concat(nodeIndices[3].ReadFields(binaryReader));
            nodeWeights = new []{ new NodeWeights(), new NodeWeights(), new NodeWeights(), new NodeWeights() };
            blamPointers.Concat(nodeWeights[0].ReadFields(binaryReader));
            blamPointers.Concat(nodeWeights[1].ReadFields(binaryReader));
            blamPointers.Concat(nodeWeights[2].ReadFields(binaryReader));
            blamPointers.Concat(nodeWeights[3].ReadFields(binaryReader));
            color = binaryReader.ReadVector4();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            text = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            nodeIndices = ReadBlockArrayData<NodeIndices>(binaryReader, blamPointers.Dequeue());
            nodeWeights = ReadBlockArrayData<NodeWeights>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, text, nextAddress);
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
