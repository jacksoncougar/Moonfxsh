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
    public partial class GlobalGeometrySectionRawVertexBlock : GlobalGeometrySectionRawVertexBlockBase
    {
        public GlobalGeometrySectionRawVertexBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 196, Alignment = 4)]
    public class GlobalGeometrySectionRawVertexBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal NodeIndicesOLD[] nodeIndicesOLD;
        internal NodeWeights[] nodeWeights;
        internal NodeIndicesNEW[] nodeIndicesNEW;
        internal int useNewNodeIndices;
        internal int adjustedCompoundNodeIndex;
        internal OpenTK.Vector2 texcoord;
        internal OpenTK.Vector3 normal;
        internal OpenTK.Vector3 binormal;
        internal OpenTK.Vector3 tangent;
        internal OpenTK.Vector3 anisotropicBinormal;
        internal OpenTK.Vector2 secondaryTexcoord;
        internal Moonfish.Tags.ColourR8G8B8 primaryLightmapColor;
        internal OpenTK.Vector2 primaryLightmapTexcoord;
        internal OpenTK.Vector3 primaryLightmapIncidentDirection;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 196; } }
        public override int Alignment { get { return 4; } }
        public GlobalGeometrySectionRawVertexBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            position = binaryReader.ReadVector3();
            nodeIndicesOLD = new []{ new NodeIndicesOLD(), new NodeIndicesOLD(), new NodeIndicesOLD(), new NodeIndicesOLD() };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesOLD[3].ReadFields(binaryReader)));
            nodeWeights = new []{ new NodeWeights(), new NodeWeights(), new NodeWeights(), new NodeWeights() };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeWeights[3].ReadFields(binaryReader)));
            nodeIndicesNEW = new []{ new NodeIndicesNEW(), new NodeIndicesNEW(), new NodeIndicesNEW(), new NodeIndicesNEW() };
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[0].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[1].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[2].ReadFields(binaryReader)));
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(nodeIndicesNEW[3].ReadFields(binaryReader)));
            useNewNodeIndices = binaryReader.ReadInt32();
            adjustedCompoundNodeIndex = binaryReader.ReadInt32();
            texcoord = binaryReader.ReadVector2();
            normal = binaryReader.ReadVector3();
            binormal = binaryReader.ReadVector3();
            tangent = binaryReader.ReadVector3();
            anisotropicBinormal = binaryReader.ReadVector3();
            secondaryTexcoord = binaryReader.ReadVector2();
            primaryLightmapColor = binaryReader.ReadColorR8G8B8();
            primaryLightmapTexcoord = binaryReader.ReadVector2();
            primaryLightmapIncidentDirection = binaryReader.ReadVector3();
            invalidName_ = binaryReader.ReadBytes(12);
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadBytes(12);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            nodeIndicesOLD = ReadBlockArrayData<NodeIndicesOLD>(binaryReader, blamPointers.Dequeue());
            nodeWeights = ReadBlockArrayData<NodeWeights>(binaryReader, blamPointers.Dequeue());
            nodeIndicesNEW = ReadBlockArrayData<NodeIndicesNEW>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
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
                binaryWriter.Write(texcoord);
                binaryWriter.Write(normal);
                binaryWriter.Write(binormal);
                binaryWriter.Write(tangent);
                binaryWriter.Write(anisotropicBinormal);
                binaryWriter.Write(secondaryTexcoord);
                binaryWriter.Write(primaryLightmapColor);
                binaryWriter.Write(primaryLightmapTexcoord);
                binaryWriter.Write(primaryLightmapIncidentDirection);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1, 0, 12);
                return nextAddress;
            }
        }
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class NodeIndicesOLD : GuerillaBlock
        {
            internal int nodeIndexOLD;
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
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
using(binaryWriter.BaseStream.Pin())
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
        [LayoutAttribute(Size = 4, Alignment = 1)]
        public class NodeIndicesNEW : GuerillaBlock
        {
            internal int nodeIndexNEW;
            public override int SerializedSize { get { return 4; } }
            public override int Alignment { get { return 1; } }
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
using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeIndexNEW);
                    return nextAddress;
                }
            }
        };
    };
}
