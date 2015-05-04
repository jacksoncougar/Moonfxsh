// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudWidgetInputsStructBlock : HudWidgetInputsStructBlockBase
    {
        public HudWidgetInputsStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class HudWidgetInputsStructBlockBase : GuerillaBlock
    {
        internal Input1 input1;
        internal Input2 input2;
        internal Input3 input3;
        internal Input4 input4;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public HudWidgetInputsStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            input1 = (Input1) binaryReader.ReadByte();
            input2 = (Input2) binaryReader.ReadByte();
            input3 = (Input3) binaryReader.ReadByte();
            input4 = (Input4) binaryReader.ReadByte();
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
                binaryWriter.Write((Byte) input1);
                binaryWriter.Write((Byte) input2);
                binaryWriter.Write((Byte) input3);
                binaryWriter.Write((Byte) input4);
                return nextAddress;
            }
        }

        internal enum Input1 : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            InvalidName = 4,
            InvalidName0 = 5,
            InvalidName1 = 6,
            InvalidName2 = 7,
            InvalidName3 = 8,
            InvalidName4 = 9,
            InvalidName5 = 10,
            InvalidName6 = 11,
            InvalidName7 = 12,
            InvalidName8 = 13,
            InvalidName9 = 14,
            InvalidName10 = 15,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            InvalidName11 = 25,
            InvalidName12 = 26,
            InvalidName13 = 27,
            InvalidName14 = 28,
            InvalidName15 = 29,
            InvalidName16 = 30,
            InvalidName17 = 31,
            PARENTShield = 32,
            PARENTBody = 33,
            InvalidName18 = 34,
            InvalidName19 = 35,
            InvalidName20 = 36,
            InvalidName21 = 37,
            InvalidName22 = 38,
            InvalidName23 = 39,
            InvalidName24 = 40,
            InvalidName25 = 41,
            InvalidName26 = 42,
            InvalidName27 = 43,
            InvalidName28 = 44,
            InvalidName29 = 45,
            InvalidName30 = 46,
            InvalidName31 = 47,
            WEAPONClipAmmo = 48,
            WEAPONHeat = 49,
            WEAPONBattery = 50,
            WEAPONTotalAmmo = 51,
            WEAPONBarrelSpin = 52,
            WEAPONOverheated = 53,
            WEAPONClipAmmoFraction = 54,
            WEAPONTimeOnOverheat = 55,
            WEAPONBatteryFraction = 56,
            WEAPONLockingFraction = 57,
            InvalidName32 = 58,
            InvalidName33 = 59,
            InvalidName34 = 60,
            InvalidName35 = 61,
            InvalidName36 = 62,
            InvalidName37 = 63,
            InvalidName38 = 64,
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
            InvalidName39 = 69,
            InvalidName40 = 70,
            InvalidName41 = 71,
            InvalidName42 = 72,
            InvalidName43 = 73,
            InvalidName44 = 74,
            InvalidName45 = 75,
            InvalidName46 = 76,
            InvalidName47 = 77,
            InvalidName48 = 78,
            InvalidName49 = 79,
            InvalidName50 = 80,
        };

        internal enum Input2 : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            InvalidName = 4,
            InvalidName0 = 5,
            InvalidName1 = 6,
            InvalidName2 = 7,
            InvalidName3 = 8,
            InvalidName4 = 9,
            InvalidName5 = 10,
            InvalidName6 = 11,
            InvalidName7 = 12,
            InvalidName8 = 13,
            InvalidName9 = 14,
            InvalidName10 = 15,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            InvalidName11 = 25,
            InvalidName12 = 26,
            InvalidName13 = 27,
            InvalidName14 = 28,
            InvalidName15 = 29,
            InvalidName16 = 30,
            InvalidName17 = 31,
            PARENTShield = 32,
            PARENTBody = 33,
            InvalidName18 = 34,
            InvalidName19 = 35,
            InvalidName20 = 36,
            InvalidName21 = 37,
            InvalidName22 = 38,
            InvalidName23 = 39,
            InvalidName24 = 40,
            InvalidName25 = 41,
            InvalidName26 = 42,
            InvalidName27 = 43,
            InvalidName28 = 44,
            InvalidName29 = 45,
            InvalidName30 = 46,
            InvalidName31 = 47,
            WEAPONClipAmmo = 48,
            WEAPONHeat = 49,
            WEAPONBattery = 50,
            WEAPONTotalAmmo = 51,
            WEAPONBarrelSpin = 52,
            WEAPONOverheated = 53,
            WEAPONClipAmmoFraction = 54,
            WEAPONTimeOnOverheat = 55,
            WEAPONBatteryFraction = 56,
            WEAPONLockingFraction = 57,
            InvalidName32 = 58,
            InvalidName33 = 59,
            InvalidName34 = 60,
            InvalidName35 = 61,
            InvalidName36 = 62,
            InvalidName37 = 63,
            InvalidName38 = 64,
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
            InvalidName39 = 69,
            InvalidName40 = 70,
            InvalidName41 = 71,
            InvalidName42 = 72,
            InvalidName43 = 73,
            InvalidName44 = 74,
            InvalidName45 = 75,
            InvalidName46 = 76,
            InvalidName47 = 77,
            InvalidName48 = 78,
            InvalidName49 = 79,
            InvalidName50 = 80,
        };

        internal enum Input3 : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            InvalidName = 4,
            InvalidName0 = 5,
            InvalidName1 = 6,
            InvalidName2 = 7,
            InvalidName3 = 8,
            InvalidName4 = 9,
            InvalidName5 = 10,
            InvalidName6 = 11,
            InvalidName7 = 12,
            InvalidName8 = 13,
            InvalidName9 = 14,
            InvalidName10 = 15,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            InvalidName11 = 25,
            InvalidName12 = 26,
            InvalidName13 = 27,
            InvalidName14 = 28,
            InvalidName15 = 29,
            InvalidName16 = 30,
            InvalidName17 = 31,
            PARENTShield = 32,
            PARENTBody = 33,
            InvalidName18 = 34,
            InvalidName19 = 35,
            InvalidName20 = 36,
            InvalidName21 = 37,
            InvalidName22 = 38,
            InvalidName23 = 39,
            InvalidName24 = 40,
            InvalidName25 = 41,
            InvalidName26 = 42,
            InvalidName27 = 43,
            InvalidName28 = 44,
            InvalidName29 = 45,
            InvalidName30 = 46,
            InvalidName31 = 47,
            WEAPONClipAmmo = 48,
            WEAPONHeat = 49,
            WEAPONBattery = 50,
            WEAPONTotalAmmo = 51,
            WEAPONBarrelSpin = 52,
            WEAPONOverheated = 53,
            WEAPONClipAmmoFraction = 54,
            WEAPONTimeOnOverheat = 55,
            WEAPONBatteryFraction = 56,
            WEAPONLockingFraction = 57,
            InvalidName32 = 58,
            InvalidName33 = 59,
            InvalidName34 = 60,
            InvalidName35 = 61,
            InvalidName36 = 62,
            InvalidName37 = 63,
            InvalidName38 = 64,
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
            InvalidName39 = 69,
            InvalidName40 = 70,
            InvalidName41 = 71,
            InvalidName42 = 72,
            InvalidName43 = 73,
            InvalidName44 = 74,
            InvalidName45 = 75,
            InvalidName46 = 76,
            InvalidName47 = 77,
            InvalidName48 = 78,
            InvalidName49 = 79,
            InvalidName50 = 80,
        };

        internal enum Input4 : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            InvalidName = 4,
            InvalidName0 = 5,
            InvalidName1 = 6,
            InvalidName2 = 7,
            InvalidName3 = 8,
            InvalidName4 = 9,
            InvalidName5 = 10,
            InvalidName6 = 11,
            InvalidName7 = 12,
            InvalidName8 = 13,
            InvalidName9 = 14,
            InvalidName10 = 15,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            InvalidName11 = 25,
            InvalidName12 = 26,
            InvalidName13 = 27,
            InvalidName14 = 28,
            InvalidName15 = 29,
            InvalidName16 = 30,
            InvalidName17 = 31,
            PARENTShield = 32,
            PARENTBody = 33,
            InvalidName18 = 34,
            InvalidName19 = 35,
            InvalidName20 = 36,
            InvalidName21 = 37,
            InvalidName22 = 38,
            InvalidName23 = 39,
            InvalidName24 = 40,
            InvalidName25 = 41,
            InvalidName26 = 42,
            InvalidName27 = 43,
            InvalidName28 = 44,
            InvalidName29 = 45,
            InvalidName30 = 46,
            InvalidName31 = 47,
            WEAPONClipAmmo = 48,
            WEAPONHeat = 49,
            WEAPONBattery = 50,
            WEAPONTotalAmmo = 51,
            WEAPONBarrelSpin = 52,
            WEAPONOverheated = 53,
            WEAPONClipAmmoFraction = 54,
            WEAPONTimeOnOverheat = 55,
            WEAPONBatteryFraction = 56,
            WEAPONLockingFraction = 57,
            InvalidName32 = 58,
            InvalidName33 = 59,
            InvalidName34 = 60,
            InvalidName35 = 61,
            InvalidName36 = 62,
            InvalidName37 = 63,
            InvalidName38 = 64,
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
            InvalidName39 = 69,
            InvalidName40 = 70,
            InvalidName41 = 71,
            InvalidName42 = 72,
            InvalidName43 = 73,
            InvalidName44 = 74,
            InvalidName45 = 75,
            InvalidName46 = 76,
            InvalidName47 = 77,
            InvalidName48 = 78,
            InvalidName49 = 79,
            InvalidName50 = 80,
        };
    };
}