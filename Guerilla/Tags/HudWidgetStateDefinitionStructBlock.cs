using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudWidgetStateDefinitionStructBlock : HudWidgetStateDefinitionStructBlockBase
    {
        public  HudWidgetStateDefinitionStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class HudWidgetStateDefinitionStructBlockBase
    {
        internal YUnitFlags yUnitFlags;
        internal YExtraFlags yExtraFlags;
        internal YWeaponFlags yWeaponFlags;
        internal YGameEngineStateFlags yGameEngineStateFlags;
        internal NUnitFlags nUnitFlags;
        internal NExtraFlags nExtraFlags;
        internal NWeaponFlags nWeaponFlags;
        internal NGameEngineStateFlags nGameEngineStateFlags;
        internal byte ageCutoff;
        internal byte clipCutoff;
        internal byte totalCutoff;
        internal byte[] invalidName_;
        internal  HudWidgetStateDefinitionStructBlockBase(BinaryReader binaryReader)
        {
            this.yUnitFlags = (YUnitFlags)binaryReader.ReadInt16();
            this.yExtraFlags = (YExtraFlags)binaryReader.ReadInt16();
            this.yWeaponFlags = (YWeaponFlags)binaryReader.ReadInt16();
            this.yGameEngineStateFlags = (YGameEngineStateFlags)binaryReader.ReadInt16();
            this.nUnitFlags = (NUnitFlags)binaryReader.ReadInt16();
            this.nExtraFlags = (NExtraFlags)binaryReader.ReadInt16();
            this.nWeaponFlags = (NWeaponFlags)binaryReader.ReadInt16();
            this.nGameEngineStateFlags = (NGameEngineStateFlags)binaryReader.ReadInt16();
            this.ageCutoff = binaryReader.ReadByte();
            this.clipCutoff = binaryReader.ReadByte();
            this.totalCutoff = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
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
        internal enum YUnitFlags : short
        
        {
            Default = 1,
            GrenadeTypeIsNONE = 2,
            GrenadeTypeIsFrag = 4,
            GrenadeTypeIsPlasma = 8,
            UnitIsSingleWielding = 16,
            UnitIsDualWielding = 32,
            UnitIsUnzoomed = 64,
            UnitIsZoomedLevel1 = 128,
            UnitIsZoomedLevel2 = 256,
            GrenadesDisabled = 512,
            BinocularsEnabled = 1024,
            MotionSensorEnabled = 2048,
            ShieldEnabled = 4096,
            Dervish = 8192,
        };
        [FlagsAttribute]
        internal enum YExtraFlags : short
        
        {
            AutoaimFriendly = 1,
            AutoaimPlasma = 2,
            AutoaimHeadshot = 4,
            AutoaimVulnerable = 8,
            AutoaimInvincible = 16,
        };
        [FlagsAttribute]
        internal enum YWeaponFlags : short
        
        {
            PrimaryWeapon = 1,
            SecondaryWeapon = 2,
            BackpackWeapon = 4,
            AgeBelowCutoff = 8,
            ClipBelowCutoff = 16,
            TotalBelowCutoff = 32,
            Overheated = 64,
            OutOfAmmo = 128,
            LockTargetAvailable = 256,
            Locking = 512,
            Locked = 1024,
        };
        [FlagsAttribute]
        internal enum YGameEngineStateFlags : short
        
        {
            CampaignSolo = 1,
            CampaignCoop = 2,
            FreeForAll = 4,
            TeamGame = 8,
            UserLeading = 16,
            UserNotLeading = 32,
            TimedGame = 64,
            UntimedGame = 128,
            OtherScoreValid = 256,
            OtherScoreInvalid = 512,
            PlayerIsArmingBomb = 1024,
            PlayerTalking = 2048,
        };
        [FlagsAttribute]
        internal enum NUnitFlags : short
        
        {
            Default = 1,
            GrenadeTypeIsNONE = 2,
            GrenadeTypeIsFrag = 4,
            GrenadeTypeIsPlasma = 8,
            UnitIsSingleWielding = 16,
            UnitIsDualWielding = 32,
            UnitIsUnzoomed = 64,
            UnitIsZoomedLevel1 = 128,
            UnitIsZoomedLevel2 = 256,
            GrenadesDisabled = 512,
            BinocularsEnabled = 1024,
            MotionSensorEnabled = 2048,
            ShieldEnabled = 4096,
            Dervish = 8192,
        };
        [FlagsAttribute]
        internal enum NExtraFlags : short
        
        {
            AutoaimFriendly = 1,
            AutoaimPlasma = 2,
            AutoaimHeadshot = 4,
            AutoaimVulnerable = 8,
            AutoaimInvincible = 16,
        };
        [FlagsAttribute]
        internal enum NWeaponFlags : short
        
        {
            PrimaryWeapon = 1,
            SecondaryWeapon = 2,
            BackpackWeapon = 4,
            AgeBelowCutoff = 8,
            ClipBelowCutoff = 16,
            TotalBelowCutoff = 32,
            Overheated = 64,
            OutOfAmmo = 128,
            LockTargetAvailable = 256,
            Locking = 512,
            Locked = 1024,
        };
        [FlagsAttribute]
        internal enum NGameEngineStateFlags : short
        
        {
            CampaignSolo = 1,
            CampaignCoop = 2,
            FreeForAll = 4,
            TeamGame = 8,
            UserLeading = 16,
            UserNotLeading = 32,
            TimedGame = 64,
            UntimedGame = 128,
            OtherScoreValid = 256,
            OtherScoreInvalid = 512,
            PlayerIsArmingBomb = 1024,
            PlayerTalking = 2048,
        };
    };
}
