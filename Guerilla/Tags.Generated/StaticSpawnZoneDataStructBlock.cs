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
    public partial class StaticSpawnZoneDataStructBlock : StaticSpawnZoneDataStructBlockBase
    {
        public StaticSpawnZoneDataStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class StaticSpawnZoneDataStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal RelevantTeam relevantTeam;
        internal RelevantGames relevantGames;
        internal Flags flags;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StaticSpawnZoneDataStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            relevantTeam = (RelevantTeam) binaryReader.ReadInt32();
            relevantGames = (RelevantGames) binaryReader.ReadInt32();
            flags = (Flags) binaryReader.ReadInt32();
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
                binaryWriter.Write(name);
                binaryWriter.Write((Int32) relevantTeam);
                binaryWriter.Write((Int32) relevantGames);
                binaryWriter.Write((Int32) flags);
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