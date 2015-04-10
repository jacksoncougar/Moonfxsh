// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioStartingEquipmentBlock : ScenarioStartingEquipmentBlockBase
    {
        public  ScenarioStartingEquipmentBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 156)]
    public class ScenarioStartingEquipmentBlockBase
    {
        internal Flags flags;
        internal GameType1 gameType1;
        internal GameType2 gameType2;
        internal GameType3 gameType3;
        internal GameType4 gameType4;
        internal byte[] invalidName_;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference itemCollection1;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference itemCollection2;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference itemCollection3;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference itemCollection4;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference itemCollection5;
        [TagReference("itmc")]
        internal Moonfish.Tags.TagReference itemCollection6;
        internal byte[] invalidName_0;
        internal  ScenarioStartingEquipmentBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            gameType1 = (GameType1)binaryReader.ReadInt16();
            gameType2 = (GameType2)binaryReader.ReadInt16();
            gameType3 = (GameType3)binaryReader.ReadInt16();
            gameType4 = (GameType4)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(48);
            itemCollection1 = binaryReader.ReadTagReference();
            itemCollection2 = binaryReader.ReadTagReference();
            itemCollection3 = binaryReader.ReadTagReference();
            itemCollection4 = binaryReader.ReadTagReference();
            itemCollection5 = binaryReader.ReadTagReference();
            itemCollection6 = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(48);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)gameType1);
                binaryWriter.Write((Int16)gameType2);
                binaryWriter.Write((Int16)gameType3);
                binaryWriter.Write((Int16)gameType4);
                binaryWriter.Write(invalidName_, 0, 48);
                binaryWriter.Write(itemCollection1);
                binaryWriter.Write(itemCollection2);
                binaryWriter.Write(itemCollection3);
                binaryWriter.Write(itemCollection4);
                binaryWriter.Write(itemCollection5);
                binaryWriter.Write(itemCollection6);
                binaryWriter.Write(invalidName_0, 0, 48);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            NoGrenades = 1,
            PlasmaGrenades = 2,
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
    };
}
