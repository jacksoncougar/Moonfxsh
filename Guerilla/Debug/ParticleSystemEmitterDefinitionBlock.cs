// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleSystemEmitterDefinitionBlock : ParticleSystemEmitterDefinitionBlockBase
    {
        public  ParticleSystemEmitterDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 184)]
    public class ParticleSystemEmitterDefinitionBlockBase
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
        internal  ParticleSystemEmitterDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            particlePhysics = binaryReader.ReadTagReference();
            particleEmissionRate = new ParticlePropertyScalarStructNewBlock(binaryReader);
            particleLifespan = new ParticlePropertyScalarStructNewBlock(binaryReader);
            particleVelocity = new ParticlePropertyScalarStructNewBlock(binaryReader);
            particleAngularVelocity = new ParticlePropertyScalarStructNewBlock(binaryReader);
            particleSize = new ParticlePropertyScalarStructNewBlock(binaryReader);
            particleTint = new ParticlePropertyColorStructNewBlock(binaryReader);
            particleAlpha = new ParticlePropertyScalarStructNewBlock(binaryReader);
            emissionShape = (EmissionShape)binaryReader.ReadInt32();
            emissionRadius = new ParticlePropertyScalarStructNewBlock(binaryReader);
            emissionAngle = new ParticlePropertyScalarStructNewBlock(binaryReader);
            translationalOffset = binaryReader.ReadVector3();
            relativeDirection = binaryReader.ReadVector2();
            invalidName_ = binaryReader.ReadBytes(8);
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
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
