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
    
    public partial class GlobalDetailObjectCellsBlock : GuerillaBlock, IWriteQueueable
    {
        public short FieldShortInteger;
        public short FieldShortInteger0;
        public short FieldShortInteger1;
        public short FieldShortInteger2;
        public int FieldLongInteger;
        public int FieldLongInteger0;
        public int FieldLongInteger1;
        private byte[] fieldpad = new byte[12];
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
            this.FieldShortInteger = binaryReader.ReadInt16();
            this.FieldShortInteger0 = binaryReader.ReadInt16();
            this.FieldShortInteger1 = binaryReader.ReadInt16();
            this.FieldShortInteger2 = binaryReader.ReadInt16();
            this.FieldLongInteger = binaryReader.ReadInt32();
            this.FieldLongInteger0 = binaryReader.ReadInt32();
            this.FieldLongInteger1 = binaryReader.ReadInt32();
            this.fieldpad = binaryReader.ReadBytes(12);
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
            queueableBlamBinaryWriter.Write(this.FieldShortInteger);
            queueableBlamBinaryWriter.Write(this.FieldShortInteger0);
            queueableBlamBinaryWriter.Write(this.FieldShortInteger1);
            queueableBlamBinaryWriter.Write(this.FieldShortInteger2);
            queueableBlamBinaryWriter.Write(this.FieldLongInteger);
            queueableBlamBinaryWriter.Write(this.FieldLongInteger0);
            queueableBlamBinaryWriter.Write(this.FieldLongInteger1);
            queueableBlamBinaryWriter.Write(this.fieldpad);
        }
    }
}
