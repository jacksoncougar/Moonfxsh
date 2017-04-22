//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("character_weapons_block")]
    public partial class CharacterWeaponsBlock : GuerillaBlock, IWriteQueueable
    {
        public WeaponsFlags CharacterWeaponsWeaponsFlags;
        [Moonfish.Tags.TagReferenceAttribute("weap")]
        public Moonfish.Tags.TagReference Weapon;
        public float MaximumFiringRange;
        public float MinimumFiringRange;
        public Moonfish.Model.Range NormalCombatRange;
        public float BombardmentRange;
        public float MaxSpecialTargetDistance;
        public Moonfish.Model.Range TimidCombatRange;
        public Moonfish.Model.Range AggressiveCombatRange;
        public float SuperballisticRange;
        public Moonfish.Model.Range BallisticFiringBounds;
        public Moonfish.Model.Range BallisticFractionBounds;
        public Moonfish.Model.Range FirstBurstDelayTime;
        public float SurpriseDelayTime;
        public float SurpriseFirewildlyTime;
        public float DeathFirewildlyChance;
        public float DeathFirewildlyTime;
        public OpenTK.Vector3 CustomStandGunOffset;
        public OpenTK.Vector3 CustomCrouchGunOffset;
        public SpecialfireModeEnum SpecialfireMode;
        public SpecialfireSituationEnum SpecialfireSituation;
        public float SpecialfireChance;
        public float SpecialfireDelay;
        public float SpecialDamageModifier;
        public float SpecialProjectileError;
        public Moonfish.Model.Range DropWeaponLoaded;
        public int DropWeaponAmmo;
        /// <summary>
        /// Parameters control how accuracy changes over the duration of a series of bursts
        ///Accuracy is an analog value between 0 and 1. At zero, the parameters of the first
        ///firing-pattern block is used. At 1, the parameters in the second block is used. In
        ///between, all the values are linearly interpolated
        /// </summary>
        public Moonfish.Model.Range NormalAccuracyBounds;
        public float NormalAccuracyTime;
        public Moonfish.Model.Range HeroicAccuracyBounds;
        public float HeroicAccuracyTime;
        public Moonfish.Model.Range LegendaryAccuracyBounds;
        public float LegendaryAccuracyTime;
        public CharacterFiringPatternBlock[] FiringPatterns = new CharacterFiringPatternBlock[0];
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference WeaponMeleeDamage;
        public override int SerializedSize
        {
            get
            {
                return 204;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.CharacterWeaponsWeaponsFlags = ((WeaponsFlags)(binaryReader.ReadInt32()));
            this.Weapon = binaryReader.ReadTagReference();
            this.MaximumFiringRange = binaryReader.ReadSingle();
            this.MinimumFiringRange = binaryReader.ReadSingle();
            this.NormalCombatRange = binaryReader.ReadRange();
            this.BombardmentRange = binaryReader.ReadSingle();
            this.MaxSpecialTargetDistance = binaryReader.ReadSingle();
            this.TimidCombatRange = binaryReader.ReadRange();
            this.AggressiveCombatRange = binaryReader.ReadRange();
            this.SuperballisticRange = binaryReader.ReadSingle();
            this.BallisticFiringBounds = binaryReader.ReadRange();
            this.BallisticFractionBounds = binaryReader.ReadRange();
            this.FirstBurstDelayTime = binaryReader.ReadRange();
            this.SurpriseDelayTime = binaryReader.ReadSingle();
            this.SurpriseFirewildlyTime = binaryReader.ReadSingle();
            this.DeathFirewildlyChance = binaryReader.ReadSingle();
            this.DeathFirewildlyTime = binaryReader.ReadSingle();
            this.CustomStandGunOffset = binaryReader.ReadVector3();
            this.CustomCrouchGunOffset = binaryReader.ReadVector3();
            this.SpecialfireMode = ((SpecialfireModeEnum)(binaryReader.ReadInt16()));
            this.SpecialfireSituation = ((SpecialfireSituationEnum)(binaryReader.ReadInt16()));
            this.SpecialfireChance = binaryReader.ReadSingle();
            this.SpecialfireDelay = binaryReader.ReadSingle();
            this.SpecialDamageModifier = binaryReader.ReadSingle();
            this.SpecialProjectileError = binaryReader.ReadSingle();
            this.DropWeaponLoaded = binaryReader.ReadRange();
            this.DropWeaponAmmo = binaryReader.ReadInt32();
            this.NormalAccuracyBounds = binaryReader.ReadRange();
            this.NormalAccuracyTime = binaryReader.ReadSingle();
            this.HeroicAccuracyBounds = binaryReader.ReadRange();
            this.HeroicAccuracyTime = binaryReader.ReadSingle();
            this.LegendaryAccuracyBounds = binaryReader.ReadRange();
            this.LegendaryAccuracyTime = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(64));
            this.WeaponMeleeDamage = binaryReader.ReadTagReference();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.FiringPatterns = base.ReadBlockArrayData<CharacterFiringPatternBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.FiringPatterns);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.CharacterWeaponsWeaponsFlags)));
            queueableBinaryWriter.Write(this.Weapon);
            queueableBinaryWriter.Write(this.MaximumFiringRange);
            queueableBinaryWriter.Write(this.MinimumFiringRange);
            queueableBinaryWriter.Write(this.NormalCombatRange);
            queueableBinaryWriter.Write(this.BombardmentRange);
            queueableBinaryWriter.Write(this.MaxSpecialTargetDistance);
            queueableBinaryWriter.Write(this.TimidCombatRange);
            queueableBinaryWriter.Write(this.AggressiveCombatRange);
            queueableBinaryWriter.Write(this.SuperballisticRange);
            queueableBinaryWriter.Write(this.BallisticFiringBounds);
            queueableBinaryWriter.Write(this.BallisticFractionBounds);
            queueableBinaryWriter.Write(this.FirstBurstDelayTime);
            queueableBinaryWriter.Write(this.SurpriseDelayTime);
            queueableBinaryWriter.Write(this.SurpriseFirewildlyTime);
            queueableBinaryWriter.Write(this.DeathFirewildlyChance);
            queueableBinaryWriter.Write(this.DeathFirewildlyTime);
            queueableBinaryWriter.Write(this.CustomStandGunOffset);
            queueableBinaryWriter.Write(this.CustomCrouchGunOffset);
            queueableBinaryWriter.Write(((short)(this.SpecialfireMode)));
            queueableBinaryWriter.Write(((short)(this.SpecialfireSituation)));
            queueableBinaryWriter.Write(this.SpecialfireChance);
            queueableBinaryWriter.Write(this.SpecialfireDelay);
            queueableBinaryWriter.Write(this.SpecialDamageModifier);
            queueableBinaryWriter.Write(this.SpecialProjectileError);
            queueableBinaryWriter.Write(this.DropWeaponLoaded);
            queueableBinaryWriter.Write(this.DropWeaponAmmo);
            queueableBinaryWriter.Write(this.NormalAccuracyBounds);
            queueableBinaryWriter.Write(this.NormalAccuracyTime);
            queueableBinaryWriter.Write(this.HeroicAccuracyBounds);
            queueableBinaryWriter.Write(this.HeroicAccuracyTime);
            queueableBinaryWriter.Write(this.LegendaryAccuracyBounds);
            queueableBinaryWriter.Write(this.LegendaryAccuracyTime);
            queueableBinaryWriter.WritePointer(this.FiringPatterns);
            queueableBinaryWriter.Write(this.WeaponMeleeDamage);
        }
        [System.FlagsAttribute()]
        public enum WeaponsFlags : int
        {
            None = 0,
            BurstingInhibitsMovement = 1,
            MustCrouchToShoot = 2,
            UseExtendedSafetosaveRange = 4,
        }
        public enum SpecialfireModeEnum : short
        {
            None = 0,
            Overcharge = 1,
            SecondaryTrigger = 2,
        }
        public enum SpecialfireSituationEnum : short
        {
            Never = 0,
            EnemyVisible = 1,
            EnemyOutOfSight = 2,
            Strafing = 3,
        }
    }
}
