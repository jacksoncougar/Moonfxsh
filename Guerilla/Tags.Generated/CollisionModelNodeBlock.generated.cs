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
    
    [TagBlockOriginalNameAttribute("collision_model_node_block")]
    public partial class CollisionModelNodeBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        private byte[] fieldpad = new byte[2];
        public Moonfish.Tags.ShortBlockIndex1 ParentNode;
        public Moonfish.Tags.ShortBlockIndex1 NextSiblingNode;
        public Moonfish.Tags.ShortBlockIndex1 FirstChildNode;
        public override int SerializedSize
        {
            get
            {
                return 12;
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
            this.Name = binaryReader.ReadStringID();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.ParentNode = binaryReader.ReadShortBlockIndex1();
            this.NextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.FirstChildNode = binaryReader.ReadShortBlockIndex1();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.ParentNode);
            queueableBinaryWriter.Write(this.NextSiblingNode);
            queueableBinaryWriter.Write(this.FirstChildNode);
        }
    }
}
