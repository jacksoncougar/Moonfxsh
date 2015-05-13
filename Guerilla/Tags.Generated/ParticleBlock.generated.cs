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
    
    [TagClassAttribute("prt3")]
    public partial class ParticleBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags ParticleFlags;
        public ParticleBillboardStyleEnum ParticleBillboardStyle;
        private byte[] fieldpad = new byte[2];
        public short FirstSequenceIndex;
        public short SequenceCount;
        [Moonfish.Tags.TagReferenceAttribute("stem")]
        public Moonfish.Tags.TagReference ShaderTemplate;
        public GlobalShaderParameterBlock[] ShaderParameters = new GlobalShaderParameterBlock[0];
        public ParticlePropertyColorStructNewBlock Color = new ParticlePropertyColorStructNewBlock();
        public ParticlePropertyScalarStructNewBlock Alpha = new ParticlePropertyScalarStructNewBlock();
        public ParticlePropertyScalarStructNewBlock Scale = new ParticlePropertyScalarStructNewBlock();
        public ParticlePropertyScalarStructNewBlock Rotation = new ParticlePropertyScalarStructNewBlock();
        public ParticlePropertyScalarStructNewBlock FrameIndex = new ParticlePropertyScalarStructNewBlock();
        /// <summary>
        /// collision occurs when particle physics has collision, death spawned when particle dies
        /// </summary>
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference CollisionEffect;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference DeathEffect;
        public EffectLocationsBlock[] Locations = new EffectLocationsBlock[0];
        public ParticleSystemDefinitionBlockNew[] AttachedParticleSystems = new ParticleSystemDefinitionBlockNew[0];
        public ShaderPostprocessDefinitionNewBlock[] ShaderPostprocessDefinitionNewBlock = new ShaderPostprocessDefinitionNewBlock[0];
        private byte[] fieldpad0 = new byte[8];
        private byte[] fieldpad1 = new byte[16];
        private byte[] fieldpad2 = new byte[16];
        public override int SerializedSize
        {
            get
            {
                return 188;
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
            this.ParticleFlags = ((Flags)(binaryReader.ReadInt32()));
            this.ParticleBillboardStyle = ((ParticleBillboardStyleEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.FirstSequenceIndex = binaryReader.ReadInt16();
            this.SequenceCount = binaryReader.ReadInt16();
            this.ShaderTemplate = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(40));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Color.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Alpha.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Scale.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Rotation.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.FrameIndex.ReadFields(binaryReader)));
            this.CollisionEffect = binaryReader.ReadTagReference();
            this.DeathEffect = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(4));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(56));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(124));
            this.fieldpad0 = binaryReader.ReadBytes(8);
            this.fieldpad1 = binaryReader.ReadBytes(16);
            this.fieldpad2 = binaryReader.ReadBytes(16);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ShaderParameters = base.ReadBlockArrayData<GlobalShaderParameterBlock>(binaryReader, pointerQueue.Dequeue());
            this.Color.ReadInstances(binaryReader, pointerQueue);
            this.Alpha.ReadInstances(binaryReader, pointerQueue);
            this.Scale.ReadInstances(binaryReader, pointerQueue);
            this.Rotation.ReadInstances(binaryReader, pointerQueue);
            this.FrameIndex.ReadInstances(binaryReader, pointerQueue);
            this.Locations = base.ReadBlockArrayData<EffectLocationsBlock>(binaryReader, pointerQueue.Dequeue());
            this.AttachedParticleSystems = base.ReadBlockArrayData<ParticleSystemDefinitionBlockNew>(binaryReader, pointerQueue.Dequeue());
            this.ShaderPostprocessDefinitionNewBlock = base.ReadBlockArrayData<ShaderPostprocessDefinitionNewBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.ShaderParameters);
            this.Color.QueueWrites(queueableBinaryWriter);
            this.Alpha.QueueWrites(queueableBinaryWriter);
            this.Scale.QueueWrites(queueableBinaryWriter);
            this.Rotation.QueueWrites(queueableBinaryWriter);
            this.FrameIndex.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Locations);
            queueableBinaryWriter.QueueWrite(this.AttachedParticleSystems);
            queueableBinaryWriter.QueueWrite(this.ShaderPostprocessDefinitionNewBlock);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.ParticleFlags)));
            queueableBinaryWriter.Write(((short)(this.ParticleBillboardStyle)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.FirstSequenceIndex);
            queueableBinaryWriter.Write(this.SequenceCount);
            queueableBinaryWriter.Write(this.ShaderTemplate);
            queueableBinaryWriter.WritePointer(this.ShaderParameters);
            this.Color.Write_(queueableBinaryWriter);
            this.Alpha.Write_(queueableBinaryWriter);
            this.Scale.Write_(queueableBinaryWriter);
            this.Rotation.Write_(queueableBinaryWriter);
            this.FrameIndex.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.CollisionEffect);
            queueableBinaryWriter.Write(this.DeathEffect);
            queueableBinaryWriter.WritePointer(this.Locations);
            queueableBinaryWriter.WritePointer(this.AttachedParticleSystems);
            queueableBinaryWriter.WritePointer(this.ShaderPostprocessDefinitionNewBlock);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.fieldpad2);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Spins = 1,
            RandomUMirror = 2,
            RandomVMirror = 4,
            FrameAnimationOneShot = 8,
            SelectRandomSequence = 16,
            DisableFrameBlending = 32,
            CanAnimateBackwards = 64,
            ReceiveLightmapLighting = 128,
            TintFromDiffuseTexture = 256,
            DiesAtRest = 512,
            DiesOnStructureCollision = 1024,
            DiesInMedia = 2048,
            DiesInAir = 4096,
            BitmapAuthoredVertically = 8192,
            HasSweetener = 16384,
        }
        public enum ParticleBillboardStyleEnum : short
        {
            ScreenFacing = 0,
            ParallelToDirection = 1,
            PerpendicularToDirection = 2,
            Vertical = 3,
            Horizontal = 4,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Prt3 = ((TagClass)("prt3"));
    }
}
