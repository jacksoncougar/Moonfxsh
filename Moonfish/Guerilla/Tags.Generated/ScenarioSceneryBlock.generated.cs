//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("scenario_scenery_block")]
    public partial class ScenarioSceneryBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.ShortBlockIndex1 Type;
        public Moonfish.Tags.ShortBlockIndex1 Name;
        public ScenarioObjectDatumStructBlock ObjectData = new ScenarioObjectDatumStructBlock();
        private byte[] indexer = new byte[4];
        public ScenarioObjectPermutationStructBlock PermutationData = new ScenarioObjectPermutationStructBlock();
        public ScenarioSceneryDatumStructV4Block SceneryData = new ScenarioSceneryDatumStructV4Block();
        public override int SerializedSize
        {
            get
            {
                return 92;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Type = binaryReader.ReadShortBlockIndex1();
            this.Name = binaryReader.ReadShortBlockIndex1();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ObjectData.ReadFields(binaryReader)));
            this.indexer = binaryReader.ReadBytes(4);
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.PermutationData.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.SceneryData.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ObjectData.ReadInstances(binaryReader, pointerQueue);
            this.PermutationData.ReadInstances(binaryReader, pointerQueue);
            this.SceneryData.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.ObjectData.QueueWrites(queueableBinaryWriter);
            this.PermutationData.QueueWrites(queueableBinaryWriter);
            this.SceneryData.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Type);
            queueableBinaryWriter.Write(this.Name);
            this.ObjectData.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.indexer);
            this.PermutationData.Write(queueableBinaryWriter);
            this.SceneryData.Write(queueableBinaryWriter);
        }
    }
}
