// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Prt3 = (TagClass)"prt3";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("prt3")]
    public partial class ParticleBlock : ParticleBlockBase
    {
        public  ParticleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ParticleBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 188, Alignment = 4)]
    public class ParticleBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal ParticleBillboardStyle particleBillboardStyle;
        internal byte[] invalidName_;
        internal short firstSequenceIndex;
        internal short sequenceCount;
        [TagReference("stem")]
        internal Moonfish.Tags.TagReference shaderTemplate;
        internal GlobalShaderParameterBlock[] shaderParameters;
        internal ParticlePropertyColorStructNewBlock color;
        internal ParticlePropertyScalarStructNewBlock alpha;
        internal ParticlePropertyScalarStructNewBlock scale;
        internal ParticlePropertyScalarStructNewBlock rotation;
        internal ParticlePropertyScalarStructNewBlock frameIndex;
        /// <summary>
        /// effect, material effect or sound spawned when this particle collides with something
        /// </summary>
        [TagReference("null")]
        internal Moonfish.Tags.TagReference collisionEffect;
        /// <summary>
        /// effect, material effect or sound spawned when this particle dies
        /// </summary>
        [TagReference("null")]
        internal Moonfish.Tags.TagReference deathEffect;
        internal EffectLocationsBlock[] locations;
        internal ParticleSystemDefinitionBlockNew[] attachedParticleSystems;
        internal ShaderPostprocessDefinitionNewBlock[] shaderPostprocessDefinitionNewBlock;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        
        public override int SerializedSize{get { return 188; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ParticleBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            particleBillboardStyle = (ParticleBillboardStyle)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            firstSequenceIndex = binaryReader.ReadInt16();
            sequenceCount = binaryReader.ReadInt16();
            shaderTemplate = binaryReader.ReadTagReference();
            shaderParameters = Guerilla.ReadBlockArray<GlobalShaderParameterBlock>(binaryReader);
            color = new ParticlePropertyColorStructNewBlock(binaryReader);
            alpha = new ParticlePropertyScalarStructNewBlock(binaryReader);
            scale = new ParticlePropertyScalarStructNewBlock(binaryReader);
            rotation = new ParticlePropertyScalarStructNewBlock(binaryReader);
            frameIndex = new ParticlePropertyScalarStructNewBlock(binaryReader);
            collisionEffect = binaryReader.ReadTagReference();
            deathEffect = binaryReader.ReadTagReference();
            locations = Guerilla.ReadBlockArray<EffectLocationsBlock>(binaryReader);
            attachedParticleSystems = Guerilla.ReadBlockArray<ParticleSystemDefinitionBlockNew>(binaryReader);
            shaderPostprocessDefinitionNewBlock = Guerilla.ReadBlockArray<ShaderPostprocessDefinitionNewBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadBytes(16);
            invalidName_2 = binaryReader.ReadBytes(16);
        }
        public  ParticleBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            particleBillboardStyle = (ParticleBillboardStyle)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            firstSequenceIndex = binaryReader.ReadInt16();
            sequenceCount = binaryReader.ReadInt16();
            shaderTemplate = binaryReader.ReadTagReference();
            shaderParameters = Guerilla.ReadBlockArray<GlobalShaderParameterBlock>(binaryReader);
            color = new ParticlePropertyColorStructNewBlock(binaryReader);
            alpha = new ParticlePropertyScalarStructNewBlock(binaryReader);
            scale = new ParticlePropertyScalarStructNewBlock(binaryReader);
            rotation = new ParticlePropertyScalarStructNewBlock(binaryReader);
            frameIndex = new ParticlePropertyScalarStructNewBlock(binaryReader);
            collisionEffect = binaryReader.ReadTagReference();
            deathEffect = binaryReader.ReadTagReference();
            locations = Guerilla.ReadBlockArray<EffectLocationsBlock>(binaryReader);
            attachedParticleSystems = Guerilla.ReadBlockArray<ParticleSystemDefinitionBlockNew>(binaryReader);
            shaderPostprocessDefinitionNewBlock = Guerilla.ReadBlockArray<ShaderPostprocessDefinitionNewBlock>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadBytes(16);
            invalidName_2 = binaryReader.ReadBytes(16);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)particleBillboardStyle);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(firstSequenceIndex);
                binaryWriter.Write(sequenceCount);
                binaryWriter.Write(shaderTemplate);
                nextAddress = Guerilla.WriteBlockArray<GlobalShaderParameterBlock>(binaryWriter, shaderParameters, nextAddress);
                color.Write(binaryWriter);
                alpha.Write(binaryWriter);
                scale.Write(binaryWriter);
                rotation.Write(binaryWriter);
                frameIndex.Write(binaryWriter);
                binaryWriter.Write(collisionEffect);
                binaryWriter.Write(deathEffect);
                nextAddress = Guerilla.WriteBlockArray<EffectLocationsBlock>(binaryWriter, locations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ParticleSystemDefinitionBlockNew>(binaryWriter, attachedParticleSystems, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ShaderPostprocessDefinitionNewBlock>(binaryWriter, shaderPostprocessDefinitionNewBlock, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1, 0, 16);
                binaryWriter.Write(invalidName_2, 0, 16);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
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
        };
        internal enum ParticleBillboardStyle : short
        {
            ScreenFacing = 0,
            ParallelToDirection = 1,
            PerpendicularToDirection = 2,
            Vertical = 3,
            Horizontal = 4,
        };
    };
}
