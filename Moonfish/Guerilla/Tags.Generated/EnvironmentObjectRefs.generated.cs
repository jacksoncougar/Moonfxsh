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
    
    public partial class EnvironmentObjectRefs : GuerillaBlock, IWriteQueueable
    {
        public Flags EnvironmentObjectRefsFlags;
        private byte[] fieldpad = new byte[2];
        public int FirstSector;
        public int LastSector;
        public EnvironmentObjectBspRefs[] Bsps = new EnvironmentObjectBspRefs[0];
        public EnvironmentObjectNodes[] Nodes = new EnvironmentObjectNodes[0];
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
            this.EnvironmentObjectRefsFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.FirstSector = binaryReader.ReadInt32();
            this.LastSector = binaryReader.ReadInt32();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Bsps = base.ReadBlockArrayData<EnvironmentObjectBspRefs>(binaryReader, pointerQueue.Dequeue());
            this.Nodes = base.ReadBlockArrayData<EnvironmentObjectNodes>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Bsps);
            queueableBinaryWriter.QueueWrite(this.Nodes);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.EnvironmentObjectRefsFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.FirstSector);
            queueableBinaryWriter.Write(this.LastSector);
            queueableBinaryWriter.WritePointer(this.Bsps);
            queueableBinaryWriter.WritePointer(this.Nodes);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Mobile = 1,
        }
    }
}
