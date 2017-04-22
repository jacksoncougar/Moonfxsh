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
    [TagBlockOriginalNameAttribute("effect_event_block")]
    public partial class EffectEventBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags EffectEventFlags;
        public float SkipFraction;
        public Moonfish.Model.Range DelayBounds;
        public Moonfish.Model.Range DurationBounds;
        public EffectPartBlock[] Parts = new EffectPartBlock[0];
        public BeamBlock[] Beams = new BeamBlock[0];
        public EffectAccelerationsBlock[] Accelerations = new EffectAccelerationsBlock[0];
        public ParticleSystemDefinitionBlockNew[] ParticleSystems = new ParticleSystemDefinitionBlockNew[0];
        public override int SerializedSize
        {
            get
            {
                return 56;
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
            this.EffectEventFlags = ((Flags)(binaryReader.ReadInt32()));
            this.SkipFraction = binaryReader.ReadSingle();
            this.DelayBounds = binaryReader.ReadRange();
            this.DurationBounds = binaryReader.ReadRange();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(60));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Parts = base.ReadBlockArrayData<EffectPartBlock>(binaryReader, pointerQueue.Dequeue());
            this.Beams = base.ReadBlockArrayData<BeamBlock>(binaryReader, pointerQueue.Dequeue());
            this.Accelerations = base.ReadBlockArrayData<EffectAccelerationsBlock>(binaryReader, pointerQueue.Dequeue());
            this.ParticleSystems = base.ReadBlockArrayData<ParticleSystemDefinitionBlockNew>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Parts);
            queueableBinaryWriter.QueueWrite(this.Beams);
            queueableBinaryWriter.QueueWrite(this.Accelerations);
            queueableBinaryWriter.QueueWrite(this.ParticleSystems);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.EffectEventFlags)));
            queueableBinaryWriter.Write(this.SkipFraction);
            queueableBinaryWriter.Write(this.DelayBounds);
            queueableBinaryWriter.Write(this.DurationBounds);
            queueableBinaryWriter.WritePointer(this.Parts);
            queueableBinaryWriter.WritePointer(this.Beams);
            queueableBinaryWriter.WritePointer(this.Accelerations);
            queueableBinaryWriter.WritePointer(this.ParticleSystems);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            DisabledForDebugging = 1,
        }
    }
}
