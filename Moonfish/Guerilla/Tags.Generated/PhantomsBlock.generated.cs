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
    
    public partial class PhantomsBlock : GuerillaBlock, IWriteQueueable
    {
        private byte[] fieldskip = new byte[4];
        public short Size;
        public short Count;
        private byte[] fieldskip0 = new byte[4];
        private byte[] fieldpad = new byte[4];
        private byte[] fieldpad0 = new byte[4];
        private byte[] fieldskip1 = new byte[4];
        public short Size0;
        public short Count0;
        private byte[] fieldskip2 = new byte[4];
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
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.fieldskip = binaryReader.ReadBytes(4);
            this.Size = binaryReader.ReadInt16();
            this.Count = binaryReader.ReadInt16();
            this.fieldskip0 = binaryReader.ReadBytes(4);
            this.fieldpad = binaryReader.ReadBytes(4);
            this.fieldpad0 = binaryReader.ReadBytes(4);
            this.fieldskip1 = binaryReader.ReadBytes(4);
            this.Size0 = binaryReader.ReadInt16();
            this.Count0 = binaryReader.ReadInt16();
            this.fieldskip2 = binaryReader.ReadBytes(4);
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
            queueableBlamBinaryWriter.Write(this.fieldskip);
            queueableBlamBinaryWriter.Write(this.Size);
            queueableBlamBinaryWriter.Write(this.Count);
            queueableBlamBinaryWriter.Write(this.fieldskip0);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.fieldskip1);
            queueableBlamBinaryWriter.Write(this.Size0);
            queueableBlamBinaryWriter.Write(this.Count0);
            queueableBlamBinaryWriter.Write(this.fieldskip2);
        }
    }
}
