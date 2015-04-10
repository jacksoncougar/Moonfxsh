using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterChargeBlock : CharacterChargeBlockBase
    {
        public  CharacterChargeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class CharacterChargeBlockBase
    {
        internal ChargeFlags chargeFlags;
        internal float meleeConsiderRange;
        /// <summary>
        /// chance of initiating a melee within a 1 second period
        /// </summary>
        internal float meleeChance;
        internal float meleeAttackRange;
        internal float meleeAbortRange;
        /// <summary>
        /// Give up after given amount of time spent charging
        /// </summary>
        internal float meleeAttackTimeoutSeconds;
        /// <summary>
        /// don't attempt again before given time since last melee
        /// </summary>
        internal float meleeAttackDelayTimerSeconds;
        internal Moonfish.Model.Range meleeLeapRange;
        internal float meleeLeapChance;
        internal float idealLeapVelocity;
        internal float maxLeapVelocity;
        internal float meleeLeapBallistic;
        /// <summary>
        /// time between melee leaps
        /// </summary>
        internal float meleeDelayTimerSeconds;
        /// <summary>
        /// when I berserk, I pull out a ...
        /// </summary>
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference berserkWeapon;
        internal  CharacterChargeBlockBase(BinaryReader binaryReader)
        {
            this.chargeFlags = (ChargeFlags)binaryReader.ReadInt32();
            this.meleeConsiderRange = binaryReader.ReadSingle();
            this.meleeChance = binaryReader.ReadSingle();
            this.meleeAttackRange = binaryReader.ReadSingle();
            this.meleeAbortRange = binaryReader.ReadSingle();
            this.meleeAttackTimeoutSeconds = binaryReader.ReadSingle();
            this.meleeAttackDelayTimerSeconds = binaryReader.ReadSingle();
            this.meleeLeapRange = binaryReader.ReadRange();
            this.meleeLeapChance = binaryReader.ReadSingle();
            this.idealLeapVelocity = binaryReader.ReadSingle();
            this.maxLeapVelocity = binaryReader.ReadSingle();
            this.meleeLeapBallistic = binaryReader.ReadSingle();
            this.meleeDelayTimerSeconds = binaryReader.ReadSingle();
            this.berserkWeapon = binaryReader.ReadTagReference();
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
        internal enum ChargeFlags : int
        
        {
            OffhandMeleeAllowed = 1,
            BerserkWheneverCharge = 2,
        };
    };
}
