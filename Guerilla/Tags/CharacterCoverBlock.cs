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
    [LayoutAttribute(Size = 64)]
    public class CharacterCoverBlockBase
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
            this.coverFlags = (CoverFlags)binaryReader.ReadInt32();
            this.hideBehindCoverTimeSeconds = binaryReader.ReadRange();
            this.coverVitalityThreshold = binaryReader.ReadSingle();
            this.coverShieldFraction = binaryReader.ReadSingle();
            this.coverCheckDelay = binaryReader.ReadSingle();
            this.emergeFromCoverWhenShieldFractionReachesThreshold = binaryReader.ReadSingle();
            this.coverDangerThreshold = binaryReader.ReadSingle();
            this.dangerUpperThreshold = binaryReader.ReadSingle();
            this.coverChance = binaryReader.ReadRange();
            this.proximitySelfPreserveWus = binaryReader.ReadSingle();
            this.disallowCoverDistanceWorldUnits = binaryReader.ReadSingle();
            this.proximityMeleeDistance = binaryReader.ReadSingle();
            this.unreachableEnemyDangerThreshold = binaryReader.ReadSingle();
            this.scaryTargetThreshold = binaryReader.ReadSingle();
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
        [FlagsAttribute]
        internal enum CoverFlags : int
        
        {
            Flag1 = 1,
        };
    };
}
