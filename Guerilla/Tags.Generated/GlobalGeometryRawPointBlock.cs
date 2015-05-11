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
    public partial class GlobalGeometryRawPointBlock : GlobalGeometryRawPointBlockBase
    {
        public GlobalGeometryRawPointBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 68, Alignment = 4)]
    public class GlobalGeometryRawPointBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal NodeIndicesOLD[] nodeIndicesOLD;
        internal NodeWeights[] nodeWeights;
        internal NodeIndicesNEW[] nodeIndicesNEW;
        internal int useNewNodeIndices;
        internal int adjustedCompoundNodeIndex;

        public override int SerializedSize
        {
            get { return 68; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalGeometryRawPointBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            nodeIndicesOLD = new[]
            {new NodeIndicesOLD(), new NodeIndicesOLD(), new NodeIndicesOLD(), new NodeIndicesOLD()};
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[3].ReadFields(binaryReader)));
            nodeWeights = new[] {new NodeWeights(), new NodeWeights(), new NodeWeights(), new NodeWeights()};
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[3].ReadFields(binaryReader)));
            nodeIndicesNEW = new[]
            {new NodeIndicesNEW(), new NodeIndicesNEW(), new NodeIndicesNEW(), new NodeIndicesNEW()};
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[3].ReadFields(binaryReader)));
            useNewNodeIndices = binaryReader.ReadInt32();
            adjustedCompoundNodeIndex = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            nodeIndicesOLD[0].ReadPointers(binaryReader, blamPointers);
            nodeIndicesOLD[1].ReadPointers(binaryReader, blamPointers);
            nodeIndicesOLD[2].ReadPointers(binaryReader, blamPointers);
            nodeIndicesOLD[3].ReadPointers(binaryReader, blamPointers);
            nodeWeights[0].ReadPointers(binaryReader, blamPointers);
            nodeWeights[1].ReadPointers(binaryReader, blamPointers);
            nodeWeights[2].ReadPointers(binaryReader, blamPointers);
            nodeWeights[3].ReadPointers(binaryReader, blamPointers);
            nodeIndicesNEW[0].ReadPointers(binaryReader, blamPointers);
            nodeIndicesNEW[1].ReadPointers(binaryReader, blamPointers);
            nodeIndicesNEW[2].ReadPointers(binaryReader, blamPointers);
            nodeIndicesNEW[3].ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                nodeIndicesOLD[0].Write(binaryWriter);
                nodeIndicesOLD[1].Write(binaryWriter);
                nodeIndicesOLD[2].Write(binaryWriter);
                nodeIndicesOLD[3].Write(binaryWriter);
                nodeWeights[0].Write(binaryWriter);
                nodeWeights[1].Write(binaryWriter);
                nodeWeights[2].Write(binaryWriter);
                nodeWeights[3].Write(binaryWriter);
                nodeIndicesNEW[0].Write(binaryWriter);
                nodeIndicesNEW[1].Write(binaryWriter);
                nodeIndicesNEW[2].Write(binaryWriter);
                nodeIndicesNEW[3].Write(binaryWriter);
                binaryWriter.Write(useNewNodeIndices);
                binaryWriter.Write(adjustedCompoundNodeIndex);
                return nextAddress;
            }
        }

        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class NodeIndicesOLD : GuerillaBlock
        {
            internal int nodeIndexOLD;

            public override int SerializedSize
            {
                get { return 4; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public NodeIndicesOLD() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                nodeIndexOLD = binaryReader.ReadInt32();
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
                    binaryWriter.Write(nodeIndexOLD);
                    return nextAddress;
                }
            }
        };

        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class NodeWeights : GuerillaBlock
        {
            internal float nodeWeight;

            public override int SerializedSize
            {
                get { return 4; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

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
                using (binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeWeight);
                    return nextAddress;
                }
            }
        };

        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class NodeIndicesNEW : GuerillaBlock
        {
            internal int nodeIndexNEW;

            public override int SerializedSize
            {
                get { return 4; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

            public NodeIndicesNEW() : base()
            {
            }

            public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
            {
                var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
                nodeIndexNEW = binaryReader.ReadInt32();
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
                    binaryWriter.Write(nodeIndexNEW);
                    return nextAddress;
                }
            }
        };
    };
}