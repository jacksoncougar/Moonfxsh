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
    
    public partial class ScenarioVehicleBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.ShortBlockIndex1 Type;
        public Moonfish.Tags.ShortBlockIndex1 Name;
        public ScenarioObjectDatumStructBlock ObjectData = new ScenarioObjectDatumStructBlock();
        private byte[] indexer = new byte[4];
        public ScenarioObjectPermutationStructBlock PermutationData = new ScenarioObjectPermutationStructBlock();
        public ScenarioUnitStructBlock UnitData = new ScenarioUnitStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 84;
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
            this.Type = binaryReader.ReadShortBlockIndex1();
            this.Name = binaryReader.ReadShortBlockIndex1();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ObjectData.ReadFields(binaryReader)));
            this.indexer = binaryReader.ReadBytes(4);
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.PermutationData.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.UnitData.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ObjectData.ReadInstances(binaryReader, pointerQueue);
            this.PermutationData.ReadInstances(binaryReader, pointerQueue);
            this.UnitData.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.ObjectData.QueueWrites(queueableBlamBinaryWriter);
            this.PermutationData.QueueWrites(queueableBlamBinaryWriter);
            this.UnitData.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.Type);
            queueableBlamBinaryWriter.Write(this.Name);
            this.ObjectData.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.indexer);
            this.PermutationData.Write_(queueableBlamBinaryWriter);
            this.UnitData.Write_(queueableBlamBinaryWriter);
        }
    }
}
