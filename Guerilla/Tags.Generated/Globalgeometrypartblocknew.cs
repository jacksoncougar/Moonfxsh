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
    public partial class GlobalGeometryPartBlockNew : GlobalGeometryPartBlockNewBase
    {
        public GlobalGeometryPartBlockNew() : base()
        {
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class GlobalGeometryPartBlockNewBase : GuerillaBlock
    {
        internal Type type;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 material;
        internal short stripStartIndex;
        internal short stripLength;
        internal short firstSubpartIndex;
        internal short subpartCount;
        internal byte maxNodesVertex;
        internal byte contributingCompoundNodeCount;
        internal OpenTK.Vector3 position;
        internal NodeIndices[] nodeIndices;
        internal NodeWeights[] nodeWeights;
        internal float lodMipmapMagicNumber;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 72; } }
        public override int Alignment { get { return 4; } }
        public GlobalGeometryPartBlockNewBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            material = binaryReader.ReadShortBlockIndex1();
            stripStartIndex = binaryReader.ReadInt16();
            stripLength = binaryReader.ReadInt16();
            firstSubpartIndex = binaryReader.ReadInt16();
            subpartCount = binaryReader.ReadInt16();
            maxNodesVertex = binaryReader.ReadByte();
            contributingCompoundNodeCount = binaryReader.ReadByte();
            position = binaryReader.ReadVector3();
            nodeIndices = new []{ new NodeIndices(), new NodeIndices(), new NodeIndices(), new NodeIndices() };
            blamPointers.Concat(nodeIndices[0].ReadFields(binaryReader));
            blamPointers.Concat(nodeIndices[1].ReadFields(binaryReader));
            blamPointers.Concat(nodeIndices[2].ReadFields(binaryReader));
            blamPointers.Concat(nodeIndices[3].ReadFields(binaryReader));
            nodeWeights = new []{ new NodeWeights(), new NodeWeights(), new NodeWeights() };
            blamPointers.Concat(nodeWeights[0].ReadFields(binaryReader));
            blamPointers.Concat(nodeWeights[1].ReadFields(binaryReader));
            blamPointers.Concat(nodeWeights[2].ReadFields(binaryReader));
            lodMipmapMagicNumber = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            nodeIndices = ReadBlockArrayData<NodeIndices>(binaryReader, blamPointers.Dequeue());
            nodeWeights = ReadBlockArrayData<NodeWeights>(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(material);
                binaryWriter.Write(stripStartIndex);
                binaryWriter.Write(stripLength);
                binaryWriter.Write(firstSubpartIndex);
                binaryWriter.Write(subpartCount);
                binaryWriter.Write(maxNodesVertex);
                binaryWriter.Write(contributingCompoundNodeCount);
                binaryWriter.Write(position);
                nodeIndices[0].Write(binaryWriter);
                nodeIndices[1].Write(binaryWriter);
                nodeIndices[2].Write(binaryWriter);
                nodeIndices[3].Write(binaryWriter);
                nodeWeights[0].Write(binaryWriter);
                nodeWeights[1].Write(binaryWriter);
                nodeWeights[2].Write(binaryWriter);
                binaryWriter.Write(lodMipmapMagicNumber);
                binaryWriter.Write(invalidName_, 0, 24);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            NotDrawn = 0,
            OpaqueShadowOnly = 1,
            OpaqueShadowCasting = 2,
            OpaqueNonshadowing = 3,
            Transparent = 4,
            LightmapOnly = 5,
        };
        [FlagsAttribute]
        internal enum Flags : short
        {
            Decalable = 1,
            NewPartTypes = 2,
            DislikesPhotons = 4,
            OverrideTriangleList = 8,
            IgnoredByLightmapper = 16,
        };
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
