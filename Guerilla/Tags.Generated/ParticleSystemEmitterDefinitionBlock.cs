// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleSystemEmitterDefinitionBlock : ParticleSystemEmitterDefinitionBlockBase
    {
        public ParticleSystemEmitterDefinitionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 184, Alignment = 4)]
    public class ParticleSystemEmitterDefinitionBlockBase : GuerillaBlock
    {
        [TagReference("pmov")]
        internal Moonfish.Tags.TagReference particlePhysics;
        internal ParticlePropertyScalarStructNewBlock particleEmissionRate;
        internal ParticlePropertyScalarStructNewBlock particleLifespan;
        internal ParticlePropertyScalarStructNewBlock particleVelocity;
        internal ParticlePropertyScalarStructNewBlock particleAngularVelocity;
        internal ParticlePropertyScalarStructNewBlock particleSize;
        internal ParticlePropertyColorStructNewBlock particleTint;
        internal ParticlePropertyScalarStructNewBlock particleAlpha;
        internal EmissionShape emissionShape;
        internal ParticlePropertyScalarStructNewBlock emissionRadius;
        internal ParticlePropertyScalarStructNewBlock emissionAngle;
        internal OpenTK.Vector3 translationalOffset;
        /// <summary>
        /// particle initial velocity direction relative to the location's forward
        /// </summary>
        internal OpenTK.Vector2 relativeDirection;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 184; } }
        public override int Alignment { get { return 4; } }
        public ParticleSystemEmitterDefinitionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            particlePhysics = binaryReader.ReadTagReference();
            particleEmissionRate = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(particleEmissionRate.ReadFields(binaryReader));
            particleLifespan = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(particleLifespan.ReadFields(binaryReader));
            particleVelocity = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(particleVelocity.ReadFields(binaryReader));
            particleAngularVelocity = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(particleAngularVelocity.ReadFields(binaryReader));
            particleSize = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(particleSize.ReadFields(binaryReader));
            particleTint = new ParticlePropertyColorStructNewBlock();
            blamPointers.Concat(particleTint.ReadFields(binaryReader));
            particleAlpha = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(particleAlpha.ReadFields(binaryReader));
            emissionShape = (EmissionShape)binaryReader.ReadInt32();
            emissionRadius = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(emissionRadius.ReadFields(binaryReader));
            emissionAngle = new ParticlePropertyScalarStructNewBlock();
            blamPointers.Concat(emissionAngle.ReadFields(binaryReader));
            translationalOffset = binaryReader.ReadVector3();
            relativeDirection = binaryReader.ReadVector2();
            invalidName_ = binaryReader.ReadBytes(8);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            particleEmissionRate.ReadPointers(binaryReader, blamPointers);
            particleLifespan.ReadPointers(binaryReader, blamPointers);
            particleVelocity.ReadPointers(binaryReader, blamPointers);
            particleAngularVelocity.ReadPointers(binaryReader, blamPointers);
            particleSize.ReadPointers(binaryReader, blamPointers);
            particleTint.ReadPointers(binaryReader, blamPointers);
            particleAlpha.ReadPointers(binaryReader, blamPointers);
            emissionRadius.ReadPointers(binaryReader, blamPointers);
            emissionAngle.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(particlePhysics);
                particleEmissionRate.Write(binaryWriter);
                particleLifespan.Write(binaryWriter);
                particleVelocity.Write(binaryWriter);
                particleAngularVelocity.Write(binaryWriter);
                particleSize.Write(binaryWriter);
                particleTint.Write(binaryWriter);
                particleAlpha.Write(binaryWriter);
                binaryWriter.Write((Int32)emissionShape);
                emissionRadius.Write(binaryWriter);
                emissionAngle.Write(binaryWriter);
                binaryWriter.Write(translationalOffset);
                binaryWriter.Write(relativeDirection);
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress;
            }
        }
        internal enum EmissionShape : int
        {
            Sprayer = 0,
            Disc = 1,
            Globe = 2,
            Implode = 3,
            Tube = 4,
            Halo = 5,
            ImpactContour = 6,
            ImpactArea = 7,
            Debris = 8,
            Line = 9,
        };
    };
}
