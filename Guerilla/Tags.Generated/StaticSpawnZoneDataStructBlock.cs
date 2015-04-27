// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StaticSpawnZoneDataStructBlock : StaticSpawnZoneDataStructBlockBase
    {
        public  StaticSpawnZoneDataStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StaticSpawnZoneDataStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class StaticSpawnZoneDataStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal RelevantTeam relevantTeam;
        internal RelevantGames relevantGames;
        internal Flags flags;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StaticSpawnZoneDataStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            relevantTeam = (RelevantTeam)binaryReader.ReadInt32();
            relevantGames = (RelevantGames)binaryReader.ReadInt32();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public  StaticSpawnZoneDataStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            relevantTeam = (RelevantTeam)binaryReader.ReadInt32();
            relevantGames = (RelevantGames)binaryReader.ReadInt32();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)relevantTeam);
                binaryWriter.Write((Int32)relevantGames);
                binaryWriter.Write((Int32)flags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum RelevantTeam : int
        {
            RedAlpha = 1,
            BlueBravo = 2,
            YellowCharlie = 4,
            GreenDelta = 8,
            PurpleEcho = 16,
            OrangeFoxtrot = 32,
            BrownGolf = 64,
            PinkHotel = 128,
            NEUTRAL = 256,
        };
        [FlagsAttribute]
        internal enum RelevantGames : int
        {
            Slayer = 1,
            Oddball = 2,
            KingOfTheHill = 4,
            CaptureTheFlag = 8,
            Race = 16,
            Headhunter = 32,
            Juggernaut = 64,
            Territories = 128,
        };
        [FlagsAttribute]
        internal enum Flags : int
        {
            DisabledIfFlagHome = 1,
            DisabledIfFlagAway = 2,
            DisabledIfBombHome = 4,
            DisabledIfBombAway = 8,
        };
    };
}
