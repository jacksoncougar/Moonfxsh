using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("PRTM")]
    public  partial class ParticleModelBlock : ParticleModelBlockBase
    {
        public  ParticleModelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 224)]
    public class ParticleModelBlockBase
    {
        internal Flags flags;
        internal Orientation orientation;
        internal byte[] invalidName_;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal ParticlePropertyScalarStructNewBlock scaleX;
        internal ParticlePropertyScalarStructNewBlock scaleY;
        internal ParticlePropertyScalarStructNewBlock scaleZ;
        internal ParticlePropertyScalarStructNewBlock rotation;
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
        internal ParticleModelsBlock[] models;
        internal ParticleModelVerticesBlock[] rawVertices;
        internal ParticleModelIndicesBlock[] indices;
        internal CachedDataBlock[] cachedData;
        internal GlobalGeometryBlockInfoStructBlock geometrySectionInfo;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  ParticleModelBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.orientation = (Orientation)binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(16);
            this.shader = binaryReader.ReadTagReference();
            this.scaleX = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.scaleY = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.scaleZ = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.rotation = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.collisionEffect = binaryReader.ReadTagReference();
            this.deathEffect = binaryReader.ReadTagReference();
            this.locations = ReadEffectLocationsBlockArray(binaryReader);
            this.attachedParticleSystems = ReadParticleSystemDefinitionBlockNewArray(binaryReader);
            this.models = ReadParticleModelsBlockArray(binaryReader);
            this.rawVertices = ReadParticleModelVerticesBlockArray(binaryReader);
            this.indices = ReadParticleModelIndicesBlockArray(binaryReader);
            this.cachedData = ReadCachedDataBlockArray(binaryReader);
            this.geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            this.invalidName_0 = binaryReader.ReadBytes(16);
            this.invalidName_1 = binaryReader.ReadBytes(8);
            this.invalidName_2 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual EffectLocationsBlock[] ReadEffectLocationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectLocationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectLocationsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
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
            var array = new ParticleSystemDefinitionBlockNew[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemDefinitionBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleModelsBlock[] ReadParticleModelsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleModelsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleModelsBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleModelsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleModelVerticesBlock[] ReadParticleModelVerticesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleModelVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleModelVerticesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleModelVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleModelIndicesBlock[] ReadParticleModelIndicesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleModelIndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleModelIndicesBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleModelIndicesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CachedDataBlock[] ReadCachedDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CachedDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CachedDataBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CachedDataBlock(binaryReader);
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
        internal enum Orientation : int
        
        {
            ScreenFacing = 0,
            ParallelToDirection = 1,
            PerpendicularToDirection = 2,
            Vertical = 3,
            Horizontal = 4,
        };
    };
}
