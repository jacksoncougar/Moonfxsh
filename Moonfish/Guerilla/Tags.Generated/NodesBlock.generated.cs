//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
    
    public partial class NodesBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public Flags NodesFlags;
        public Moonfish.Tags.ShortBlockIndex1 Parent;
        public Moonfish.Tags.ShortBlockIndex1 Sibling;
        public Moonfish.Tags.ShortBlockIndex1 Child;
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
            this.Name = binaryReader.ReadStringIdent();
            this.NodesFlags = ((Flags)(binaryReader.ReadInt16()));
            this.Parent = binaryReader.ReadShortBlockIndex1();
            this.Sibling = binaryReader.ReadShortBlockIndex1();
            this.Child = binaryReader.ReadShortBlockIndex1();
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
            queueableBinaryWriter.Write(((short)(this.NodesFlags)));
            queueableBinaryWriter.Write(this.Parent);
            queueableBinaryWriter.Write(this.Sibling);
            queueableBinaryWriter.Write(this.Child);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            DoesNotAnimate = 1,
        }
    }
}
