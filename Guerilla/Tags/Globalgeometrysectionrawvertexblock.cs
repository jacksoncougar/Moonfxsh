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
    [LayoutAttribute(Size = 196)]
    public class GlobalGeometrySectionRawVertexBlockBase
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
            this.position = binaryReader.ReadVector3();
            this.nodeIndicesOLD = new []{ new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader), new NodeIndicesOLD(binaryReader),  };
            this.nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
            this.nodeIndicesNEW = new []{ new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader), new NodeIndicesNEW(binaryReader),  };
            this.useNewNodeIndices = binaryReader.ReadInt32();
            this.adjustedCompoundNodeIndex = binaryReader.ReadInt32();
            this.texcoord = binaryReader.ReadVector2();
            this.normal = binaryReader.ReadVector3();
            this.binormal = binaryReader.ReadVector3();
            this.tangent = binaryReader.ReadVector3();
            this.anisotropicBinormal = binaryReader.ReadVector3();
            this.secondaryTexcoord = binaryReader.ReadVector2();
            this.primaryLightmapColor = binaryReader.ReadColorR8G8B8();
            this.primaryLightmapTexcoord = binaryReader.ReadVector2();
            this.primaryLightmapIncidentDirection = binaryReader.ReadVector3();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.invalidName_1 = binaryReader.ReadBytes(12);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        public class NodeIndicesOLD
        {
            internal int nodeIndexOLD;
            internal  NodeIndicesOLD(BinaryReader binaryReader)
            {
                this.nodeIndexOLD = binaryReader.ReadInt32();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.Count];
                if(blamPointer.Count > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.Count);
                    }
                }
                return data;
            }
        };
        public class NodeWeights
        {
            internal float nodeWeight;
            internal  NodeWeights(BinaryReader binaryReader)
            {
                this.nodeWeight = binaryReader.ReadSingle();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.Count];
                if(blamPointer.Count > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.Count);
                    }
                }
                return data;
            }
        };
        public class NodeIndicesNEW
        {
            internal int nodeIndexNEW;
            internal  NodeIndicesNEW(BinaryReader binaryReader)
            {
                this.nodeIndexNEW = binaryReader.ReadInt32();
            }
            internal  virtual byte[] ReadData(BinaryReader binaryReader)
            {
                var blamPointer = binaryReader.ReadBlamPointer(1);
                var data = new byte[blamPointer.Count];
                if(blamPointer.Count > 0)
                {
                    using (binaryReader.BaseStream.Pin())
                    {
                        binaryReader.BaseStream.Position = blamPointer[0];
                        data = binaryReader.ReadBytes(blamPointer.Count);
                    }
                }
                return data;
            }
        };
    };
}
