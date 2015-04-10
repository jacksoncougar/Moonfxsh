// ReSharper disable All
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
        public  CharacterGrenadesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterGrenadesBlockBase(System.IO.BinaryReader binaryReader)
        {
            grenadesFlags = (GrenadesFlags)binaryReader.ReadInt32();
            grenadeType = (GrenadeTypeTypeOfGrenadesThatWeThrow)binaryReader.ReadInt16();
            trajectoryType = (TrajectoryTypeHowWeThrowOurGrenades)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            minimumEnemyCount = binaryReader.ReadInt16();
            enemyRadiusWorldUnits = binaryReader.ReadSingle();
            grenadeIdealVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            grenadeVelocityWorldUnitsPerSecond = binaryReader.ReadSingle();
            grenadeRangesWorldUnits = binaryReader.ReadRange();
            collateralDamageRadiusWorldUnits = binaryReader.ReadSingle();
            grenadeChance01 = binaryReader.ReadSingle();
            grenadeThrowDelaySeconds = binaryReader.ReadSingle();
            grenadeUncoverChance01 = binaryReader.ReadSingle();
            antiVehicleGrenadeChance01 = binaryReader.ReadSingle();
            grenadeCount = binaryReader.ReadInt32();
            dontDropGrenadesChance01 = binaryReader.ReadSingle();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)grenadesFlags);
                binaryWriter.Write((Int16)grenadeType);
                binaryWriter.Write((Int16)trajectoryType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(minimumEnemyCount);
                binaryWriter.Write(enemyRadiusWorldUnits);
                binaryWriter.Write(grenadeIdealVelocityWorldUnitsPerSecond);
                binaryWriter.Write(grenadeVelocityWorldUnitsPerSecond);
                binaryWriter.Write(grenadeRangesWorldUnits);
                binaryWriter.Write(collateralDamageRadiusWorldUnits);
                binaryWriter.Write(grenadeChance01);
                binaryWriter.Write(grenadeThrowDelaySeconds);
                binaryWriter.Write(grenadeUncoverChance01);
                binaryWriter.Write(antiVehicleGrenadeChance01);
                binaryWriter.Write(grenadeCount);
                binaryWriter.Write(dontDropGrenadesChance01);
            }
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
