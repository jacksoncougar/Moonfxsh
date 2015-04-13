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
        public  CharacterWeaponsBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterWeaponsBlockBase(BinaryReader binaryReader)
        {
            this.weaponsFlags = (WeaponsFlags)binaryReader.ReadInt32();
            this.weapon = binaryReader.ReadTagReference();
            this.maximumFiringRangeWorldUnits = binaryReader.ReadSingle();
            this.minimumFiringRange = binaryReader.ReadSingle();
            this.normalCombatRangeWorldUnits = binaryReader.ReadRange();
            this.bombardmentRange = binaryReader.ReadSingle();
            this.maxSpecialTargetDistanceWorldUnits = binaryReader.ReadSingle();
            this.timidCombatRangeWorldUnits = binaryReader.ReadRange();
            this.aggressiveCombatRangeWorldUnits = binaryReader.ReadRange();
            this.superBallisticRange = binaryReader.ReadSingle();
            this.ballisticFiringBoundsWorldUnits = binaryReader.ReadRange();
            this.ballisticFractionBounds01 = binaryReader.ReadRange();
            this.firstBurstDelayTimeSeconds = binaryReader.ReadRange();
            this.surpriseDelayTimeSeconds = binaryReader.ReadSingle();
            this.surpriseFireWildlyTimeSeconds = binaryReader.ReadSingle();
            this.deathFireWildlyChance01 = binaryReader.ReadSingle();
            this.deathFireWildlyTimeSeconds = binaryReader.ReadSingle();
            this.customStandGunOffset = binaryReader.ReadVector3();
            this.customCrouchGunOffset = binaryReader.ReadVector3();
            this.specialFireMode = (SpecialFireModeTheTypeOfSpecialWeaponFireThatWeCanUse)binaryReader.ReadInt16();
            this.specialFireSituation = (SpecialFireSituationWhenWeWillDecideToUseOurSpecialWeaponFireMode)binaryReader.ReadInt16();
            this.specialFireChance01 = binaryReader.ReadSingle();
            this.specialFireDelaySeconds = binaryReader.ReadSingle();
            this.specialDamageModifier01 = binaryReader.ReadSingle();
            this.specialProjectileErrorDegrees = binaryReader.ReadSingle();
            this.dropWeaponLoaded = binaryReader.ReadRange();
            this.dropWeaponAmmo = binaryReader.ReadInt32();
            this.normalAccuracyBounds = binaryReader.ReadRange();
            this.normalAccuracyTime = binaryReader.ReadSingle();
            this.heroicAccuracyBounds = binaryReader.ReadRange();
            this.heroicAccuracyTime = binaryReader.ReadSingle();
            this.legendaryAccuracyBounds = binaryReader.ReadRange();
            this.legendaryAccuracyTime = binaryReader.ReadSingle();
            this.firingPatterns = ReadCharacterFiringPatternBlockArray(binaryReader);
            this.weaponMeleeDamage = binaryReader.ReadTagReference();
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
        internal  virtual CharacterFiringPatternBlock[] ReadCharacterFiringPatternBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CharacterFiringPatternBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CharacterFiringPatternBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CharacterFiringPatternBlock(binaryReader);
                }
            }
            return array;
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
