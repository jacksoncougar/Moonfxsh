// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass PRTM = (TagClass) "PRTM";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("PRTM")]
    public partial class ParticleModelBlock : ParticleModelBlockBase
    {
        public ParticleModelBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 220, Alignment = 4)]
    public class ParticleModelBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Orientation orientation;
        internal byte[] invalidName_;
        [TagReference("shad")] internal Moonfish.Tags.TagReference shader;
        internal ParticlePropertyScalarStructNewBlock scaleX;
        internal ParticlePropertyScalarStructNewBlock scaleY;
        internal ParticlePropertyScalarStructNewBlock scaleZ;
        internal ParticlePropertyScalarStructNewBlock rotation;

        /// <summary>
        /// effect, material effect or sound spawned when this particle collides with something
        /// </summary>
        [TagReference("null")] internal Moonfish.Tags.TagReference collisionEffect;

        /// <summary>
        /// effect, material effect or sound spawned when this particle dies
        /// </summary>
        [TagReference("null")] internal Moonfish.Tags.TagReference deathEffect;

        internal EffectLocationsBlock[] locations;
        internal ParticleSystemDefinitionBlockNew[] attachedParticleSystems;
        internal ParticleModelsBlock[] models;
        internal ParticleModelVerticesBlock[] rawVertices;
        internal ParticleModelIndicesBlock[] indices;
        internal CachedDataBlock[] cachedData;
        internal GlobalGeometryBlockInfoStructBlock geometrySectionInfo;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;

        public override int SerializedSize
        {
            get { return 220; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ParticleModelBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            orientation = (Orientation) binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(16);
            shader = binaryReader.ReadTagReference();
            scaleX = new ParticlePropertyScalarStructNewBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(scaleX.ReadFields(binaryReader)));
            scaleY = new ParticlePropertyScalarStructNewBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(scaleY.ReadFields(binaryReader)));
            scaleZ = new ParticlePropertyScalarStructNewBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(scaleZ.ReadFields(binaryReader)));
            rotation = new ParticlePropertyScalarStructNewBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(rotation.ReadFields(binaryReader)));
            collisionEffect = binaryReader.ReadTagReference();
            deathEffect = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<EffectLocationsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticleSystemDefinitionBlockNew>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticleModelsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticleModelVerticesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticleModelIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CachedDataBlock>(binaryReader));
            geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(geometrySectionInfo.ReadFields(binaryReader)));
            invalidName_0 = binaryReader.ReadBytes(16);
            invalidName_1 = binaryReader.ReadBytes(8);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            scaleX.ReadPointers(binaryReader, blamPointers);
            scaleY.ReadPointers(binaryReader, blamPointers);
            scaleZ.ReadPointers(binaryReader, blamPointers);
            rotation.ReadPointers(binaryReader, blamPointers);
            locations = ReadBlockArrayData<EffectLocationsBlock>(binaryReader, blamPointers.Dequeue());
            attachedParticleSystems = ReadBlockArrayData<ParticleSystemDefinitionBlockNew>(binaryReader,
                blamPointers.Dequeue());
            models = ReadBlockArrayData<ParticleModelsBlock>(binaryReader, blamPointers.Dequeue());
            rawVertices = ReadBlockArrayData<ParticleModelVerticesBlock>(binaryReader, blamPointers.Dequeue());
            indices = ReadBlockArrayData<ParticleModelIndicesBlock>(binaryReader, blamPointers.Dequeue());
            cachedData = ReadBlockArrayData<CachedDataBlock>(binaryReader, blamPointers.Dequeue());
            geometrySectionInfo.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write((Int32) orientation);
                binaryWriter.Write(invalidName_, 0, 16);
                binaryWriter.Write(shader);
                scaleX.Write(binaryWriter);
                scaleY.Write(binaryWriter);
                scaleZ.Write(binaryWriter);
                rotation.Write(binaryWriter);
                binaryWriter.Write(collisionEffect);
                binaryWriter.Write(deathEffect);
                nextAddress = Guerilla.WriteBlockArray<EffectLocationsBlock>(binaryWriter, locations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ParticleSystemDefinitionBlockNew>(binaryWriter,
                    attachedParticleSystems, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ParticleModelsBlock>(binaryWriter, models, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ParticleModelVerticesBlock>(binaryWriter, rawVertices,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ParticleModelIndicesBlock>(binaryWriter, indices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CachedDataBlock>(binaryWriter, cachedData, nextAddress);
                geometrySectionInfo.Write(binaryWriter);
                binaryWriter.Write(invalidName_0, 0, 16);
                binaryWriter.Write(invalidName_1, 0, 8);
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