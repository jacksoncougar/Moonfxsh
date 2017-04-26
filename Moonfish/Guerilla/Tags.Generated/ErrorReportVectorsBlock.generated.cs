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
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("error_report_vectors_block")]
    public partial class ErrorReportVectorsBlock : GuerillaBlock, IWriteDeferrable
    {
        public OpenTK.Vector3 Position;
        public NodeIndicesBlock[] NodeIndices00 = new NodeIndicesBlock[4];
        public NodeWeightsBlock[] NodeWeights00 = new NodeWeightsBlock[4];
        public OpenTK.Vector4 Color;
        public OpenTK.Vector3 Normal;
        public float ScreenLength;
        public override int SerializedSize
        {
            get
            {
                return 64;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
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
            this.Color = binaryReader.ReadVector4();
            this.Normal = binaryReader.ReadVector3();
            this.ScreenLength = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
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
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i].DeferReferences(queueableBinaryWriter);
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeWeights00[i].DeferReferences(queueableBinaryWriter);
            }
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Position);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices00[i].Write(queueableBinaryWriter);
            }
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeWeights00[i].Write(queueableBinaryWriter);
            }
            queueableBinaryWriter.Write(this.Color);
            queueableBinaryWriter.Write(this.Normal);
            queueableBinaryWriter.Write(this.ScreenLength);
        }
        [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
        public class NodeIndicesBlock : GuerillaBlock, IWriteDeferrable
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
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.NodeIndex = binaryReader.ReadByte();
                return pointerQueue;
            }
            public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
            {
                base.ReadInstances(binaryReader, pointerQueue);
            }
            public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
            {
                base.DeferReferences(queueableBinaryWriter);
            }
            public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
            {
                base.Write(queueableBinaryWriter);
                queueableBinaryWriter.Write(this.NodeIndex);
            }
        }
        [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
        public class NodeWeightsBlock : GuerillaBlock, IWriteDeferrable
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
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.NodeWeight = binaryReader.ReadSingle();
                return pointerQueue;
            }
            public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
            {
                base.ReadInstances(binaryReader, pointerQueue);
            }
            public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
            {
                base.DeferReferences(queueableBinaryWriter);
            }
            public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
            {
                base.Write(queueableBinaryWriter);
                queueableBinaryWriter.Write(this.NodeWeight);
            }
        }
    }
}
