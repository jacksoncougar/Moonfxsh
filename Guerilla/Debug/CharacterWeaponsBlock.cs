// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterWeaponsBlock : CharacterWeaponsBlockBase
    {
        public  CharacterWeaponsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 204)]
    public class CharacterWeaponsBlockBase
    {
        internal WeaponsFlags weaponsFlags;
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference weapon;
        /// <summary>
        /// we can only fire our weapon at targets within this distance
        /// </summary>
        internal float maximumFiringRangeWorldUnits;
        /// <summary>
        /// weapon will not be fired at target closer than given distance
        /// </summary>
        internal float minimumFiringRange;
        internal Moonfish.Model.Range normalCombatRangeWorldUnits;
        /// <summary>
        /// we offset our burst targets randomly by this range when firing at non-visible enemies (zero = never)
        /// </summary>
        internal float bombardmentRange;
        /// <summary>
        /// Specific target regions on a vehicle or unit will be fired upon only under the given distance
        /// </summary>
        internal float maxSpecialTargetDistanceWorldUnits;
        internal Moonfish.Model.Range timidCombatRangeWorldUnits;
        internal Moonfish.Model.Range aggressiveCombatRangeWorldUnits;
        /// <summary>
        /// we try to aim our shots super-ballistically if target is outside this range (zero = never)
        /// </summary>
        internal float superBallisticRange;
        /// <summary>
        /// At the min range, the min ballistic fraction is used, at the max, the max ballistic fraction is used
        /// </summary>
        internal Moonfish.Model.Range ballisticFiringBoundsWorldUnits;
        /// <summary>
        /// Controls speed and degree of arc. 0 = high, slow, 1 = low, fast
        /// </summary>
        internal Moonfish.Model.Range ballisticFractionBounds01;
        internal Moonfish.Model.Range firstBurstDelayTimeSeconds;
        internal float surpriseDelayTimeSeconds;
        internal float surpriseFireWildlyTimeSeconds;
        internal float deathFireWildlyChance01;
        internal float deathFireWildlyTimeSeconds;
        /// <summary>
        /// custom standing gun offset for overriding the default in the base actor
        /// </summary>
        internal OpenTK.Vector3 customStandGunOffset;
        /// <summary>
        /// custom crouching gun offset for overriding the default in the base actor
        /// </summary>
        internal OpenTK.Vector3 customCrouchGunOffset;
        /// <summary>
        /// the type of special weapon fire that we can use
        /// </summary>
        internal SpecialFireModeTheTypeOfSpecialWeaponFireThatWeCanUse specialFireMode;
        /// <summary>
        /// when we will decide to use our special weapon fire mode
        /// </summary>
        internal SpecialFireSituationWhenWeWillDecideToUseOurSpecialWeaponFireMode specialFireSituation;
        /// <summary>
        /// how likely we are to use our special weapon fire mode
        /// </summary>
        internal float specialFireChance01;
        /// <summary>
        /// how long we must wait between uses of our special weapon fire mode
        /// </summary>
        internal float specialFireDelaySeconds;
        /// <summary>
        /// damage modifier for special weapon fire (applied in addition to the normal damage modifier. zero = no change)
        /// </summary>
        internal float specialDamageModifier01;
        /// <summary>
        /// projectile error angle for special weapon fire (applied in addition to the normal error)
        /// </summary>
        internal float specialProjectileErrorDegrees;
        /// <summary>
        /// amount of ammo loaded into the weapon that we drop (in fractions of a clip, e.g. 0.3 to 0.5)
        /// </summary>
        internal Moonfish.Model.Range dropWeaponLoaded;
        /// <summary>
        /// total number of rounds in the weapon that we drop (ignored for energy weapons)
        /// </summary>
        internal int dropWeaponAmmo;
        /// <summary>
        /// Indicates starting and ending accuracies at normal difficulty
        /// </summary>
        internal Moonfish.Model.Range normalAccuracyBounds;
        /// <summary>
        /// The amount of time it takes the accuracy to go from starting to ending
        /// </summary>
        internal float normalAccuracyTime;
        /// <summary>
        /// Indicates starting and ending accuracies at heroic difficulty
        /// </summary>
        internal Moonfish.Model.Range heroicAccuracyBounds;
        /// <summary>
        /// The amount of time it takes the accuracy to go from starting to ending
        /// </summary>
        internal float heroicAccuracyTime;
        /// <summary>
        /// Indicates starting and ending accuracies at legendary difficulty
        /// </summary>
        internal Moonfish.Model.Range legendaryAccuracyBounds;
        /// <summary>
        /// The amount of time it takes the accuracy to go from starting to ending
        /// </summary>
        internal float legendaryAccuracyTime;
        internal CharacterFiringPatternBlock[] firingPatterns;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference weaponMeleeDamage;
        internal  CharacterWeaponsBlockBase(System.IO.BinaryReader binaryReader)
        {
            weaponsFlags = (WeaponsFlags)binaryReader.ReadInt32();
            weapon = binaryReader.ReadTagReference();
            maximumFiringRangeWorldUnits = binaryReader.ReadSingle();
            minimumFiringRange = binaryReader.ReadSingle();
            normalCombatRangeWorldUnits = binaryReader.ReadRange();
            bombardmentRange = binaryReader.ReadSingle();
            maxSpecialTargetDistanceWorldUnits = binaryReader.ReadSingle();
            timidCombatRangeWorldUnits = binaryReader.ReadRange();
            aggressiveCombatRangeWorldUnits = binaryReader.ReadRange();
            superBallisticRange = binaryReader.ReadSingle();
            ballisticFiringBoundsWorldUnits = binaryReader.ReadRange();
            ballisticFractionBounds01 = binaryReader.ReadRange();
            firstBurstDelayTimeSeconds = binaryReader.ReadRange();
            surpriseDelayTimeSeconds = binaryReader.ReadSingle();
            surpriseFireWildlyTimeSeconds = binaryReader.ReadSingle();
            deathFireWildlyChance01 = binaryReader.ReadSingle();
            deathFireWildlyTimeSeconds = binaryReader.ReadSingle();
            customStandGunOffset = binaryReader.ReadVector3();
            customCrouchGunOffset = binaryReader.ReadVector3();
            specialFireMode = (SpecialFireModeTheTypeOfSpecialWeaponFireThatWeCanUse)binaryReader.ReadInt16();
            specialFireSituation = (SpecialFireSituationWhenWeWillDecideToUseOurSpecialWeaponFireMode)binaryReader.ReadInt16();
            specialFireChance01 = binaryReader.ReadSingle();
            specialFireDelaySeconds = binaryReader.ReadSingle();
            specialDamageModifier01 = binaryReader.ReadSingle();
            specialProjectileErrorDegrees = binaryReader.ReadSingle();
            dropWeaponLoaded = binaryReader.ReadRange();
            dropWeaponAmmo = binaryReader.ReadInt32();
            normalAccuracyBounds = binaryReader.ReadRange();
            normalAccuracyTime = binaryReader.ReadSingle();
            heroicAccuracyBounds = binaryReader.ReadRange();
            heroicAccuracyTime = binaryReader.ReadSingle();
            legendaryAccuracyBounds = binaryReader.ReadRange();
            legendaryAccuracyTime = binaryReader.ReadSingle();
            ReadCharacterFiringPatternBlockArray(binaryReader);
            weaponMeleeDamage = binaryReader.ReadTagReference();
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
        internal  virtual CharacterFiringPatternBlock[] ReadCharacterFiringPatternBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterFiringPatternBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterFiringPatternBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterFiringPatternBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCharacterFiringPatternBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)weaponsFlags);
                binaryWriter.Write(weapon);
                binaryWriter.Write(maximumFiringRangeWorldUnits);
                binaryWriter.Write(minimumFiringRange);
                binaryWriter.Write(normalCombatRangeWorldUnits);
                binaryWriter.Write(bombardmentRange);
                binaryWriter.Write(maxSpecialTargetDistanceWorldUnits);
                binaryWriter.Write(timidCombatRangeWorldUnits);
                binaryWriter.Write(aggressiveCombatRangeWorldUnits);
                binaryWriter.Write(superBallisticRange);
                binaryWriter.Write(ballisticFiringBoundsWorldUnits);
                binaryWriter.Write(ballisticFractionBounds01);
                binaryWriter.Write(firstBurstDelayTimeSeconds);
                binaryWriter.Write(surpriseDelayTimeSeconds);
                binaryWriter.Write(surpriseFireWildlyTimeSeconds);
                binaryWriter.Write(deathFireWildlyChance01);
                binaryWriter.Write(deathFireWildlyTimeSeconds);
                binaryWriter.Write(customStandGunOffset);
                binaryWriter.Write(customCrouchGunOffset);
                binaryWriter.Write((Int16)specialFireMode);
                binaryWriter.Write((Int16)specialFireSituation);
                binaryWriter.Write(specialFireChance01);
                binaryWriter.Write(specialFireDelaySeconds);
                binaryWriter.Write(specialDamageModifier01);
                binaryWriter.Write(specialProjectileErrorDegrees);
                binaryWriter.Write(dropWeaponLoaded);
                binaryWriter.Write(dropWeaponAmmo);
                binaryWriter.Write(normalAccuracyBounds);
                binaryWriter.Write(normalAccuracyTime);
                binaryWriter.Write(heroicAccuracyBounds);
                binaryWriter.Write(heroicAccuracyTime);
                binaryWriter.Write(legendaryAccuracyBounds);
                binaryWriter.Write(legendaryAccuracyTime);
                WriteCharacterFiringPatternBlockArray(binaryWriter);
                binaryWriter.Write(weaponMeleeDamage);
            }
        }
        [FlagsAttribute]
        internal enum WeaponsFlags : int
        
        {
            BurstingInhibitsMovement = 1,
            MustCrouchToShoot = 2,
            UseExtendedSafeToSaveRange = 4,
        };
        internal enum SpecialFireModeTheTypeOfSpecialWeaponFireThatWeCanUse : short
        
        {
            None = 0,
            Overcharge = 1,
            SecondaryTrigger = 2,
        };
        internal enum SpecialFireSituationWhenWeWillDecideToUseOurSpecialWeaponFireMode : short
        
        {
            Never = 0,
            EnemyVisible = 1,
            EnemyOutOfSight = 2,
            Strafing = 3,
        };
    };
}
