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
    
    public partial class RenderModelNodeBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public Moonfish.Tags.ShortBlockIndex1 ParentNode;
        public Moonfish.Tags.ShortBlockIndex1 FirstChildNode;
        public Moonfish.Tags.ShortBlockIndex1 NextSiblingNode;
        public short ImportNodeIndex;
        public OpenTK.Vector3 DefaultTranslation;
        public OpenTK.Quaternion DefaultRotation;
        public OpenTK.Vector3 InverseForward;
        public OpenTK.Vector3 InverseLeft;
        public OpenTK.Vector3 InverseUp;
        public OpenTK.Vector3 InversePosition;
        public float InverseScale;
        public float DistanceFromParent;
        public override int SerializedSize
        {
            get
            {
                return 96;
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
            this.Name = binaryReader.ReadStringIdent();
            this.ParentNode = binaryReader.ReadShortBlockIndex1();
            this.FirstChildNode = binaryReader.ReadShortBlockIndex1();
            this.NextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.ImportNodeIndex = binaryReader.ReadInt16();
            this.DefaultTranslation = binaryReader.ReadVector3();
            this.DefaultRotation = binaryReader.ReadQuaternion();
            this.InverseForward = binaryReader.ReadVector3();
            this.InverseLeft = binaryReader.ReadVector3();
            this.InverseUp = binaryReader.ReadVector3();
            this.InversePosition = binaryReader.ReadVector3();
            this.InverseScale = binaryReader.ReadSingle();
            this.DistanceFromParent = binaryReader.ReadSingle();
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
            queueableBlamBinaryWriter.Write(this.Name);
            queueableBlamBinaryWriter.Write(this.ParentNode);
            queueableBlamBinaryWriter.Write(this.FirstChildNode);
            queueableBlamBinaryWriter.Write(this.NextSiblingNode);
            queueableBlamBinaryWriter.Write(this.ImportNodeIndex);
            queueableBlamBinaryWriter.Write(this.DefaultTranslation);
            queueableBlamBinaryWriter.Write(this.DefaultRotation);
            queueableBlamBinaryWriter.Write(this.InverseForward);
            queueableBlamBinaryWriter.Write(this.InverseLeft);
            queueableBlamBinaryWriter.Write(this.InverseUp);
            queueableBlamBinaryWriter.Write(this.InversePosition);
            queueableBlamBinaryWriter.Write(this.InverseScale);
            queueableBlamBinaryWriter.Write(this.DistanceFromParent);
        }
    }
}
