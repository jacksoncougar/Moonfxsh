//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
    
    [TagBlockOriginalNameAttribute("error_report_triangles_block")]
    public partial class ErrorReportTrianglesBlock : GuerillaBlock, IWriteQueueable
    {
        public PointsBlock[] Points00 = new PointsBlock[3];
        public OpenTK.Vector4 Color;
        public override int SerializedSize
        {
            get
            {
                return 112;
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
            int i;
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.Points00[i] = new PointsBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Points00[i].ReadFields(binaryReader)));
            }
            this.Color = binaryReader.ReadVector4();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            int i;
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.Points00[i].ReadInstances(binaryReader, pointerQueue);
            }
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            int i;
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.Points00[i].QueueWrites(queueableBlamBinaryWriter);
            }
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            int i;
            for (i = 0; (i < 3); i = (i + 1))
            {
                this.Points00[i].Write_(queueableBlamBinaryWriter);
            }
            queueableBlamBinaryWriter.Write(this.Color);
        }
        public class PointsBlock : GuerillaBlock, IWriteQueueable
        {
            public OpenTK.Vector3 Position;
            public NodeIndicesBlock[] NodeIndices00 = new NodeIndicesBlock[4];
            public NodeWeightsBlock[] NodeWeights00 = new NodeWeightsBlock[4];
            public override int SerializedSize
            {
                get
                {
                    return 32;
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
}
