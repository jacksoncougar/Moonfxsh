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
    [TagBlockOriginalNameAttribute("global_geometry_section_raw_vertex_block")]
    public partial class GlobalGeometrySectionRawVertexBlock : GuerillaBlock, IWriteDeferrable
    {
        public OpenTK.Vector3 Position;
        public NodeIndicesBlock[] NodeIndices00 = new NodeIndicesBlock[4];
        public NodeWeightsBlock[] NodeWeights00 = new NodeWeightsBlock[4];
        public NodeIndices1Block[] NodeIndices20 = new NodeIndices1Block[4];
        public int UseNewNodeIndices;
        public int AdjustedCompoundNodeIndex;
        public OpenTK.Vector2 Texcoord;
        public OpenTK.Vector3 Normal;
        public OpenTK.Vector3 Binormal;
        public OpenTK.Vector3 Tangent;
        public OpenTK.Vector3 AnisotropicBinormal;
        public OpenTK.Vector2 SecondaryTexcoord;
        public Moonfish.Tags.ColourR8G8B8 PrimaryLightmapColor;
        public OpenTK.Vector2 PrimaryLightmapTexcoord;
        public OpenTK.Vector3 PrimaryLightmapIncidentDirection;
        private byte[] fieldpad = new byte[12];
        private byte[] fieldpad0 = new byte[8];
        private byte[] fieldpad1 = new byte[12];
        public override int SerializedSize
        {
            get
            {
                return 196;
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
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i] = new NodeIndices1Block();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.NodeIndices20[i].ReadFields(binaryReader)));
            }
            this.UseNewNodeIndices = binaryReader.ReadInt32();
            this.AdjustedCompoundNodeIndex = binaryReader.ReadInt32();
            this.Texcoord = binaryReader.ReadVector2();
            this.Normal = binaryReader.ReadVector3();
            this.Binormal = binaryReader.ReadVector3();
            this.Tangent = binaryReader.ReadVector3();
            this.AnisotropicBinormal = binaryReader.ReadVector3();
            this.SecondaryTexcoord = binaryReader.ReadVector2();
            this.PrimaryLightmapColor = binaryReader.ReadColourR8G8B8();
            this.PrimaryLightmapTexcoord = binaryReader.ReadVector2();
            this.PrimaryLightmapIncidentDirection = binaryReader.ReadVector3();
            this.fieldpad = binaryReader.ReadBytes(12);
            this.fieldpad0 = binaryReader.ReadBytes(8);
            this.fieldpad1 = binaryReader.ReadBytes(12);
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
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i].ReadInstances(binaryReader, pointerQueue);
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
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i].DeferReferences(queueableBinaryWriter);
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
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.NodeIndices20[i].Write(queueableBinaryWriter);
            }
            queueableBinaryWriter.Write(this.UseNewNodeIndices);
            queueableBinaryWriter.Write(this.AdjustedCompoundNodeIndex);
            queueableBinaryWriter.Write(this.Texcoord);
            queueableBinaryWriter.Write(this.Normal);
            queueableBinaryWriter.Write(this.Binormal);
            queueableBinaryWriter.Write(this.Tangent);
            queueableBinaryWriter.Write(this.AnisotropicBinormal);
            queueableBinaryWriter.Write(this.SecondaryTexcoord);
            queueableBinaryWriter.Write(this.PrimaryLightmapColor);
            queueableBinaryWriter.Write(this.PrimaryLightmapTexcoord);
            queueableBinaryWriter.Write(this.PrimaryLightmapIncidentDirection);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.fieldpad1);
        }
        [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
        public class NodeIndicesBlock : GuerillaBlock, IWriteDeferrable
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
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.NodeIndex = binaryReader.ReadInt32();
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
        [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
        public class NodeIndices1Block : GuerillaBlock, IWriteDeferrable
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
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.NodeIndex = binaryReader.ReadInt32();
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
    }
}
