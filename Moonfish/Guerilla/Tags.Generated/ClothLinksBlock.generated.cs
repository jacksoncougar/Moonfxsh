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
    
    public partial class ClothLinksBlock : GuerillaBlock, IWriteQueueable
    {
        public int AttachmentBits;
        public short Index1;
        public short Index2;
        public float DefaultDistance;
        public float DampingMultiplier;
        public override int SerializedSize
        {
            get
            {
                return 16;
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
            this.AttachmentBits = binaryReader.ReadInt32();
            this.Index1 = binaryReader.ReadInt16();
            this.Index2 = binaryReader.ReadInt16();
            this.DefaultDistance = binaryReader.ReadSingle();
            this.DampingMultiplier = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(this.AttachmentBits);
            queueableBinaryWriter.Write(this.Index1);
            queueableBinaryWriter.Write(this.Index2);
            queueableBinaryWriter.Write(this.DefaultDistance);
            queueableBinaryWriter.Write(this.DampingMultiplier);
        }
    }
}
