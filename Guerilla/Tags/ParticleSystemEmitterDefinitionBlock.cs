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
        public  ParticleSystemEmitterDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticleSystemEmitterDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.particlePhysics = binaryReader.ReadTagReference();
            this.particleEmissionRate = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.particleLifespan = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.particleVelocity = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.particleAngularVelocity = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.particleSize = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.particleTint = new ParticlePropertyColorStructNewBlock(binaryReader);
            this.particleAlpha = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.emissionShape = (EmissionShape)binaryReader.ReadInt32();
            this.emissionRadius = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.emissionAngle = new ParticlePropertyScalarStructNewBlock(binaryReader);
            this.translationalOffset = binaryReader.ReadVector3();
            this.relativeDirection = binaryReader.ReadVector2();
            this.invalidName_ = binaryReader.ReadBytes(8);
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
