// ReSharper disable All
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
        public  GlobalGeometryPartBlockNew(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalGeometryPartBlockNewBase(System.IO.BinaryReader binaryReader)
        {
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
            nodeIndices = new []{ new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader), new NodeIndices(binaryReader),  };
            nodeWeights = new []{ new NodeWeights(binaryReader), new NodeWeights(binaryReader), new NodeWeights(binaryReader),  };
            lodMipmapMagicNumber = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
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
        public class NodeIndices
        {
            internal byte nodeIndex;
            internal  NodeIndices(System.IO.BinaryReader binaryReader)
            {
                nodeIndex = binaryReader.ReadByte();
            }
            internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeIndex);
                }
            }
        };
        public class NodeWeights
        {
            internal float nodeWeight;
            internal  NodeWeights(System.IO.BinaryReader binaryReader)
            {
                nodeWeight = binaryReader.ReadSingle();
            }
            internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
            internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
            {
                
            }
            public void Write(System.IO.BinaryWriter binaryWriter)
            {
                using(binaryWriter.BaseStream.Pin())
                {
                    binaryWriter.Write(nodeWeight);
                }
            }
        };
    };
}
