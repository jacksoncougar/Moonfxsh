using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterGrenadesBlock : CharacterGrenadesBlockBase
    {
        public  CharacterGrenadesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class CharacterGrenadesBlockBase
    {
        internal GrenadesFlags grenadesFlags;
        /// <summary>
        /// type of grenades that we throw^
        /// </summary>
        internal GrenadeTypeTypeOfGrenadesThatWeThrow grenadeType;
        /// <summary>
        /// how we throw our grenades
        /// </summary>
        internal TrajectoryTypeHowWeThrowOurGrenades trajectoryType;
        internal byte[] invalidName_;
        /// <summary>
        /// how many enemies must be within the radius of the grenade before we will consider throwing there
        /// </summary>
        internal short minimumEnemyCount;
        /// <summary>
        /// we consider enemies within this radius when determining where to throw
        /// </summary>
        internal float enemyRadiusWorldUnits;
        /// <summary>
        /// how fast we LIKE to throw our grenades
        /// </summary>
        internal float grenadeIdealVelocityWorldUnitsPerSecond;
        /// <summary>
        /// the fastest we can possibly throw our grenades
        /// </summary>
        internal float grenadeVelocityWorldUnitsPerSecond;
        /// <summary>
        /// ranges within which we will consider throwing a grenade
        /// </summary>
        internal Moonfish.Model.Range grenadeRangesWorldUnits;
        /// <summary>
        /// we won't throw if there are friendlies around our target within this range
        /// </summary>
        internal float collateralDamageRadiusWorldUnits;
        /// <summary>
        /// how likely we are to throw a grenade in one second
        /// </summary>
        internal float grenadeChance01;
        /// <summary>
        /// How long we have to wait after throwing a grenade before we can throw another one
        /// </summary>
        internal float grenadeThrowDelaySeconds;
        /// <summary>
        /// how likely we are to throw a grenade to flush out a target in one second
        /// </summary>
        internal float grenadeUncoverChance01;
        /// <summary>
        /// how likely we are to throw a grenade against a vehicle
        /// </summary>
        internal float antiVehicleGrenadeChance01;
        /// <summary>
        /// number of grenades that we start with
        /// </summary>
        internal int grenadeCount;
        /// <summary>
        /// how likely we are not to drop any grenades when we die, even if we still have some
        /// </summary>
        internal float dontDropGrenadesChance01;
        internal  CharacterGrenadesBlockBase(BinaryReader binaryReader)
        {
            this.grenadesFlags = (GrenadesFlags)binaryReader.ReadInt32();
            this.grenadeType = (GrenadeTypeTypeOfGrenadesThatWeThrow)binaryReader.ReadInt16();
            this.trajectoryType = (TrajectoryTypeHowWeThrowOurGrenades)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.minimumEnemyCount = binaryReader.ReadInt16();
            this.enemyRadiusWorldUnits = binaryReader.ReadSingle();
            this.grenadeIdealVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.grenadeVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.grenadeRangesWorldUnits = binaryReader.ReadRange();
            this.collateralDamageRadiusWorldUnits = binaryReader.ReadSingle();
            this.grenadeChance01 = binaryReader.ReadSingle();
            this.grenadeThrowDelaySeconds = binaryReader.ReadSingle();
            this.grenadeUncoverChance01 = binaryReader.ReadSingle();
            this.antiVehicleGrenadeChance01 = binaryReader.ReadSingle();
            this.grenadeCount = binaryReader.ReadInt32();
            this.dontDropGrenadesChance01 = binaryReader.ReadSingle();
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
        internal enum GrenadesFlags : int
        
        {
            Flag1 = 1,
        };
        internal enum GrenadeTypeTypeOfGrenadesThatWeThrow : short
        
        {
            HumanFragmentation = 0,
            CovenantPlasma = 1,
        };
        internal enum TrajectoryTypeHowWeThrowOurGrenades : short
        
        {
            Toss = 0,
            Lob = 1,
            Bounce = 2,
        };
    };
}
