using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioPlayersBlock : ScenarioPlayersBlockBase
    {
        public  ScenarioPlayersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class ScenarioPlayersBlockBase
    {
        internal OpenTK.Vector3 position;
        internal float facingDegrees;
        internal TeamDesignator teamDesignator;
        internal short bSPIndex;
        internal GameType1 gameType1;
        internal GameType2 gameType2;
        internal GameType3 gameType3;
        internal GameType4 gameType4;
        internal SpawnType0 spawnType0;
        internal SpawnType1 spawnType1;
        internal SpawnType2 spawnType2;
        internal SpawnType3 spawnType3;
        internal Moonfish.Tags.StringID eMPTYSTRING;
        internal Moonfish.Tags.StringID eMPTYSTRING0;
        internal CampaignPlayerType campaignPlayerType;
        internal byte[] invalidName_;
        internal  ScenarioPlayersBlockBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.facingDegrees = binaryReader.ReadSingle();
            this.teamDesignator = (TeamDesignator)binaryReader.ReadInt16();
            this.bSPIndex = binaryReader.ReadInt16();
            this.gameType1 = (GameType1)binaryReader.ReadInt16();
            this.gameType2 = (GameType2)binaryReader.ReadInt16();
            this.gameType3 = (GameType3)binaryReader.ReadInt16();
            this.gameType4 = (GameType4)binaryReader.ReadInt16();
            this.spawnType0 = (SpawnType0)binaryReader.ReadInt16();
            this.spawnType1 = (SpawnType1)binaryReader.ReadInt16();
            this.spawnType2 = (SpawnType2)binaryReader.ReadInt16();
            this.spawnType3 = (SpawnType3)binaryReader.ReadInt16();
            this.eMPTYSTRING = binaryReader.ReadStringID();
            this.eMPTYSTRING0 = binaryReader.ReadStringID();
            this.campaignPlayerType = (CampaignPlayerType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(6);
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
        internal enum TeamDesignator : short
        
        {
            RedAlpha = 0,
            BlueBravo = 1,
            YellowCharlie = 2,
            GreenDelta = 3,
            PurpleEcho = 4,
            OrangeFoxtrot = 5,
            BrownGolf = 6,
            PinkHotel = 7,
            NEUTRAL = 8,
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
        internal enum SpawnType0 : short
        
        {
            Both = 0,
            InitialSpawnOnly = 1,
            RespawnOnly = 2,
        };
        internal enum SpawnType1 : short
        
        {
            Both = 0,
            InitialSpawnOnly = 1,
            RespawnOnly = 2,
        };
        internal enum SpawnType2 : short
        
        {
            Both = 0,
            InitialSpawnOnly = 1,
            RespawnOnly = 2,
        };
        internal enum SpawnType3 : short
        
        {
            Both = 0,
            InitialSpawnOnly = 1,
            RespawnOnly = 2,
        };
        internal enum CampaignPlayerType : short
        
        {
            Masterchief = 0,
            Dervish = 1,
            ChiefMultiplayer = 2,
            EliteMultiplayer = 3,
        };
    };
}
