using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryPartBlockNew : GlobalGeometryPartBlockNewBase
    {
        public  GlobalGeometryPartBlockNew(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class GlobalGeometryPartBlockNewBase
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
        internal  GlobalGeometryPartBlockNewBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.material = binaryReader.ReadShortBlockIndex1();
            this.stripStartIndex = binaryReader.ReadInt16();
            this.stripLength = binaryReader.ReadInt16();
            this.firstSubpartIndex = binaryReader.ReadInt16();
            this.subpartCount = binaryReader.ReadInt16();
            this.maxNodesVertex = binaryReader.ReadByte();
            this.contributingCompoundNodeCount = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
            this.nodeIndices = new []{ new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader),  };
            this.nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
            this.lodMipmapMagicNumber = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(24);
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
        internal enum Type : short
        {
            NotDrawn = 0,
            OpaqueShadowOnly = 1,
            OpaqueShadowCasting = 2,
            OpaqueNonshadowing = 3,
            Transparent = 4,
            LightmapOnly = 5,
        };
        internal enum Flags : short
        {
            Decalable = 1,
            NewPartTypes = 2,
            DislikesPhotons = 4,
            OverrideTriangleList = 8,
            IgnoredByLightmapper = 16,
        };
        public class NodeIndices
        {
            internal byte nodeIndex;
            internal  NodeIndices(BinaryReader binaryReader)
            {
                this.nodeIndex = binaryReader.ReadByte();
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
    };
}
