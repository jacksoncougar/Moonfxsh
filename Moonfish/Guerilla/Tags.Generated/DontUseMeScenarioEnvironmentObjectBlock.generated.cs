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
    
    public partial class DontUseMeScenarioEnvironmentObjectBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.ShortBlockIndex1 BSP;
        public short EMPTYSTRING;
        public int UniqueID;
        private byte[] fieldpad = new byte[4];
        public Moonfish.Tags.TagClass ObjectDefinitionTag;
        public int Object;
        private byte[] fieldpad0 = new byte[44];
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
            this.BSP = binaryReader.ReadShortBlockIndex1();
            this.EMPTYSTRING = binaryReader.ReadInt16();
            this.UniqueID = binaryReader.ReadInt32();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.ObjectDefinitionTag = binaryReader.ReadTagClass();
            this.Object = binaryReader.ReadInt32();
            this.fieldpad0 = binaryReader.ReadBytes(44);
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
            queueableBinaryWriter.Write(this.BSP);
            queueableBinaryWriter.Write(this.EMPTYSTRING);
            queueableBinaryWriter.Write(this.UniqueID);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.ObjectDefinitionTag);
            queueableBinaryWriter.Write(this.Object);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
    }
}
