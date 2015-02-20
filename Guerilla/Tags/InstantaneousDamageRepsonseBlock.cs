using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 80)]
    public  partial class InstantaneousDamageRepsonseBlock : InstantaneousDamageRepsonseBlockBase
    {
        public  InstantaneousDamageRepsonseBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class InstantaneousDamageRepsonseBlockBase
    {
        internal ResponseType responseType;
        internal ConstraintDamageType constraintDamageType;
        internal Flags flags;
        /// <summary>
        /// repsonse fires after crossing this threshold.  1=full health
        /// </summary>
        internal float damageThreshold;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference transitionEffect;
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
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference delayEffect;
        internal Moonfish.Tags.StringID delayEffectMarkerName;
        internal Moonfish.Tags.StringID constraintGroupName;
        internal Moonfish.Tags.StringID ejectingSeatLabel;
        internal float skipFraction;
        internal Moonfish.Tags.StringID destroyedChildObjectMarkerName;
        internal float totalDamageThreshold;
        internal  InstantaneousDamageRepsonseBlockBase(BinaryReader binaryReader)
        {
            this.responseType = (ResponseType)binaryReader.ReadInt16();
            this.constraintDamageType = (ConstraintDamageType)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.damageThreshold = binaryReader.ReadSingle();
            this.transitionEffect = binaryReader.ReadTagReference();
            this.damageEffect = new InstantaneousResponseDamageEffectStructBlock(binaryReader);
            this.region = binaryReader.ReadStringID();
            this.newState = (NewState)binaryReader.ReadInt16();
            this.runtimeRegionIndex = binaryReader.ReadInt16();
            this.effectMarkerName = binaryReader.ReadStringID();
            this.damageEffectMarker = new InstantaneousResponseDamageEffectMarkerStructBlock(binaryReader);
            this.responseDelay = binaryReader.ReadSingle();
            this.delayEffect = binaryReader.ReadTagReference();
            this.delayEffectMarkerName = binaryReader.ReadStringID();
            this.constraintGroupName = binaryReader.ReadStringID();
            this.ejectingSeatLabel = binaryReader.ReadStringID();
            this.skipFraction = binaryReader.ReadSingle();
            this.destroyedChildObjectMarkerName = binaryReader.ReadStringID();
            this.totalDamageThreshold = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
