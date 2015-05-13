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
    
    public partial class PlayerTrainingEntryDataBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent DisplayString;
        public Moonfish.Tags.StringIdent DisplayString2;
        public Moonfish.Tags.StringIdent DisplayString3;
        public short MaxDisplayTime;
        public short DisplayCount;
        public short DissapearDelay;
        public short RedisplayDelay;
        public float DisplayDelay;
        public Flags PlayerTrainingEntryDataFlags;
        private byte[] fieldpad = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 28;
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
            this.DisplayString = binaryReader.ReadStringID();
            this.DisplayString2 = binaryReader.ReadStringID();
            this.DisplayString3 = binaryReader.ReadStringID();
            this.MaxDisplayTime = binaryReader.ReadInt16();
            this.DisplayCount = binaryReader.ReadInt16();
            this.DissapearDelay = binaryReader.ReadInt16();
            this.RedisplayDelay = binaryReader.ReadInt16();
            this.DisplayDelay = binaryReader.ReadSingle();
            this.PlayerTrainingEntryDataFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
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
            queueableBinaryWriter.Write(this.DisplayString);
            queueableBinaryWriter.Write(this.DisplayString2);
            queueableBinaryWriter.Write(this.DisplayString3);
            queueableBinaryWriter.Write(this.MaxDisplayTime);
            queueableBinaryWriter.Write(this.DisplayCount);
            queueableBinaryWriter.Write(this.DissapearDelay);
            queueableBinaryWriter.Write(this.RedisplayDelay);
            queueableBinaryWriter.Write(this.DisplayDelay);
            queueableBinaryWriter.Write(((short)(this.PlayerTrainingEntryDataFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            NotInMultiplayer = 1,
        }
    }
}
