using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ProjectileMaterialResponseBlock : ProjectileMaterialResponseBlockBase
    {
        public  ProjectileMaterialResponseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88)]
    public class ProjectileMaterialResponseBlockBase
    {
        internal Flags flags;
        internal Response response;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference dONOTUSEOLDEffect;
        internal Moonfish.Tags.StringID materialName;
        internal byte[] invalidName_;
        internal Response response0;
        internal Flags flags0;
        internal float chanceFraction01;
        internal Moonfish.Model.Range betweenDegrees;
        internal Moonfish.Model.Range andWorldUnitsPerSecond;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference dONOTUSEOLDEffect0;
        internal ScaleEffectsBy scaleEffectsBy;
        internal byte[] invalidName_0;
        /// <summary>
        /// the angle of incidence is randomly perturbed by at most this amount to simulate irregularity.
        /// </summary>
        internal float angularNoiseDegrees;
        /// <summary>
        /// the velocity is randomly perturbed by at most this amount to simulate irregularity.
        /// </summary>
        internal float velocityNoiseWorldUnitsPerSecond;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference dONOTUSEOLDDetonationEffect;
        /// <summary>
        /// the fraction of the projectile's velocity lost on penetration
        /// </summary>
        internal float initialFriction;
        /// <summary>
        /// the maximumDistance the projectile can travel through on object of this material
        /// </summary>
        internal float maximumDistance;
        /// <summary>
        /// the fraction of the projectile's velocity parallel to the surface lost on impact
        /// </summary>
        internal float parallelFriction;
        /// <summary>
        /// the fraction of the projectile's velocity perpendicular to the surface lost on impact
        /// </summary>
        internal float perpendicularFriction;
        internal  ProjectileMaterialResponseBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.response = (Response)binaryReader.ReadInt16();
            this.dONOTUSEOLDEffect = binaryReader.ReadTagReference();
            this.materialName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.response0 = (Response)binaryReader.ReadInt16();
            this.flags0 = (Flags)binaryReader.ReadInt16();
            this.chanceFraction01 = binaryReader.ReadSingle();
            this.betweenDegrees = binaryReader.ReadRange();
            this.andWorldUnitsPerSecond = binaryReader.ReadRange();
            this.dONOTUSEOLDEffect0 = binaryReader.ReadTagReference();
            this.scaleEffectsBy = (ScaleEffectsBy)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.angularNoiseDegrees = binaryReader.ReadSingle();
            this.velocityNoiseWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.dONOTUSEOLDDetonationEffect = binaryReader.ReadTagReference();
            this.initialFriction = binaryReader.ReadSingle();
            this.maximumDistance = binaryReader.ReadSingle();
            this.parallelFriction = binaryReader.ReadSingle();
            this.perpendicularFriction = binaryReader.ReadSingle();
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            CannotBeOverpenetrated = 1,
        };
        internal enum Response : short
        
        {
            ImpactDetonate = 0,
            Fizzle = 1,
            Overpenetrate = 2,
            Attach = 3,
            Bounce = 4,
            BounceDud = 5,
            FizzleRicochet = 6,
        };
        internal enum Response0 : short
        
        {
            ImpactDetonate = 0,
            Fizzle = 1,
            Overpenetrate = 2,
            Attach = 3,
            Bounce = 4,
            BounceDud = 5,
            FizzleRicochet = 6,
        };
        [FlagsAttribute]
        internal enum Flags0 : short
        
        {
            OnlyAgainstUnits = 1,
            NeverAgainstUnits = 2,
        };
        internal enum ScaleEffectsBy : short
        
        {
            Damage = 0,
            Angle = 1,
        };
    };
}
