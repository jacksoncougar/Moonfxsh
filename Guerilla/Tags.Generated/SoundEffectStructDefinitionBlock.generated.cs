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
    
    public partial class SoundEffectStructDefinitionBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("<fx>")]
        public Moonfish.Tags.TagReference TagReference;
        public SoundEffectComponentBlock[] Components = new SoundEffectComponentBlock[0];
        public SoundEffectOverridesBlock[] SoundEffectOverridesBlock = new SoundEffectOverridesBlock[0];
        public byte[] SoundEffectHardwareFormatDataDefinition;
        public PlatformSoundEffectCollectionBlock[] PlatformSoundEffectCollectionBlock = new PlatformSoundEffectCollectionBlock[0];
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
            this.TagReference = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Components = base.ReadBlockArrayData<SoundEffectComponentBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundEffectOverridesBlock = base.ReadBlockArrayData<SoundEffectOverridesBlock>(binaryReader, pointerQueue.Dequeue());
            this.SoundEffectHardwareFormatDataDefinition = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
            this.PlatformSoundEffectCollectionBlock = base.ReadBlockArrayData<PlatformSoundEffectCollectionBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Components);
            queueableBinaryWriter.QueueWrite(this.SoundEffectOverridesBlock);
            queueableBinaryWriter.QueueWrite(this.SoundEffectHardwareFormatDataDefinition);
            queueableBinaryWriter.QueueWrite(this.PlatformSoundEffectCollectionBlock);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.TagReference);
            queueableBinaryWriter.WritePointer(this.Components);
            queueableBinaryWriter.WritePointer(this.SoundEffectOverridesBlock);
            queueableBinaryWriter.WritePointer(this.SoundEffectHardwareFormatDataDefinition);
            queueableBinaryWriter.WritePointer(this.PlatformSoundEffectCollectionBlock);
        }
    }
}
