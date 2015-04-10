using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioNetgameEquipmentBlock : ScenarioNetgameEquipmentBlockBase
    {
        public  ScenarioNetgameEquipmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 144)]
    public class ScenarioNetgameEquipmentBlockBase
    {
        internal Flags flags;
        internal GameType1 gameType1;
        internal GameType2 gameType2;
        internal GameType3 gameType3;
        internal GameType4 gameType4;
        internal byte[] invalidName_;
        internal short spawnTimeInSeconds0Default;
        internal short respawnOnEmptyTimeSeconds;
        internal RespawnTimerStarts respawnTimerStarts;
        internal Classification classification;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal OpenTK.Vector3 position;
        internal ScenarioNetgameEquipmentOrientationStructBlock orientation;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference itemVehicleCollection;
        internal byte[] invalidName_2;
        internal  ScenarioNetgameEquipmentBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.gameType1 = (GameType1)binaryReader.ReadInt16();
            this.gameType2 = (GameType2)binaryReader.ReadInt16();
            this.gameType3 = (GameType3)binaryReader.ReadInt16();
            this.gameType4 = (GameType4)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            this.respawnOnEmptyTimeSeconds = binaryReader.ReadInt16();
            this.respawnTimerStarts = (RespawnTimerStarts)binaryReader.ReadInt16();
            this.classification = (Classification)binaryReader.ReadByte();
            this.invalidName_0 = binaryReader.ReadBytes(3);
            this.invalidName_1 = binaryReader.ReadBytes(40);
            this.position = binaryReader.ReadVector3();
            this.orientation = new ScenarioNetgameEquipmentOrientationStructBlock(binaryReader);
            this.itemVehicleCollection = binaryReader.ReadTagReference();
            this.invalidName_2 = binaryReader.ReadBytes(48);
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
        internal enum Flags : int
        
        {
            Levitate = 1,
            DestroyExistingOnNewSpawn = 2,
        };
        internal enum GameType1 : short
        
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
        };
        internal enum GameType2 : short
        
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
        };
        internal enum GameType3 : short
        
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
        };
        internal enum GameType4 : short
        
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
        };
        internal enum RespawnTimerStarts : short
        
        {
            OnPickUp = 0,
            OnBodyDepletion = 1,
        };
        internal enum Classification : byte
        
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
        };
    };
}
