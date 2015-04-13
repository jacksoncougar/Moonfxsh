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
    [LayoutAttribute(Size = 112)]
    public class CharacterVitalityBlockBase
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
            this.vitalityFlags = (VitalityFlags)binaryReader.ReadInt32();
            this.normalBodyVitality = binaryReader.ReadSingle();
            this.normalShieldVitality = binaryReader.ReadSingle();
            this.legendaryBodyVitality = binaryReader.ReadSingle();
            this.legendaryShieldVitality = binaryReader.ReadSingle();
            this.bodyRechargeFraction = binaryReader.ReadSingle();
            this.softPingThresholdWithShields = binaryReader.ReadSingle();
            this.softPingThresholdNoShields = binaryReader.ReadSingle();
            this.softPingMinInterruptTime = binaryReader.ReadSingle();
            this.hardPingThresholdWithShields = binaryReader.ReadSingle();
            this.hardPingThresholdNoShields = binaryReader.ReadSingle();
            this.hardPingMinInterruptTime = binaryReader.ReadSingle();
            this.currentDamageDecayDelay = binaryReader.ReadSingle();
            this.currentDamageDecayTime = binaryReader.ReadSingle();
            this.recentDamageDecayDelay = binaryReader.ReadSingle();
            this.recentDamageDecayTime = binaryReader.ReadSingle();
            this.bodyRechargeDelayTime = binaryReader.ReadSingle();
            this.bodyRechargeTime = binaryReader.ReadSingle();
            this.shieldRechargeDelayTime = binaryReader.ReadSingle();
            this.shieldRechargeTime = binaryReader.ReadSingle();
            this.stunThreshold = binaryReader.ReadSingle();
            this.stunTimeBoundsSeconds = binaryReader.ReadRange();
            this.extendedShieldDamageThreshold = binaryReader.ReadSingle();
            this.extendedBodyDamageThreshold = binaryReader.ReadSingle();
            this.suicideRadius = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(8);
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
        [FlagsAttribute]
        internal enum VitalityFlags : int
        
        {
            Unused = 1,
        };
    };
}
