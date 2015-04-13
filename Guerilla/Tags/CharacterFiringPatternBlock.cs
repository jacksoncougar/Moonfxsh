using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterFiringPatternBlock : CharacterFiringPatternBlockBase
    {
        public  CharacterFiringPatternBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class CharacterFiringPatternBlockBase
    {
        /// <summary>
        /// how many times per second we pull the trigger (zero = continuously held down)
        /// </summary>
        internal float rateOfFire;
        /// <summary>
        /// how well our bursts track moving targets. 0.0= fire at the position they were standing when we started the burst. 1.0= fire at current position
        /// </summary>
        internal float targetTracking01;
        /// <summary>
        /// how much we lead moving targets. 0.0= no prediction. 1.0= predict completely.
        /// </summary>
        internal float targetLeading01;
        /// <summary>
        /// how far away from the target the starting point is
        /// </summary>
        internal float burstOriginRadiusWorldUnits;
        /// <summary>
        /// the range from the horizontal that our starting error can be
        /// </summary>
        internal float burstOriginAngleDegrees;
        /// <summary>
        /// how far the burst point moves back towards the target (could be negative)
        /// </summary>
        internal Moonfish.Model.Range burstReturnLengthWorldUnits;
        /// <summary>
        /// the range from the horizontal that the return direction can be
        /// </summary>
        internal float burstReturnAngleDegrees;
        /// <summary>
        /// how long each burst we fire is
        /// </summary>
        internal Moonfish.Model.Range burstDurationSeconds;
        /// <summary>
        /// how long we wait between bursts
        /// </summary>
        internal Moonfish.Model.Range burstSeparationSeconds;
        /// <summary>
        /// what fraction of its normal damage our weapon inflicts (zero = no modifier)
        /// </summary>
        internal float weaponDamageModifier;
        /// <summary>
        /// error added to every projectile we fire
        /// </summary>
        internal float projectileErrorDegrees;
        /// <summary>
        /// the maximum rate at which we can sweep our fire (zero = unlimited)
        /// </summary>
        internal float burstAngularVelocityDegreesPerSecond;
        /// <summary>
        /// cap on the maximum angle by which we will miss target (restriction on burst origin radius
        /// </summary>
        internal float maximumErrorAngleDegrees;
        internal  CharacterFiringPatternBlockBase(BinaryReader binaryReader)
        {
            this.rateOfFire = binaryReader.ReadSingle();
            this.targetTracking01 = binaryReader.ReadSingle();
            this.targetLeading01 = binaryReader.ReadSingle();
            this.burstOriginRadiusWorldUnits = binaryReader.ReadSingle();
            this.burstOriginAngleDegrees = binaryReader.ReadSingle();
            this.burstReturnLengthWorldUnits = binaryReader.ReadRange();
            this.burstReturnAngleDegrees = binaryReader.ReadSingle();
            this.burstDurationSeconds = binaryReader.ReadRange();
            this.burstSeparationSeconds = binaryReader.ReadRange();
            this.weaponDamageModifier = binaryReader.ReadSingle();
            this.projectileErrorDegrees = binaryReader.ReadSingle();
            this.burstAngularVelocityDegreesPerSecond = binaryReader.ReadSingle();
            this.maximumErrorAngleDegrees = binaryReader.ReadSingle();
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
    };
}
