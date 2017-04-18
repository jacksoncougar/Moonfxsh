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
    
    public partial class GlobalGeometryRawPointBlock : GuerillaBlock, IWriteQueueable
    {
        public OpenTK.Vector3 Position;
        public NodeIndicesBlock[] NodeIndices00 = new NodeIndicesBlock[4];
        public NodeWeightsBlock[] NodeWeights00 = new NodeWeightsBlock[4];
        public NodeIndices1Block[] NodeIndices20 = new NodeIndices1Block[4];
        public int UseNewNodeIndices;
        public int AdjustedCompoundNodeIndex;
        public override int SerializedSize
        {
            get
            {
                return 68;
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
            this.Position = binaryReader.ReadVector3();
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i] = new NodeIndicesBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.NodeIndices00[i].ReadFields(binaryReader)));
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeWeights00[i] = new NodeWeightsBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.NodeWeights00[i].ReadFields(binaryReader)));
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i] = new NodeIndices1Block();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.NodeIndices20[i].ReadFields(binaryReader)));
            }
            this.UseNewNodeIndices = binaryReader.ReadInt32();
            this.AdjustedCompoundNodeIndex = binaryReader.ReadInt32();
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
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeWeights00[i].ReadInstances(binaryReader, pointerQueue);
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i].ReadInstances(binaryReader, pointerQueue);
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
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeWeights00[i].QueueWrites(queueableBlamBinaryWriter);
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i].QueueWrites(queueableBlamBinaryWriter);
            }
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.Position);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i].Write_(queueableBlamBinaryWriter);
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeWeights00[i].Write_(queueableBlamBinaryWriter);
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i].Write_(queueableBlamBinaryWriter);
            }
            queueableBlamBinaryWriter.Write(this.UseNewNodeIndices);
            queueableBlamBinaryWriter.Write(this.AdjustedCompoundNodeIndex);
        }
        public class NodeIndicesBlock : GuerillaBlock, IWriteQueueable
        {
            public int NodeIndex;
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
                this.NodeIndex = binaryReader.ReadInt32();
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
        public class NodeIndices1Block : GuerillaBlock, IWriteQueueable
        {
            public int NodeIndex;
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
                this.NodeIndex = binaryReader.ReadInt32();
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
    }
}
