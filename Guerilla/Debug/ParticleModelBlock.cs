// ReSharper disable All
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
        public  ParticleModelBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticleModelBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            orientation = (Orientation)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(16);
            shader = binaryReader.ReadTagReference();
            scaleX = new ParticlePropertyScalarStructNewBlock(binaryReader);
            scaleY = new ParticlePropertyScalarStructNewBlock(binaryReader);
            scaleZ = new ParticlePropertyScalarStructNewBlock(binaryReader);
            rotation = new ParticlePropertyScalarStructNewBlock(binaryReader);
            collisionEffect = binaryReader.ReadTagReference();
            deathEffect = binaryReader.ReadTagReference();
            ReadEffectLocationsBlockArray(binaryReader);
            ReadParticleSystemDefinitionBlockNewArray(binaryReader);
            ReadParticleModelsBlockArray(binaryReader);
            ReadParticleModelVerticesBlockArray(binaryReader);
            ReadParticleModelIndicesBlockArray(binaryReader);
            ReadCachedDataBlockArray(binaryReader);
            geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(16);
            invalidName_1 = binaryReader.ReadBytes(8);
            invalidName_2 = binaryReader.ReadBytes(4);
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
        internal  virtual ParticleModelsBlock[] ReadParticleModelsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleModelsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleModelsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleModelsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleModelVerticesBlock[] ReadParticleModelVerticesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleModelVerticesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleModelVerticesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleModelVerticesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleModelIndicesBlock[] ReadParticleModelIndicesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleModelIndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleModelIndicesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleModelIndicesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CachedDataBlock[] ReadCachedDataBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CachedDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CachedDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CachedDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEffectLocationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleSystemDefinitionBlockNewArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleModelsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleModelVerticesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleModelIndicesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCachedDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int32)orientation);
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(shader);
                scaleX.Write(binaryWriter);
                scaleY.Write(binaryWriter);
                scaleZ.Write(binaryWriter);
                rotation.Write(binaryWriter);
                binaryWriter.Write(collisionEffect);
                binaryWriter.Write(deathEffect);
                WriteEffectLocationsBlockArray(binaryWriter);
                WriteParticleSystemDefinitionBlockNewArray(binaryWriter);
                WriteParticleModelsBlockArray(binaryWriter);
                WriteParticleModelVerticesBlockArray(binaryWriter);
                WriteParticleModelIndicesBlockArray(binaryWriter);
                WriteCachedDataBlockArray(binaryWriter);
                geometrySectionInfo.Write(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 16);
                binaryWriter.Write(invalidName_1, 0, 8);
                binaryWriter.Write(invalidName_2, 0, 4);
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
