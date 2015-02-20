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
        public  ScenarioStartingEquipmentBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioStartingEquipmentBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.gameType1 = (GameType1)binaryReader.ReadInt16();
            this.gameType2 = (GameType2)binaryReader.ReadInt16();
            this.gameType3 = (GameType3)binaryReader.ReadInt16();
            this.gameType4 = (GameType4)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(48);
            this.itemCollection1 = binaryReader.ReadTagReference();
            this.itemCollection2 = binaryReader.ReadTagReference();
            this.itemCollection3 = binaryReader.ReadTagReference();
            this.itemCollection4 = binaryReader.ReadTagReference();
            this.itemCollection5 = binaryReader.ReadTagReference();
            this.itemCollection6 = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(48);
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
