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
    public partial class RenderModelCompoundNodeBlock : RenderModelCompoundNodeBlockBase
    {
        public RenderModelCompoundNodeBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class RenderModelCompoundNodeBlockBase : GuerillaBlock
    {
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderModelCompoundNodeBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            nodeIndices = new[] {new NodeIndices(), new NodeIndices(), new NodeIndices(), new NodeIndices()};
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndices[3].ReadFields(binaryReader)));
            nodeWeights = new[] {new NodeWeights(), new NodeWeights(), new NodeWeights()};
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[2].ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            nodeIndices[0].ReadPointers(binaryReader, blamPointers);
            nodeIndices[1].ReadPointers(binaryReader, blamPointers);
            nodeIndices[2].ReadPointers(binaryReader, blamPointers);
            nodeIndices[3].ReadPointers(binaryReader, blamPointers);
            nodeWeights[0].ReadPointers(binaryReader, blamPointers);
            nodeWeights[1].ReadPointers(binaryReader, blamPointers);
            nodeWeights[2].ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nodeIndices[0].Write(binaryWriter);
                nodeIndices[1].Write(binaryWriter);
                nodeIndices[2].Write(binaryWriter);
                nodeIndices[3].Write(binaryWriter);
                nodeWeights[0].Write(binaryWriter);
                nodeWeights[1].Write(binaryWriter);
                nodeWeights[2].Write(binaryWriter);
                return nextAddress;
            }
        }

        [LayoutAttribute(Size = 1, Alignment = 1)]
        public class NodeIndices : GuerillaBlock
        {
            internal byte nodeIndex;

            public override int SerializedSize
            {
                get { return 1; }
            }

            public override int Alignment
            {
                get { return 1; }
            }

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
                using (binaryWriter.BaseStream.Pin())
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
    };
}