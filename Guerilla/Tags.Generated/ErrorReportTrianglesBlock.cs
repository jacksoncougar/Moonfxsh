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
    public partial class ErrorReportTrianglesBlock : ErrorReportTrianglesBlockBase
    {
        public ErrorReportTrianglesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 112, Alignment = 4)]
    public class ErrorReportTrianglesBlockBase : GuerillaBlock
    {
        internal Points[] points;
        internal OpenTK.Vector4 color;
        public override int SerializedSize { get { return 112; } }
        public override int Alignment { get { return 4; } }
        public ErrorReportTrianglesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            points = new []{ new Points(), new Points(), new Points() };
            blamPointers.Concat(points[0].ReadFields(binaryReader));
            blamPointers.Concat(points[1].ReadFields(binaryReader));
            blamPointers.Concat(points[2].ReadFields(binaryReader));
            color = binaryReader.ReadVector4();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            points = ReadBlockArrayData<Points>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                points[0].Write(binaryWriter);
                points[1].Write(binaryWriter);
                points[2].Write(binaryWriter);
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
        [LayoutAttribute(Size = 32, Alignment = 1)]
        public class Points : GuerillaBlock
        {
            internal OpenTK.Vector3 position;
            internal NodeIndices[] nodeIndices;
            internal NodeWeights[] nodeWeights;
            public override int SerializedSize { get { return 32; } }
            public override int Alignment { get { return 1; } }
            public Points() : base()
            {
            }
            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
    };
}
