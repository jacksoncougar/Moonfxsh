using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("prt3")]
    public  partial class ParticleBlock : ParticleBlockBase
    {
        public  ParticleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 188)]
    public class ParticleBlockBase
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
        internal  ParticleBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.particleBillboardStyle = (ParticleBillboardStyle)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.firstSequenceIndex = binaryReader.ReadInt16();
            this.sequenceCount = binaryReader.ReadInt16();
            this.shaderTemplate = binaryReader.ReadTagReference();
            this.shaderParameters = ReadGlobalShaderParameterBlockArray(binaryReader);
            this.color = new ParticlePropertyColorStructNewBlock(binaryReader);
            this.alpha = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.scale = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.rotation = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.frameIndex = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.collisionEffect = binaryReader.ReadTagReference();
            this.deathEffect = binaryReader.ReadTagReference();
            this.locations = ReadEffectLocationsBlockArray(binaryReader);
            this.attachedParticleSystems = ReadParticleSystemDefinitionBlockNewArray(binaryReader);
            this.shaderPostprocessDefinitionNewBlock = ReadShaderPostprocessDefinitionNewBlockArray(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.invalidName_1 = binaryReader.ReadBytes(16);
            this.invalidName_2 = binaryReader.ReadBytes(16);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual GlobalShaderParameterBlock[] ReadGlobalShaderParameterBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalShaderParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalShaderParameterBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalShaderParameterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EffectLocationsBlock[] ReadEffectLocationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectLocationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectLocationsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectLocationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleSystemDefinitionBlockNew[] ReadParticleSystemDefinitionBlockNewArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemDefinitionBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemDefinitionBlockNew[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemDefinitionBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessDefinitionNewBlock[] ReadShaderPostprocessDefinitionNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessDefinitionNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessDefinitionNewBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessDefinitionNewBlock(binaryReader);
                }
            }
            return array;
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
