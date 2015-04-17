// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InstantaneousDamageRepsonseBlock : InstantaneousDamageRepsonseBlockBase
    {
        public InstantaneousDamageRepsonseBlock( BinaryReader binaryReader ) : base( binaryReader )
        {
        }
    };

    [LayoutAttribute( Size = 80, Alignment = 4 )]
    public class InstantaneousDamageRepsonseBlockBase : IGuerilla
    {
        internal ResponseType responseType;
        internal ConstraintDamageType constraintDamageType;
        internal Flags flags;

        /// <summary>
        /// repsonse fires after crossing this threshold.  1=full health
        /// </summary>
        internal float damageThreshold;

        [TagReference( "effe" )] internal Moonfish.Tags.TagReference transitionEffect;
        internal InstantaneousResponseDamageEffectStructBlock damageEffect;
        internal Moonfish.Tags.StringID region;
        internal NewState newState;
        internal short runtimeRegionIndex;
        internal Moonfish.Tags.StringID effectMarkerName;
        internal InstantaneousResponseDamageEffectMarkerStructBlock damageEffectMarker;

        /// <summary>
        /// in seconds
        /// </summary>
        internal float responseDelay;

        [TagReference( "effe" )] internal Moonfish.Tags.TagReference delayEffect;
        internal Moonfish.Tags.StringID delayEffectMarkerName;
        internal Moonfish.Tags.StringID constraintGroupName;
        internal Moonfish.Tags.StringID ejectingSeatLabel;
        internal float skipFraction;
        internal Moonfish.Tags.StringID destroyedChildObjectMarkerName;
        internal float totalDamageThreshold;

        internal InstantaneousDamageRepsonseBlockBase( BinaryReader binaryReader )
        {
            responseType = ( ResponseType ) binaryReader.ReadInt16( );
            constraintDamageType = ( ConstraintDamageType ) binaryReader.ReadInt16( );
            flags = ( Flags ) binaryReader.ReadInt32( );
            damageThreshold = binaryReader.ReadSingle( );
            transitionEffect = binaryReader.ReadTagReference( );
            damageEffect = new InstantaneousResponseDamageEffectStructBlock( binaryReader );
            region = binaryReader.ReadStringID( );
            newState = ( NewState ) binaryReader.ReadInt16( );
            runtimeRegionIndex = binaryReader.ReadInt16( );
            effectMarkerName = binaryReader.ReadStringID( );
            damageEffectMarker = new InstantaneousResponseDamageEffectMarkerStructBlock( binaryReader );
            responseDelay = binaryReader.ReadSingle( );
            delayEffect = binaryReader.ReadTagReference( );
            delayEffectMarkerName = binaryReader.ReadStringID( );
            constraintGroupName = binaryReader.ReadStringID( );
            ejectingSeatLabel = binaryReader.ReadStringID( );
            skipFraction = binaryReader.ReadSingle( );
            destroyedChildObjectMarkerName = binaryReader.ReadStringID( );
            totalDamageThreshold = binaryReader.ReadSingle( );
        }

        public int Write( System.IO.BinaryWriter binaryWriter, Int32 nextAddress )
        {
            using ( binaryWriter.BaseStream.Pin( ) )
            {
                binaryWriter.Write( ( Int16 ) responseType );
                binaryWriter.Write( ( Int16 ) constraintDamageType );
                binaryWriter.Write( ( Int32 ) flags );
                binaryWriter.Write( damageThreshold );
                binaryWriter.Write( transitionEffect );
                damageEffect.Write( binaryWriter );
                binaryWriter.Write( region );
                binaryWriter.Write( ( Int16 ) newState );
                binaryWriter.Write( runtimeRegionIndex );
                binaryWriter.Write( effectMarkerName );
                damageEffectMarker.Write( binaryWriter );
                binaryWriter.Write( responseDelay );
                binaryWriter.Write( delayEffect );
                binaryWriter.Write( delayEffectMarkerName );
                binaryWriter.Write( constraintGroupName );
                binaryWriter.Write( ejectingSeatLabel );
                binaryWriter.Write( skipFraction );
                binaryWriter.Write( destroyedChildObjectMarkerName );
                binaryWriter.Write( totalDamageThreshold );
                return nextAddress;
            }
        }

        internal enum ResponseType : short
        {
            ReceivesAllDamage = 0,
            ReceivesAreaEffectDamage = 1,
            ReceivesLocalDamage = 2,
        };

        internal enum ConstraintDamageType : short
        {
            None = 0,
            DestroyOneOfGroup = 1,
            DestroyEntireGroup = 2,
            LoosenOneOfGroup = 3,
            LoosenEntireGroup = 4,
        };

        [FlagsAttribute]
        internal enum Flags : int
        {
            KillsObject = 1,
            InhibitsMeleeAttack = 2,
            InhibitsWeaponAttack = 4,
            InhibitsWalking = 8,
            ForcesDropWeapon = 16,
            KillsWeaponPrimaryTrigger = 32,
            KillsWeaponSecondaryTrigger = 64,
            DestroysObject = 128,
            DamagesWeaponPrimaryTrigger = 256,
            DamagesWeaponSecondaryTrigger = 512,
            LightDamageLeftTurn = 1024,
            MajorDamageLeftTurn = 2048,
            LightDamageRightTurn = 4096,
            MajorDamageRightTurn = 8192,
            LightDamageEngine = 16384,
            MajorDamageEngine = 32768,
            KillsObjectNoPlayerSolo = 65536,
            CausesDetonation = 131072,
            DestroyAllGroupConstraints = 262144,
            KillsVariantObjects = 524288,
            ForceUnattachedEffects = 1048576,
            FiresUnderThreshold = 2097152,
            TriggersSpecialDeath = 4194304,
            OnlyOnSpecialDeath = 8388608,
            OnlyNOTOnSpecialDeath = 16777216,
        };

        internal enum NewState : short
        {
            Default = 0,
            MinorDamage = 1,
            MediumDamage = 2,
            MajorDamage = 3,
            Destroyed = 4,
        };
    };
}