// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterChargeBlock : CharacterChargeBlockBase
    {
        public CharacterChargeBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 64, Alignment = 4 )]
    public class CharacterChargeBlockBase : IGuerilla
    {
        internal ChargeFlags chargeFlags;
        internal float meleeConsiderRange;

        /// <summary>
        /// chance of initiating a melee within a 1 second period
        /// </summary>
        internal float meleeChance;

        internal float meleeAttackRange;
        internal float meleeAbortRange;

        /// <summary>
        /// Give up after given amount of time spent charging
        /// </summary>
        internal float meleeAttackTimeoutSeconds;

        /// <summary>
        /// don't attempt again before given time since last melee
        /// </summary>
        internal float meleeAttackDelayTimerSeconds;

        internal Moonfish.Model.Range meleeLeapRange;
        internal float meleeLeapChance;
        internal float idealLeapVelocity;
        internal float maxLeapVelocity;
        internal float meleeLeapBallistic;

        /// <summary>
        /// time between melee leaps
        /// </summary>
        internal float meleeDelayTimerSeconds;

        /// <summary>
        /// when I berserk, I pull out a ...
        /// </summary>
        [TagReference( "weap" )] internal Moonfish.Tags.TagReference berserkWeapon;

        internal CharacterChargeBlockBase( BinaryReader binaryReader )
        {
            chargeFlags = ( ChargeFlags ) binaryReader.ReadInt32( );
            meleeConsiderRange = binaryReader.ReadSingle( );
            meleeChance = binaryReader.ReadSingle( );
            meleeAttackRange = binaryReader.ReadSingle( );
            meleeAbortRange = binaryReader.ReadSingle( );
            meleeAttackTimeoutSeconds = binaryReader.ReadSingle( );
            meleeAttackDelayTimerSeconds = binaryReader.ReadSingle( );
            meleeLeapRange = binaryReader.ReadRange( );
            meleeLeapChance = binaryReader.ReadSingle( );
            idealLeapVelocity = binaryReader.ReadSingle( );
            maxLeapVelocity = binaryReader.ReadSingle( );
            meleeLeapBallistic = binaryReader.ReadSingle( );
            meleeDelayTimerSeconds = binaryReader.ReadSingle( );
            berserkWeapon = binaryReader.ReadTagReference( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int32 ) chargeFlags );
                binaryWriter.Write( meleeConsiderRange );
                binaryWriter.Write( meleeChance );
                binaryWriter.Write( meleeAttackRange );
                binaryWriter.Write( meleeAbortRange );
                binaryWriter.Write( meleeAttackTimeoutSeconds );
                binaryWriter.Write( meleeAttackDelayTimerSeconds );
                binaryWriter.Write( meleeLeapRange );
                binaryWriter.Write( meleeLeapChance );
                binaryWriter.Write( idealLeapVelocity );
                binaryWriter.Write( maxLeapVelocity );
                binaryWriter.Write( meleeLeapBallistic );
                binaryWriter.Write( meleeDelayTimerSeconds );
                binaryWriter.Write( berserkWeapon );
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum ChargeFlags : int
        {
            OffhandMeleeAllowed = 1,
            BerserkWheneverCharge = 2,
        };
    };
}