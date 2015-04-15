// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometrySectionRawVertexBlock : GlobalGeometrySectionRawVertexBlockBase
    {
        public  GlobalGeometrySectionRawVertexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 196, Alignment = 4)]
    public class GlobalGeometrySectionRawVertexBlockBase  : IGuerilla
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
        internal Moonfish.Tags.ColorR8G8B8 primaryLightmapColor;
        internal OpenTK.Vector2 primaryLightmapTexcoord;
        internal OpenTK.Vector3 primaryLightmapIncidentDirection;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal  GlobalGeometrySectionRawVertexBlockBase(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            nodeIndicesOLD = new []{ new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader),  };
            nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
            nodeIndicesNEW = new []{ new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader),  };
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
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
        public class NodeIndicesOLD  : IGuerilla
        {
            internal int nodeIndexOLD;
            internal  NodeIndicesOLD(BinaryReader binaryReader)
            {
                nodeIndexOLD = binaryReader.ReadInt32();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeIndexOLD);
                    return nextAddress;
                }
            }
        };
        public class NodeWeights  : IGuerilla
        {
            internal float nodeWeight;
            internal  NodeWeights(BinaryReader binaryReader)
            {
                nodeWeight = binaryReader.ReadSingle();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeWeight);
                    return nextAddress;
                }
            }
        };
        public class NodeIndicesNEW  : IGuerilla
        {
            internal int nodeIndexNEW;
            internal  NodeIndicesNEW(BinaryReader binaryReader)
            {
                nodeIndexNEW = binaryReader.ReadInt32();
            }
            public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeIndexNEW);
                    return nextAddress;
                }
            }
        };
    };
}
