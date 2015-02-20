using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalUiMultiplayerLevelBlock : GlobalUiMultiplayerLevelBlockBase
    {
        public  GlobalUiMultiplayerLevelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 3172)]
    public class GlobalUiMultiplayerLevelBlockBase
    {
        internal int mapID;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.String256 path;
        internal int sortOrder;
        internal Flags flags;
        internal byte[] invalidName_1;
        internal byte maxTeamsNone;
        internal byte maxTeamsCTF;
        internal byte maxTeamsSlayer;
        internal byte maxTeamsOddball;
        internal byte maxTeamsKOTH;
        internal byte maxTeamsRace;
        internal byte maxTeamsHeadhunter;
        internal byte maxTeamsJuggernaut;
        internal byte maxTeamsTerritories;
        internal byte maxTeamsAssault;
        internal byte maxTeamsStub10;
        internal byte maxTeamsStub11;
        internal byte maxTeamsStub12;
        internal byte maxTeamsStub13;
        internal byte maxTeamsStub14;
        internal byte maxTeamsStub15;
        internal  GlobalUiMultiplayerLevelBlockBase(BinaryReader binaryReader)
        {
            this.mapID = binaryReader.ReadInt32();
            this.bitmap = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(576);
            this.invalidName_0 = binaryReader.ReadBytes(2304);
            this.path = binaryReader.ReadString256();
            this.sortOrder = binaryReader.ReadInt32();
            this.flags = (Flags)binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadBytes(3);
            this.maxTeamsNone = binaryReader.ReadByte();
            this.maxTeamsCTF = binaryReader.ReadByte();
            this.maxTeamsSlayer = binaryReader.ReadByte();
            this.maxTeamsOddball = binaryReader.ReadByte();
            this.maxTeamsKOTH = binaryReader.ReadByte();
            this.maxTeamsRace = binaryReader.ReadByte();
            this.maxTeamsHeadhunter = binaryReader.ReadByte();
            this.maxTeamsJuggernaut = binaryReader.ReadByte();
            this.maxTeamsTerritories = binaryReader.ReadByte();
            this.maxTeamsAssault = binaryReader.ReadByte();
            this.maxTeamsStub10 = binaryReader.ReadByte();
            this.maxTeamsStub11 = binaryReader.ReadByte();
            this.maxTeamsStub12 = binaryReader.ReadByte();
            this.maxTeamsStub13 = binaryReader.ReadByte();
            this.maxTeamsStub14 = binaryReader.ReadByte();
            this.maxTeamsStub15 = binaryReader.ReadByte();
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
        internal enum Flags : byte
        
        {
            Unlockable = 1,
        };
    };
}
