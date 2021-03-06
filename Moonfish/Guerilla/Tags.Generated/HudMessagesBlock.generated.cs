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
    
    public partial class HudMessagesBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.String32 Name;
        public short StartIndexIntoTextBlob;
        public short StartIndexOfMessageBlock;
        public byte PanelCount;
        private byte[] fieldpad = new byte[3];
        private byte[] fieldpad0 = new byte[24];
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Name = binaryReader.ReadString32();
            this.StartIndexIntoTextBlob = binaryReader.ReadInt16();
            this.StartIndexOfMessageBlock = binaryReader.ReadInt16();
            this.PanelCount = binaryReader.ReadByte();
            this.fieldpad = binaryReader.ReadBytes(3);
            this.fieldpad0 = binaryReader.ReadBytes(24);
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
            queueableBinaryWriter.Write(this.StartIndexIntoTextBlob);
            queueableBinaryWriter.Write(this.StartIndexOfMessageBlock);
            queueableBinaryWriter.Write(this.PanelCount);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
    }
}
