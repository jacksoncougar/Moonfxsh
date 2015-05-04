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
    public partial class InstantaneousDamageRepsonseBlock : InstantaneousDamageRepsonseBlockBase
    {
        public InstantaneousDamageRepsonseBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class InstantaneousDamageRepsonseBlockBase : GuerillaBlock
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
        internal Moonfish.Tags.StringIdent region;
        internal NewState newState;
        internal short runtimeRegionIndex;
        internal Moonfish.Tags.StringIdent effectMarkerName;
        internal InstantaneousResponseDamageEffectMarkerStructBlock damageEffectMarker;
        /// <summary>
        /// in seconds
        /// </summary>
        internal float responseDelay;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference delayEffect;
        internal Moonfish.Tags.StringIdent delayEffectMarkerName;
        internal Moonfish.Tags.StringIdent constraintGroupName;
        internal Moonfish.Tags.StringIdent ejectingSeatLabel;
        internal float skipFraction;
        internal Moonfish.Tags.StringIdent destroyedChildObjectMarkerName;
        internal float totalDamageThreshold;
        public override int SerializedSize { get { return 80; } }
        public override int Alignment { get { return 4; } }
        public InstantaneousDamageRepsonseBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            responseType = (ResponseType)binaryReader.ReadInt16();
            constraintDamageType = (ConstraintDamageType)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
            damageThreshold = binaryReader.ReadSingle();
            transitionEffect = binaryReader.ReadTagReference();
            damageEffect = new InstantaneousResponseDamageEffectStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(damageEffect.ReadFields(binaryReader)));
            region = binaryReader.ReadStringID();
            newState = (NewState)binaryReader.ReadInt16();
            runtimeRegionIndex = binaryReader.ReadInt16();
            effectMarkerName = binaryReader.ReadStringID();
            damageEffectMarker = new InstantaneousResponseDamageEffectMarkerStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(damageEffectMarker.ReadFields(binaryReader)));
            responseDelay = binaryReader.ReadSingle();
            delayEffect = binaryReader.ReadTagReference();
            delayEffectMarkerName = binaryReader.ReadStringID();
            constraintGroupName = binaryReader.ReadStringID();
            ejectingSeatLabel = binaryReader.ReadStringID();
            skipFraction = binaryReader.ReadSingle();
            destroyedChildObjectMarkerName = binaryReader.ReadStringID();
            totalDamageThreshold = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            damageEffect.ReadPointers(binaryReader, blamPointers);
            damageEffectMarker.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)responseType);
                binaryWriter.Write((Int16)constraintDamageType);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(damageThreshold);
                binaryWriter.Write(transitionEffect);
                damageEffect.Write(binaryWriter);
                binaryWriter.Write(region);
                binaryWriter.Write((Int16)newState);
                binaryWriter.Write(runtimeRegionIndex);
                binaryWriter.Write(effectMarkerName);
                damageEffectMarker.Write(binaryWriter);
                binaryWriter.Write(responseDelay);
                binaryWriter.Write(delayEffect);
                binaryWriter.Write(delayEffectMarkerName);
                binaryWriter.Write(constraintGroupName);
                binaryWriter.Write(ejectingSeatLabel);
                binaryWriter.Write(skipFraction);
                binaryWriter.Write(destroyedChildObjectMarkerName);
                binaryWriter.Write(totalDamageThreshold);
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
