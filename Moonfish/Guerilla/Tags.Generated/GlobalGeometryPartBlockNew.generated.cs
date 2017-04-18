//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class GlobalGeometryPartBlockNew : GuerillaBlock, IWriteQueueable
    {
        public TypeEnum Type;
        public Flags GlobalGeometryPartNewFlags;
        public Moonfish.Tags.ShortBlockIndex1 Material;
        public short StripStartIndex;
        public short StripLength;
        public short FirstSubpartIndex;
        public short SubpartCount;
        public byte MaxNodesVertex;
        public byte ContributingCompoundNodeCount;
        /// <summary>
        /// EMPTY STRING
        /// </summary>
        public OpenTK.Vector3 Position;
        public NodeIndicesBlock[] NodeIndices00 = new NodeIndicesBlock[4];
        public NodeWeightsBlock[] NodeWeights00 = new NodeWeightsBlock[3];
        public float LodMipmapMagicNumber;
        private byte[] fieldskip = new byte[24];
        public override int SerializedSize
        {
            get
            {
                return 72;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.GlobalGeometryPartNewFlags = ((Flags)(binaryReader.ReadInt16()));
            this.Material = binaryReader.ReadShortBlockIndex1();
            this.StripStartIndex = binaryReader.ReadInt16();
            this.StripLength = binaryReader.ReadInt16();
            this.FirstSubpartIndex = binaryReader.ReadInt16();
            this.SubpartCount = binaryReader.ReadInt16();
            this.MaxNodesVertex = binaryReader.ReadByte();
            this.ContributingCompoundNodeCount = binaryReader.ReadByte();
            this.Position = binaryReader.ReadVector3();
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i] = new NodeIndicesBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.NodeIndices00[i].ReadFields(binaryReader)));
            }
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.NodeWeights00[i] = new NodeWeightsBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.NodeWeights00[i].ReadFields(binaryReader)));
            }
            this.LodMipmapMagicNumber = binaryReader.ReadSingle();
            this.fieldskip = binaryReader.ReadBytes(24);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i].ReadInstances(binaryReader, pointerQueue);
            }
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.NodeWeights00[i].ReadInstances(binaryReader, pointerQueue);
            }
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i].QueueWrites(queueableBlamBinaryWriter);
            }
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.NodeWeights00[i].QueueWrites(queueableBlamBinaryWriter);
            }
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((short)(this.Type)));
            queueableBlamBinaryWriter.Write(((short)(this.GlobalGeometryPartNewFlags)));
            queueableBlamBinaryWriter.Write(this.Material);
            queueableBlamBinaryWriter.Write(this.StripStartIndex);
            queueableBlamBinaryWriter.Write(this.StripLength);
            queueableBlamBinaryWriter.Write(this.FirstSubpartIndex);
            queueableBlamBinaryWriter.Write(this.SubpartCount);
            queueableBlamBinaryWriter.Write(this.MaxNodesVertex);
            queueableBlamBinaryWriter.Write(this.ContributingCompoundNodeCount);
            queueableBlamBinaryWriter.Write(this.Position);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i].Write_(queueableBlamBinaryWriter);
            }
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.NodeWeights00[i].Write_(queueableBlamBinaryWriter);
            }
            queueableBlamBinaryWriter.Write(this.LodMipmapMagicNumber);
            queueableBlamBinaryWriter.Write(this.fieldskip);
        }
        public enum TypeEnum : short
        {
            NotDrawn = 0,
            OpaqueShadowOnly = 1,
            OpaqueShadowCasting = 2,
            OpaqueNonshadowing = 3,
            Transparent = 4,
            LightmapOnly = 5,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Decalable = 1,
            NewPartTypes = 2,
            DislikesPhotons = 4,
            OverrideTriangleList = 8,
            IgnoredByLightmapper = 16,
        }
        public class NodeIndicesBlock : GuerillaBlock, IWriteQueueable
        {
            public byte NodeIndex;
            public override int SerializedSize
            {
                get
                {
                    return 1;
                }
            }
            public override int Alignment
            {
                get
                {
                    return 1;
                }
            }
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.NodeIndex = binaryReader.ReadByte();
                return pointerQueue;
            }
            public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
            {
                base.ReadInstances(binaryReader, pointerQueue);
            }
            public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
            {
                base.QueueWrites(queueableBlamBinaryWriter);
            }
            public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
            {
                base.Write_(queueableBlamBinaryWriter);
                queueableBlamBinaryWriter.Write(this.NodeIndex);
            }
        }
        public class NodeWeightsBlock : GuerillaBlock, IWriteQueueable
        {
            public float NodeWeight;
            public override int SerializedSize
            {
                get
                {
                    return 4;
                }
            }
            public override int Alignment
            {
                get
                {
                    return 1;
                }
            }
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.NodeWeight = binaryReader.ReadSingle();
                return pointerQueue;
            }
            public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
            {
                base.ReadInstances(binaryReader, pointerQueue);
            }
            public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
            {
                base.QueueWrites(queueableBlamBinaryWriter);
            }
            public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
            {
                base.Write_(queueableBlamBinaryWriter);
                queueableBlamBinaryWriter.Write(this.NodeWeight);
            }
        }
    }
}
