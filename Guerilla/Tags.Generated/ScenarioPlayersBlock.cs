// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioPlayersBlock : ScenarioPlayersBlockBase
    {
        public  ScenarioPlayersBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioPlayersBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class ScenarioPlayersBlockBase : GuerillaBlock
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
        internal Moonfish.Tags.StringIdent eMPTYSTRING;
        internal Moonfish.Tags.StringIdent eMPTYSTRING0;
        internal CampaignPlayerType campaignPlayerType;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 52; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioPlayersBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            position = binaryReader.ReadVector3();
            facingDegrees = binaryReader.ReadSingle();
            teamDesignator = (TeamDesignator)binaryReader.ReadInt16();
            bSPIndex = binaryReader.ReadInt16();
            gameType1 = (GameType1)binaryReader.ReadInt16();
            gameType2 = (GameType2)binaryReader.ReadInt16();
            gameType3 = (GameType3)binaryReader.ReadInt16();
            gameType4 = (GameType4)binaryReader.ReadInt16();
            spawnType0 = (SpawnType0)binaryReader.ReadInt16();
            spawnType1 = (SpawnType1)binaryReader.ReadInt16();
            spawnType2 = (SpawnType2)binaryReader.ReadInt16();
            spawnType3 = (SpawnType3)binaryReader.ReadInt16();
            eMPTYSTRING = binaryReader.ReadStringID();
            eMPTYSTRING0 = binaryReader.ReadStringID();
            campaignPlayerType = (CampaignPlayerType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(6);
        }
        public  ScenarioPlayersBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            facingDegrees = binaryReader.ReadSingle();
            teamDesignator = (TeamDesignator)binaryReader.ReadInt16();
            bSPIndex = binaryReader.ReadInt16();
            gameType1 = (GameType1)binaryReader.ReadInt16();
            gameType2 = (GameType2)binaryReader.ReadInt16();
            gameType3 = (GameType3)binaryReader.ReadInt16();
            gameType4 = (GameType4)binaryReader.ReadInt16();
            spawnType0 = (SpawnType0)binaryReader.ReadInt16();
            spawnType1 = (SpawnType1)binaryReader.ReadInt16();
            spawnType2 = (SpawnType2)binaryReader.ReadInt16();
            spawnType3 = (SpawnType3)binaryReader.ReadInt16();
            eMPTYSTRING = binaryReader.ReadStringID();
            eMPTYSTRING0 = binaryReader.ReadStringID();
            campaignPlayerType = (CampaignPlayerType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(6);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                binaryWriter.Write(facingDegrees);
                binaryWriter.Write((Int16)teamDesignator);
                binaryWriter.Write(bSPIndex);
                binaryWriter.Write((Int16)gameType1);
                binaryWriter.Write((Int16)gameType2);
                binaryWriter.Write((Int16)gameType3);
                binaryWriter.Write((Int16)gameType4);
                binaryWriter.Write((Int16)spawnType0);
                binaryWriter.Write((Int16)spawnType1);
                binaryWriter.Write((Int16)spawnType2);
                binaryWriter.Write((Int16)spawnType3);
                binaryWriter.Write(eMPTYSTRING);
                binaryWriter.Write(eMPTYSTRING0);
                binaryWriter.Write((Int16)campaignPlayerType);
                binaryWriter.Write(invalidName_, 0, 6);
                return nextAddress;
            }
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
