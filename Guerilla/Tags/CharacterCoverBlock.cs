// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterCoverBlock : CharacterCoverBlockBase
    {
        public  CharacterCoverBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class CharacterCoverBlockBase  : IGuerilla
    {
        internal CoverFlags coverFlags;
        /// <summary>
        /// how long we stay behind cover after seeking cover
        /// </summary>
        internal Moonfish.Model.Range hideBehindCoverTimeSeconds;
        /// <summary>
        /// When vitality drops below this level, possibly trigger a cover
        /// </summary>
        internal float coverVitalityThreshold;
        /// <summary>
        /// trigger cover when shield drops below this fraction (low shield cover impulse must be enabled)
        /// </summary>
        internal float coverShieldFraction;
        /// <summary>
        /// amount of time I will wait before trying again after covering
        /// </summary>
        internal float coverCheckDelay;
        /// <summary>
        /// emergeFromCoverWhenShieldFractionReachesThreshold
        /// </summary>
        internal float emergeFromCoverWhenShieldFractionReachesThreshold;
        /// <summary>
        /// Danger must be this high to cover. At a danger level of 'danger threshold', the chance of seeking cover is the cover chance lower bound (below)
        /// </summary>
        internal float coverDangerThreshold;
        /// <summary>
        /// At or above danger level of upper threshold, the chance of seeking cover is the cover chance upper bound (below)
        /// </summary>
        internal float dangerUpperThreshold;
        /// <summary>
        /// Bounds on the chances of seeking cover.
        /// </summary>
        internal Moonfish.Model.Range coverChance;
        /// <summary>
        /// When the proximity_self_preservation impulse is enabled, triggers self-preservation when target within this distance
        /// </summary>
        internal float proximitySelfPreserveWus;
        /// <summary>
        /// Disallow covering from visible target under the given distance away
        /// </summary>
        internal float disallowCoverDistanceWorldUnits;
        /// <summary>
        /// When self preserving from a target less than given distance, causes melee attack (assuming proximity_melee_impulse is enabled)
        /// </summary>
        internal float proximityMeleeDistance;
        /// <summary>
        /// When danger from an unreachable enemy surpasses threshold, actor cover (assuming unreachable_enemy_cover impulse is enabled)
        /// </summary>
        internal float unreachableEnemyDangerThreshold;
        /// <summary>
        /// When target is aware of me and surpasses the given scariness, self-preserve (scary_target_cover_impulse)
        /// </summary>
        internal float scaryTargetThreshold;
        internal  CharacterCoverBlockBase(BinaryReader binaryReader)
        {
            coverFlags = (CoverFlags)binaryReader.ReadInt32();
            hideBehindCoverTimeSeconds = binaryReader.ReadRange();
            coverVitalityThreshold = binaryReader.ReadSingle();
            coverShieldFraction = binaryReader.ReadSingle();
            coverCheckDelay = binaryReader.ReadSingle();
            emergeFromCoverWhenShieldFractionReachesThreshold = binaryReader.ReadSingle();
            coverDangerThreshold = binaryReader.ReadSingle();
            dangerUpperThreshold = binaryReader.ReadSingle();
            coverChance = binaryReader.ReadRange();
            proximitySelfPreserveWus = binaryReader.ReadSingle();
            disallowCoverDistanceWorldUnits = binaryReader.ReadSingle();
            proximityMeleeDistance = binaryReader.ReadSingle();
            unreachableEnemyDangerThreshold = binaryReader.ReadSingle();
            scaryTargetThreshold = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)coverFlags);
                binaryWriter.Write(hideBehindCoverTimeSeconds);
                binaryWriter.Write(coverVitalityThreshold);
                binaryWriter.Write(coverShieldFraction);
                binaryWriter.Write(coverCheckDelay);
                binaryWriter.Write(emergeFromCoverWhenShieldFractionReachesThreshold);
                binaryWriter.Write(coverDangerThreshold);
                binaryWriter.Write(dangerUpperThreshold);
                binaryWriter.Write(coverChance);
                binaryWriter.Write(proximitySelfPreserveWus);
                binaryWriter.Write(disallowCoverDistanceWorldUnits);
                binaryWriter.Write(proximityMeleeDistance);
                binaryWriter.Write(unreachableEnemyDangerThreshold);
                binaryWriter.Write(scaryTargetThreshold);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum CoverFlags : int
        {
            Flag1 = 1,
        };
    };
}
