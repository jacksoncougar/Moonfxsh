// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterVitalityBlock : CharacterVitalityBlockBase
    {
        public  CharacterVitalityBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 112, Alignment = 4)]
    public class CharacterVitalityBlockBase  : IGuerilla
    {
        internal VitalityFlags vitalityFlags;
        /// <summary>
        /// maximum body vitality of our unit
        /// </summary>
        internal float normalBodyVitality;
        /// <summary>
        /// maximum shield vitality of our unit
        /// </summary>
        internal float normalShieldVitality;
        /// <summary>
        /// maximum body vitality of our unit (on legendary)
        /// </summary>
        internal float legendaryBodyVitality;
        /// <summary>
        /// maximum shield vitality of our unit (on legendary)
        /// </summary>
        internal float legendaryShieldVitality;
        /// <summary>
        /// fraction of body health that can be regained after damage
        /// </summary>
        internal float bodyRechargeFraction;
        /// <summary>
        /// damage necessary to trigger a soft ping when shields are up
        /// </summary>
        internal float softPingThresholdWithShields;
        /// <summary>
        /// damage necessary to trigger a soft ping when shields are down
        /// </summary>
        internal float softPingThresholdNoShields;
        /// <summary>
        /// minimum time before a soft ping can be interrupted
        /// </summary>
        internal float softPingMinInterruptTime;
        /// <summary>
        /// damage necessary to trigger a hard ping when shields are up
        /// </summary>
        internal float hardPingThresholdWithShields;
        /// <summary>
        /// damage necessary to trigger a hard ping when shields are down
        /// </summary>
        internal float hardPingThresholdNoShields;
        /// <summary>
        /// minimum time before a hard ping can be interrupted
        /// </summary>
        internal float hardPingMinInterruptTime;
        /// <summary>
        /// current damage begins to fall after a time delay has passed since last the damage
        /// </summary>
        internal float currentDamageDecayDelay;
        /// <summary>
        /// amount of time it would take for 100% current damage to decay to 0
        /// </summary>
        internal float currentDamageDecayTime;
        /// <summary>
        /// recent damage begins to fall after a time delay has passed since last the damage
        /// </summary>
        internal float recentDamageDecayDelay;
        /// <summary>
        /// amount of time it would take for 100% recent damage to decay to 0
        /// </summary>
        internal float recentDamageDecayTime;
        /// <summary>
        /// amount of time delay before a shield begins to recharge
        /// </summary>
        internal float bodyRechargeDelayTime;
        /// <summary>
        /// amount of time for shields to recharge completely
        /// </summary>
        internal float bodyRechargeTime;
        /// <summary>
        /// amount of time delay before a shield begins to recharge
        /// </summary>
        internal float shieldRechargeDelayTime;
        /// <summary>
        /// amount of time for shields to recharge completely
        /// </summary>
        internal float shieldRechargeTime;
        /// <summary>
        /// stun level that triggers the stunned state (currently, the 'stunned' behavior)
        /// </summary>
        internal float stunThreshold;
        internal Moonfish.Model.Range stunTimeBoundsSeconds;
        /// <summary>
        /// Amount of shield damage sustained before it is considered 'extended'
        /// </summary>
        internal float extendedShieldDamageThreshold;
        /// <summary>
        /// Amount of body damage sustained before it is considered 'extended'
        /// </summary>
        internal float extendedBodyDamageThreshold;
        /// <summary>
        /// when I die and explode, I damage stuff within this distance of me.
        /// </summary>
        internal float suicideRadius;
        internal byte[] invalidName_;
        internal  CharacterVitalityBlockBase(BinaryReader binaryReader)
        {
            vitalityFlags = (VitalityFlags)binaryReader.ReadInt32();
            normalBodyVitality = binaryReader.ReadSingle();
            normalShieldVitality = binaryReader.ReadSingle();
            legendaryBodyVitality = binaryReader.ReadSingle();
            legendaryShieldVitality = binaryReader.ReadSingle();
            bodyRechargeFraction = binaryReader.ReadSingle();
            softPingThresholdWithShields = binaryReader.ReadSingle();
            softPingThresholdNoShields = binaryReader.ReadSingle();
            softPingMinInterruptTime = binaryReader.ReadSingle();
            hardPingThresholdWithShields = binaryReader.ReadSingle();
            hardPingThresholdNoShields = binaryReader.ReadSingle();
            hardPingMinInterruptTime = binaryReader.ReadSingle();
            currentDamageDecayDelay = binaryReader.ReadSingle();
            currentDamageDecayTime = binaryReader.ReadSingle();
            recentDamageDecayDelay = binaryReader.ReadSingle();
            recentDamageDecayTime = binaryReader.ReadSingle();
            bodyRechargeDelayTime = binaryReader.ReadSingle();
            bodyRechargeTime = binaryReader.ReadSingle();
            shieldRechargeDelayTime = binaryReader.ReadSingle();
            shieldRechargeTime = binaryReader.ReadSingle();
            stunThreshold = binaryReader.ReadSingle();
            stunTimeBoundsSeconds = binaryReader.ReadRange();
            extendedShieldDamageThreshold = binaryReader.ReadSingle();
            extendedBodyDamageThreshold = binaryReader.ReadSingle();
            suicideRadius = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(8);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)vitalityFlags);
                binaryWriter.Write(normalBodyVitality);
                binaryWriter.Write(normalShieldVitality);
                binaryWriter.Write(legendaryBodyVitality);
                binaryWriter.Write(legendaryShieldVitality);
                binaryWriter.Write(bodyRechargeFraction);
                binaryWriter.Write(softPingThresholdWithShields);
                binaryWriter.Write(softPingThresholdNoShields);
                binaryWriter.Write(softPingMinInterruptTime);
                binaryWriter.Write(hardPingThresholdWithShields);
                binaryWriter.Write(hardPingThresholdNoShields);
                binaryWriter.Write(hardPingMinInterruptTime);
                binaryWriter.Write(currentDamageDecayDelay);
                binaryWriter.Write(currentDamageDecayTime);
                binaryWriter.Write(recentDamageDecayDelay);
                binaryWriter.Write(recentDamageDecayTime);
                binaryWriter.Write(bodyRechargeDelayTime);
                binaryWriter.Write(bodyRechargeTime);
                binaryWriter.Write(shieldRechargeDelayTime);
                binaryWriter.Write(shieldRechargeTime);
                binaryWriter.Write(stunThreshold);
                binaryWriter.Write(stunTimeBoundsSeconds);
                binaryWriter.Write(extendedShieldDamageThreshold);
                binaryWriter.Write(extendedBodyDamageThreshold);
                binaryWriter.Write(suicideRadius);
                binaryWriter.Write(invalidName_, 0, 8);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum VitalityFlags : int
        {
            Unused = 1,
        };
    };
}
