using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StaticSpawnZoneDataStructBlock : StaticSpawnZoneDataStructBlockBase
    {
        public  StaticSpawnZoneDataStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class StaticSpawnZoneDataStructBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal RelevantTeam relevantTeam;
        internal RelevantGames relevantGames;
        internal Flags flags;
        internal  StaticSpawnZoneDataStructBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.relevantTeam = (RelevantTeam)binaryReader.ReadInt32();
            this.relevantGames = (RelevantGames)binaryReader.ReadInt32();
            this.flags = (Flags)binaryReader.ReadInt32();
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
