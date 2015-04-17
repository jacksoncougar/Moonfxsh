// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterFiringPatternBlock : CharacterFiringPatternBlockBase
    {
        public CharacterFiringPatternBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 64, Alignment = 4 )]
    public class CharacterFiringPatternBlockBase : IGuerilla
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

        internal CharacterFiringPatternBlockBase( BinaryReader binaryReader )
        {
            rateOfFire = binaryReader.ReadSingle( );
            targetTracking01 = binaryReader.ReadSingle( );
            targetLeading01 = binaryReader.ReadSingle( );
            burstOriginRadiusWorldUnits = binaryReader.ReadSingle( );
            burstOriginAngleDegrees = binaryReader.ReadSingle( );
            burstReturnLengthWorldUnits = binaryReader.ReadRange( );
            burstReturnAngleDegrees = binaryReader.ReadSingle( );
            burstDurationSeconds = binaryReader.ReadRange( );
            burstSeparationSeconds = binaryReader.ReadRange( );
            weaponDamageModifier = binaryReader.ReadSingle( );
            projectileErrorDegrees = binaryReader.ReadSingle( );
            burstAngularVelocityDegreesPerSecond = binaryReader.ReadSingle( );
            maximumErrorAngleDegrees = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( rateOfFire );
                binaryWriter.Write( targetTracking01 );
                binaryWriter.Write( targetLeading01 );
                binaryWriter.Write( burstOriginRadiusWorldUnits );
                binaryWriter.Write( burstOriginAngleDegrees );
                binaryWriter.Write( burstReturnLengthWorldUnits );
                binaryWriter.Write( burstReturnAngleDegrees );
                binaryWriter.Write( burstDurationSeconds );
                binaryWriter.Write( burstSeparationSeconds );
                binaryWriter.Write( weaponDamageModifier );
                binaryWriter.Write( projectileErrorDegrees );
                binaryWriter.Write( burstAngularVelocityDegreesPerSecond );
                binaryWriter.Write( maximumErrorAngleDegrees );
                return nextAddress;
            }
        }
    };
}