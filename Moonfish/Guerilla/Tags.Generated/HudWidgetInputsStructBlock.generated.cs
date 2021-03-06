//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class HudWidgetInputsStructBlock : GuerillaBlock, IWriteQueueable
    {
        public Input1Enum Input1;
        public Input2Enum Input2;
        public Input3Enum Input3;
        public Input4Enum Input4;
        public override int SerializedSize
        {
            get
            {
                return 4;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Input1 = ((Input1Enum)(binaryReader.ReadByte()));
            this.Input2 = ((Input2Enum)(binaryReader.ReadByte()));
            this.Input3 = ((Input3Enum)(binaryReader.ReadByte()));
            this.Input4 = ((Input4Enum)(binaryReader.ReadByte()));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(((byte)(this.Input1)));
            queueableBinaryWriter.Write(((byte)(this.Input2)));
            queueableBinaryWriter.Write(((byte)(this.Input3)));
            queueableBinaryWriter.Write(((byte)(this.Input4)));
        }
        public enum Input1Enum : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            PARENTShield = 32,
            PARENTBody = 33,
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
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
        }
        public enum Input2Enum : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            PARENTShield = 32,
            PARENTBody = 33,
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
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
        }
        public enum Input3Enum : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            PARENTShield = 32,
            PARENTBody = 33,
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
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
        }
        public enum Input4Enum : byte
        {
            BASICZero = 0,
            BASICOne = 1,
            BASICTime = 2,
            BASICGlobalHudFade = 3,
            UNITShield = 16,
            UNITBody = 17,
            UNITAutoaimed = 18,
            UNITHasNoGrenades = 19,
            UNITFragGrenCnt = 20,
            UNITPlasmaGrenCnt = 21,
            UNITTimeOnDplShld = 22,
            UNITZoomFraction = 23,
            UNITCamoValue = 24,
            PARENTShield = 32,
            PARENTBody = 33,
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
            UserScoreFraction = 65,
            OtherUserScoreFraction = 66,
            UserWinning = 67,
            BombArmingAmount = 68,
        }
    }
}
