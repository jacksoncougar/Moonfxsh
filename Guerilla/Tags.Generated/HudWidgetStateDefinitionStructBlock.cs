// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudWidgetStateDefinitionStructBlock : HudWidgetStateDefinitionStructBlockBase
    {
        public HudWidgetStateDefinitionStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class HudWidgetStateDefinitionStructBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public HudWidgetStateDefinitionStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            yUnitFlags = (YUnitFlags) binaryReader.ReadInt16();
            yExtraFlags = (YExtraFlags) binaryReader.ReadInt16();
            yWeaponFlags = (YWeaponFlags) binaryReader.ReadInt16();
            yGameEngineStateFlags = (YGameEngineStateFlags) binaryReader.ReadInt16();
            nUnitFlags = (NUnitFlags) binaryReader.ReadInt16();
            nExtraFlags = (NExtraFlags) binaryReader.ReadInt16();
            nWeaponFlags = (NWeaponFlags) binaryReader.ReadInt16();
            nGameEngineStateFlags = (NGameEngineStateFlags) binaryReader.ReadInt16();
            ageCutoff = binaryReader.ReadByte();
            clipCutoff = binaryReader.ReadByte();
            totalCutoff = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) yUnitFlags);
                binaryWriter.Write((Int16) yExtraFlags);
                binaryWriter.Write((Int16) yWeaponFlags);
                binaryWriter.Write((Int16) yGameEngineStateFlags);
                binaryWriter.Write((Int16) nUnitFlags);
                binaryWriter.Write((Int16) nExtraFlags);
                binaryWriter.Write((Int16) nWeaponFlags);
                binaryWriter.Write((Int16) nGameEngineStateFlags);
                binaryWriter.Write(ageCutoff);
                binaryWriter.Write(clipCutoff);
                binaryWriter.Write(totalCutoff);
                binaryWriter.Write(invalidName_, 0, 1);
                return nextAddress;
            }
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