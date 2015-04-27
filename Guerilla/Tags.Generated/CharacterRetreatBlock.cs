// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterRetreatBlock : CharacterRetreatBlockBase
    {
        public  CharacterRetreatBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CharacterRetreatBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 76, Alignment = 4)]
    public class CharacterRetreatBlockBase : GuerillaBlock
    {
        internal RetreatFlags retreatFlags;
        /// <summary>
        /// When shield vitality drops below given amount, retreat is triggered by low_shield_retreat_impulse
        /// </summary>
        internal float shieldThreshold;
        /// <summary>
        /// When confronting an enemy of over the given scariness, retreat is triggered by scary_target_retreat_impulse
        /// </summary>
        internal float scaryTargetThreshold;
        /// <summary>
        /// When perceived danger rises above the given threshold, retreat is triggered by danger_retreat_impulse
        /// </summary>
        internal float dangerThreshold;
        /// <summary>
        /// When enemy closer than given threshold, retreat is triggered by proximity_retreat_impulse
        /// </summary>
        internal float proximityThreshold;
        /// <summary>
        /// actor cowers for at least the given amount of time
        /// </summary>
        internal Moonfish.Model.Range minMaxForcedCowerTimeBounds;
        /// <summary>
        /// actor times out of cower after the given amount of time
        /// </summary>
        internal Moonfish.Model.Range minMaxCowerTimeoutBounds;
        /// <summary>
        /// If target reaches is within the given proximity, an ambush is triggered by the proximity ambush impulse
        /// </summary>
        internal float proximityAmbushThreshold;
        /// <summary>
        /// If target is less than threshold (0-1) aware of me, an ambush is triggered by the vulnerable enemy ambush impulse
        /// </summary>
        internal float awarenessAmbushThreshold;
        /// <summary>
        /// If leader-dead-retreat-impulse is active, gives the chance that we will flee when our leader dies within 4 world units of us
        /// </summary>
        internal float leaderDeadRetreatChance;
        /// <summary>
        /// If peer-dead-retreat-impulse is active, gives the chance that we will flee when one of our peers (friend of the same race) dies within 4 world units of us
        /// </summary>
        internal float peerDeadRetreatChance;
        /// <summary>
        /// If peer-dead-retreat-impulse is active, gives the chance that we will flee when a second peer (friend of the same race) dies within 4 world units of us
        /// </summary>
        internal float secondPeerDeadRetreatChance;
        /// <summary>
        /// The angle from the intended destination direction that a zig-zag will cause
        /// </summary>
        internal float zigZagAngleDegrees;
        /// <summary>
        /// How long it takes to zig left and then zag right.
        /// </summary>
        internal float zigZagPeriodSeconds;
        /// <summary>
        /// The likelihood of throwing down a grenade to cover our retreat
        /// </summary>
        internal float retreatGrenadeChance;
        /// <summary>
        /// If I want to flee and I don't have flee animations with my current weapon, throw it away and try a ...
        /// </summary>
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference backupWeapon;
        
        public override int SerializedSize{get { return 76; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CharacterRetreatBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            retreatFlags = (RetreatFlags)binaryReader.ReadInt32();
            shieldThreshold = binaryReader.ReadSingle();
            scaryTargetThreshold = binaryReader.ReadSingle();
            dangerThreshold = binaryReader.ReadSingle();
            proximityThreshold = binaryReader.ReadSingle();
            minMaxForcedCowerTimeBounds = binaryReader.ReadRange();
            minMaxCowerTimeoutBounds = binaryReader.ReadRange();
            proximityAmbushThreshold = binaryReader.ReadSingle();
            awarenessAmbushThreshold = binaryReader.ReadSingle();
            leaderDeadRetreatChance = binaryReader.ReadSingle();
            peerDeadRetreatChance = binaryReader.ReadSingle();
            secondPeerDeadRetreatChance = binaryReader.ReadSingle();
            zigZagAngleDegrees = binaryReader.ReadSingle();
            zigZagPeriodSeconds = binaryReader.ReadSingle();
            retreatGrenadeChance = binaryReader.ReadSingle();
            backupWeapon = binaryReader.ReadTagReference();
        }
        public  CharacterRetreatBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            retreatFlags = (RetreatFlags)binaryReader.ReadInt32();
            shieldThreshold = binaryReader.ReadSingle();
            scaryTargetThreshold = binaryReader.ReadSingle();
            dangerThreshold = binaryReader.ReadSingle();
            proximityThreshold = binaryReader.ReadSingle();
            minMaxForcedCowerTimeBounds = binaryReader.ReadRange();
            minMaxCowerTimeoutBounds = binaryReader.ReadRange();
            proximityAmbushThreshold = binaryReader.ReadSingle();
            awarenessAmbushThreshold = binaryReader.ReadSingle();
            leaderDeadRetreatChance = binaryReader.ReadSingle();
            peerDeadRetreatChance = binaryReader.ReadSingle();
            secondPeerDeadRetreatChance = binaryReader.ReadSingle();
            zigZagAngleDegrees = binaryReader.ReadSingle();
            zigZagPeriodSeconds = binaryReader.ReadSingle();
            retreatGrenadeChance = binaryReader.ReadSingle();
            backupWeapon = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)retreatFlags);
                binaryWriter.Write(shieldThreshold);
                binaryWriter.Write(scaryTargetThreshold);
                binaryWriter.Write(dangerThreshold);
                binaryWriter.Write(proximityThreshold);
                binaryWriter.Write(minMaxForcedCowerTimeBounds);
                binaryWriter.Write(minMaxCowerTimeoutBounds);
                binaryWriter.Write(proximityAmbushThreshold);
                binaryWriter.Write(awarenessAmbushThreshold);
                binaryWriter.Write(leaderDeadRetreatChance);
                binaryWriter.Write(peerDeadRetreatChance);
                binaryWriter.Write(secondPeerDeadRetreatChance);
                binaryWriter.Write(zigZagAngleDegrees);
                binaryWriter.Write(zigZagPeriodSeconds);
                binaryWriter.Write(retreatGrenadeChance);
                binaryWriter.Write(backupWeapon);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum RetreatFlags : int
        {
            ZigZagWhenFleeing = 1,
            Unused1 = 2,
        };
    };
}
