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
    
    public partial class UiErrorCategoryBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// For each error condition displayed in the UI, set the title and description string ids here
        /// </summary>
        public Moonfish.Tags.StringIdent CategoryName;
        public Flags UiErrorCategoryFlags;
        public DefaultButtonEnum DefaultButton;
        private byte[] fieldpad = new byte[1];
        [Moonfish.Tags.TagReferenceAttribute("unic")]
        public Moonfish.Tags.TagReference StringTag;
        public Moonfish.Tags.StringIdent DefaultTitle;
        public Moonfish.Tags.StringIdent DefaultMessage;
        public Moonfish.Tags.StringIdent DefaultOk;
        public Moonfish.Tags.StringIdent DefaultCancel;
        public UiErrorBlock[] ErrorBlock = new UiErrorBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 40;
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
            this.CategoryName = binaryReader.ReadStringIdent();
            this.UiErrorCategoryFlags = ((Flags)(binaryReader.ReadInt16()));
            this.DefaultButton = ((DefaultButtonEnum)(binaryReader.ReadByte()));
            this.fieldpad = binaryReader.ReadBytes(1);
            this.StringTag = binaryReader.ReadTagReference();
            this.DefaultTitle = binaryReader.ReadStringIdent();
            this.DefaultMessage = binaryReader.ReadStringIdent();
            this.DefaultOk = binaryReader.ReadStringIdent();
            this.DefaultCancel = binaryReader.ReadStringIdent();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ErrorBlock = base.ReadBlockArrayData<UiErrorBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.ErrorBlock);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.CategoryName);
            queueableBinaryWriter.Write(((short)(this.UiErrorCategoryFlags)));
            queueableBinaryWriter.Write(((byte)(this.DefaultButton)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.StringTag);
            queueableBinaryWriter.Write(this.DefaultTitle);
            queueableBinaryWriter.Write(this.DefaultMessage);
            queueableBinaryWriter.Write(this.DefaultOk);
            queueableBinaryWriter.Write(this.DefaultCancel);
            queueableBinaryWriter.WritePointer(this.ErrorBlock);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            UseLargeDialog = 1,
        }
        public enum DefaultButtonEnum : byte
        {
            NoDefault = 0,
            DefaultOk = 1,
            DefaultCancel = 2,
        }
    }
}
