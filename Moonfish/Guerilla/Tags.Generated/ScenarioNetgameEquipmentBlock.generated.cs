//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("scenario_netgame_equipment_block")]
    public partial class ScenarioNetgameEquipmentBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags ScenarioNetgameEquipmentFlags;
        public GameType1Enum GameType1;
        public GameType2Enum GameType2;
        public GameType3Enum GameType3;
        public GameType4Enum GameType4;
        private byte[] fieldpad = new byte[2];
        public short SpawnTime;
        public short RespawnOnEmptyTime;
        public RespawnTimerStartsEnum RespawnTimerStarts;
        public ClassificationEnum Classification;
        private byte[] fieldpad0 = new byte[3];
        private byte[] fieldpad1 = new byte[40];
        public OpenTK.Vector3 Position;
        public ScenarioNetgameEquipmentOrientationStructBlock Orientation = new ScenarioNetgameEquipmentOrientationStructBlock();
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference ItemVehicleCollection;
        private byte[] fieldpad2 = new byte[48];
        public override int SerializedSize
        {
            get
            {
                return 144;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.ScenarioNetgameEquipmentFlags = ((Flags)(binaryReader.ReadInt32()));
            this.GameType1 = ((GameType1Enum)(binaryReader.ReadInt16()));
            this.GameType2 = ((GameType2Enum)(binaryReader.ReadInt16()));
            this.GameType3 = ((GameType3Enum)(binaryReader.ReadInt16()));
            this.GameType4 = ((GameType4Enum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.SpawnTime = binaryReader.ReadInt16();
            this.RespawnOnEmptyTime = binaryReader.ReadInt16();
            this.RespawnTimerStarts = ((RespawnTimerStartsEnum)(binaryReader.ReadInt16()));
            this.Classification = ((ClassificationEnum)(binaryReader.ReadByte()));
            this.fieldpad0 = binaryReader.ReadBytes(3);
            this.fieldpad1 = binaryReader.ReadBytes(40);
            this.Position = binaryReader.ReadVector3();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Orientation.ReadFields(binaryReader)));
            this.ItemVehicleCollection = binaryReader.ReadTagReference();
            this.fieldpad2 = binaryReader.ReadBytes(48);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Orientation.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.Orientation.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((int)(this.ScenarioNetgameEquipmentFlags)));
            queueableBinaryWriter.Write(((short)(this.GameType1)));
            queueableBinaryWriter.Write(((short)(this.GameType2)));
            queueableBinaryWriter.Write(((short)(this.GameType3)));
            queueableBinaryWriter.Write(((short)(this.GameType4)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.SpawnTime);
            queueableBinaryWriter.Write(this.RespawnOnEmptyTime);
            queueableBinaryWriter.Write(((short)(this.RespawnTimerStarts)));
            queueableBinaryWriter.Write(((byte)(this.Classification)));
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.Position);
            this.Orientation.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.ItemVehicleCollection);
            queueableBinaryWriter.Write(this.fieldpad2);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Levitate = 1,
            DestroyExistingOnNewSpawn = 2,
        }
        public enum GameType1Enum : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        }
        public enum GameType2Enum : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        }
        public enum GameType3Enum : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        }
        public enum GameType4Enum : short
        {
            NONE = 0,
            CaptureTheFlag = 1,
            Slayer = 2,
            Oddball = 3,
            KingOfTheHill = 4,
            Race = 5,
            Headhunter = 6,
            Juggernaut = 7,
            Territories = 8,
            Stub = 9,
            Ignored3 = 10,
            Ignored4 = 11,
            AllGameTypes = 12,
            AllExceptCTF = 13,
            AllExceptCTFRace = 14,
        }
        public enum RespawnTimerStartsEnum : short
        {
            OnPickUp = 0,
            OnBodyDepletion = 1,
        }
        public enum ClassificationEnum : byte
        {
            Weapon = 0,
            PrimaryLightLand = 1,
            SecondaryLightLand = 2,
            PrimaryHeavyLand = 3,
            PrimaryFlying = 4,
            SecondaryHeavyLand = 5,
            PrimaryTurret = 6,
            SecondaryTurret = 7,
            Grenade = 8,
            Powerup = 9,
        }
    }
}
