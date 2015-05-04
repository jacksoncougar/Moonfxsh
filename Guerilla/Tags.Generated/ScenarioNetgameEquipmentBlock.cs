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
    public partial class ScenarioNetgameEquipmentBlock : ScenarioNetgameEquipmentBlockBase
    {
        public ScenarioNetgameEquipmentBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 4)]
    public class ScenarioNetgameEquipmentBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 144; } }
        public override int Alignment { get { return 4; } }
        public ScenarioNetgameEquipmentBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            gameType1 = (GameType1)binaryReader.ReadInt16();
            gameType2 = (GameType2)binaryReader.ReadInt16();
            gameType3 = (GameType3)binaryReader.ReadInt16();
            gameType4 = (GameType4)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            respawnOnEmptyTimeSeconds = binaryReader.ReadInt16();
            respawnTimerStarts = (RespawnTimerStarts)binaryReader.ReadInt16();
            classification = (Classification)binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(3);
            invalidName_1 = binaryReader.ReadBytes(40);
            position = binaryReader.ReadVector3();
            orientation = new ScenarioNetgameEquipmentOrientationStructBlock();
            blamPointers.Concat(orientation.ReadFields(binaryReader));
            itemVehicleCollection = binaryReader.ReadTagReference();
            invalidName_2 = binaryReader.ReadBytes(48);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_1[16].ReadPointers(binaryReader, blamPointers);
            invalidName_1[17].ReadPointers(binaryReader, blamPointers);
            invalidName_1[18].ReadPointers(binaryReader, blamPointers);
            invalidName_1[19].ReadPointers(binaryReader, blamPointers);
            invalidName_1[20].ReadPointers(binaryReader, blamPointers);
            invalidName_1[21].ReadPointers(binaryReader, blamPointers);
            invalidName_1[22].ReadPointers(binaryReader, blamPointers);
            invalidName_1[23].ReadPointers(binaryReader, blamPointers);
            invalidName_1[24].ReadPointers(binaryReader, blamPointers);
            invalidName_1[25].ReadPointers(binaryReader, blamPointers);
            invalidName_1[26].ReadPointers(binaryReader, blamPointers);
            invalidName_1[27].ReadPointers(binaryReader, blamPointers);
            invalidName_1[28].ReadPointers(binaryReader, blamPointers);
            invalidName_1[29].ReadPointers(binaryReader, blamPointers);
            invalidName_1[30].ReadPointers(binaryReader, blamPointers);
            invalidName_1[31].ReadPointers(binaryReader, blamPointers);
            invalidName_1[32].ReadPointers(binaryReader, blamPointers);
            invalidName_1[33].ReadPointers(binaryReader, blamPointers);
            invalidName_1[34].ReadPointers(binaryReader, blamPointers);
            invalidName_1[35].ReadPointers(binaryReader, blamPointers);
            invalidName_1[36].ReadPointers(binaryReader, blamPointers);
            invalidName_1[37].ReadPointers(binaryReader, blamPointers);
            invalidName_1[38].ReadPointers(binaryReader, blamPointers);
            invalidName_1[39].ReadPointers(binaryReader, blamPointers);
            orientation.ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_2[20].ReadPointers(binaryReader, blamPointers);
            invalidName_2[21].ReadPointers(binaryReader, blamPointers);
            invalidName_2[22].ReadPointers(binaryReader, blamPointers);
            invalidName_2[23].ReadPointers(binaryReader, blamPointers);
            invalidName_2[24].ReadPointers(binaryReader, blamPointers);
            invalidName_2[25].ReadPointers(binaryReader, blamPointers);
            invalidName_2[26].ReadPointers(binaryReader, blamPointers);
            invalidName_2[27].ReadPointers(binaryReader, blamPointers);
            invalidName_2[28].ReadPointers(binaryReader, blamPointers);
            invalidName_2[29].ReadPointers(binaryReader, blamPointers);
            invalidName_2[30].ReadPointers(binaryReader, blamPointers);
            invalidName_2[31].ReadPointers(binaryReader, blamPointers);
            invalidName_2[32].ReadPointers(binaryReader, blamPointers);
            invalidName_2[33].ReadPointers(binaryReader, blamPointers);
            invalidName_2[34].ReadPointers(binaryReader, blamPointers);
            invalidName_2[35].ReadPointers(binaryReader, blamPointers);
            invalidName_2[36].ReadPointers(binaryReader, blamPointers);
            invalidName_2[37].ReadPointers(binaryReader, blamPointers);
            invalidName_2[38].ReadPointers(binaryReader, blamPointers);
            invalidName_2[39].ReadPointers(binaryReader, blamPointers);
            invalidName_2[40].ReadPointers(binaryReader, blamPointers);
            invalidName_2[41].ReadPointers(binaryReader, blamPointers);
            invalidName_2[42].ReadPointers(binaryReader, blamPointers);
            invalidName_2[43].ReadPointers(binaryReader, blamPointers);
            invalidName_2[44].ReadPointers(binaryReader, blamPointers);
            invalidName_2[45].ReadPointers(binaryReader, blamPointers);
            invalidName_2[46].ReadPointers(binaryReader, blamPointers);
            invalidName_2[47].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)gameType1);
                binaryWriter.Write((Int16)gameType2);
                binaryWriter.Write((Int16)gameType3);
                binaryWriter.Write((Int16)gameType4);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(spawnTimeInSeconds0Default);
                binaryWriter.Write(respawnOnEmptyTimeSeconds);
                binaryWriter.Write((Int16)respawnTimerStarts);
                binaryWriter.Write((Byte)classification);
                binaryWriter.Write(invalidName_0, 0, 3);
                binaryWriter.Write(invalidName_1, 0, 40);
                binaryWriter.Write(position);
                orientation.Write(binaryWriter);
                binaryWriter.Write(itemVehicleCollection);
                binaryWriter.Write(invalidName_2, 0, 48);
                return nextAddress;
            }
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
