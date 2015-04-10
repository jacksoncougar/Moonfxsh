// ReSharper disable All
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
        public  ParticleBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticleBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            particleBillboardStyle = (ParticleBillboardStyle)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            firstSequenceIndex = binaryReader.ReadInt16();
            sequenceCount = binaryReader.ReadInt16();
            shaderTemplate = binaryReader.ReadTagReference();
            ReadGlobalShaderParameterBlockArray(binaryReader);
            color = new ParticlePropertyColorStructNewBlock(binaryReader);
            alpha = new ParticlePropertyScalarStructNewBlock(binaryReader);
            scale = new ParticlePropertyScalarStructNewBlock(binaryReader);
            rotation = new ParticlePropertyScalarStructNewBlock(binaryReader);
            frameIndex = new ParticlePropertyScalarStructNewBlock(binaryReader);
            collisionEffect = binaryReader.ReadTagReference();
            deathEffect = binaryReader.ReadTagReference();
            ReadEffectLocationsBlockArray(binaryReader);
            ReadParticleSystemDefinitionBlockNewArray(binaryReader);
            ReadShaderPostprocessDefinitionNewBlockArray(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadBytes(16);
            invalidName_2 = binaryReader.ReadBytes(16);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual GlobalShaderParameterBlock[] ReadGlobalShaderParameterBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalShaderParameterBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalShaderParameterBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalShaderParameterBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EffectLocationsBlock[] ReadEffectLocationsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectLocationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectLocationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectLocationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleSystemDefinitionBlockNew[] ReadParticleSystemDefinitionBlockNewArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemDefinitionBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemDefinitionBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemDefinitionBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessDefinitionNewBlock[] ReadShaderPostprocessDefinitionNewBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessDefinitionNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessDefinitionNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessDefinitionNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalShaderParameterBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEffectLocationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleSystemDefinitionBlockNewArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessDefinitionNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)particleBillboardStyle);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(firstSequenceIndex);
                binaryWriter.Write(sequenceCount);
                binaryWriter.Write(shaderTemplate);
                WriteGlobalShaderParameterBlockArray(binaryWriter);
                color.Write(binaryWriter);
                alpha.Write(binaryWriter);
                scale.Write(binaryWriter);
                rotation.Write(binaryWriter);
                frameIndex.Write(binaryWriter);
                binaryWriter.Write(collisionEffect);
                binaryWriter.Write(deathEffect);
                WriteEffectLocationsBlockArray(binaryWriter);
                WriteParticleSystemDefinitionBlockNewArray(binaryWriter);
                WriteShaderPostprocessDefinitionNewBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1, 0, 16);
                binaryWriter.Write(invalidName_2, 0, 16);
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
