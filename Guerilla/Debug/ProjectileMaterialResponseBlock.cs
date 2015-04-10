// ReSharper disable All
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
        public  ProjectileMaterialResponseBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ProjectileMaterialResponseBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            response = (Response)binaryReader.ReadInt16();
            dONOTUSEOLDEffect = binaryReader.ReadTagReference();
            materialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            response0 = (Response)binaryReader.ReadInt16();
            flags0 = (Flags)binaryReader.ReadInt16();
            chanceFraction01 = binaryReader.ReadSingle();
            betweenDegrees = binaryReader.ReadRange();
            andWorldUnitsPerSecond = binaryReader.ReadRange();
            dONOTUSEOLDEffect0 = binaryReader.ReadTagReference();
            scaleEffectsBy = (ScaleEffectsBy)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            angularNoiseDegrees = binaryReader.ReadSingle();
            velocityNoiseWorldUnitsPerSecond = binaryReader.ReadSingle();
            dONOTUSEOLDDetonationEffect = binaryReader.ReadTagReference();
            initialFriction = binaryReader.ReadSingle();
            maximumDistance = binaryReader.ReadSingle();
            parallelFriction = binaryReader.ReadSingle();
            perpendicularFriction = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)response);
                binaryWriter.Write(dONOTUSEOLDEffect);
                binaryWriter.Write(materialName);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Int16)response0);
                binaryWriter.Write((Int16)flags0);
                binaryWriter.Write(chanceFraction01);
                binaryWriter.Write(betweenDegrees);
                binaryWriter.Write(andWorldUnitsPerSecond);
                binaryWriter.Write(dONOTUSEOLDEffect0);
                binaryWriter.Write((Int16)scaleEffectsBy);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(angularNoiseDegrees);
                binaryWriter.Write(velocityNoiseWorldUnitsPerSecond);
                binaryWriter.Write(dONOTUSEOLDDetonationEffect);
                binaryWriter.Write(initialFriction);
                binaryWriter.Write(maximumDistance);
                binaryWriter.Write(parallelFriction);
                binaryWriter.Write(perpendicularFriction);
            }
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
