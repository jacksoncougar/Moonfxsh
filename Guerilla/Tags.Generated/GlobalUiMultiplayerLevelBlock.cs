// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalUiMultiplayerLevelBlock : GlobalUiMultiplayerLevelBlockBase
    {
        public  GlobalUiMultiplayerLevelBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalUiMultiplayerLevelBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 3172, Alignment = 4)]
    public class GlobalUiMultiplayerLevelBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 3172; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalUiMultiplayerLevelBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            mapID = binaryReader.ReadInt32();
            bitmap = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(576);
            invalidName_0 = binaryReader.ReadBytes(2304);
            path = binaryReader.ReadString256();
            sortOrder = binaryReader.ReadInt32();
            flags = (Flags)binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadBytes(3);
            maxTeamsNone = binaryReader.ReadByte();
            maxTeamsCTF = binaryReader.ReadByte();
            maxTeamsSlayer = binaryReader.ReadByte();
            maxTeamsOddball = binaryReader.ReadByte();
            maxTeamsKOTH = binaryReader.ReadByte();
            maxTeamsRace = binaryReader.ReadByte();
            maxTeamsHeadhunter = binaryReader.ReadByte();
            maxTeamsJuggernaut = binaryReader.ReadByte();
            maxTeamsTerritories = binaryReader.ReadByte();
            maxTeamsAssault = binaryReader.ReadByte();
            maxTeamsStub10 = binaryReader.ReadByte();
            maxTeamsStub11 = binaryReader.ReadByte();
            maxTeamsStub12 = binaryReader.ReadByte();
            maxTeamsStub13 = binaryReader.ReadByte();
            maxTeamsStub14 = binaryReader.ReadByte();
            maxTeamsStub15 = binaryReader.ReadByte();
        }
        public  GlobalUiMultiplayerLevelBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            mapID = binaryReader.ReadInt32();
            bitmap = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(576);
            invalidName_0 = binaryReader.ReadBytes(2304);
            path = binaryReader.ReadString256();
            sortOrder = binaryReader.ReadInt32();
            flags = (Flags)binaryReader.ReadByte();
            invalidName_1 = binaryReader.ReadBytes(3);
            maxTeamsNone = binaryReader.ReadByte();
            maxTeamsCTF = binaryReader.ReadByte();
            maxTeamsSlayer = binaryReader.ReadByte();
            maxTeamsOddball = binaryReader.ReadByte();
            maxTeamsKOTH = binaryReader.ReadByte();
            maxTeamsRace = binaryReader.ReadByte();
            maxTeamsHeadhunter = binaryReader.ReadByte();
            maxTeamsJuggernaut = binaryReader.ReadByte();
            maxTeamsTerritories = binaryReader.ReadByte();
            maxTeamsAssault = binaryReader.ReadByte();
            maxTeamsStub10 = binaryReader.ReadByte();
            maxTeamsStub11 = binaryReader.ReadByte();
            maxTeamsStub12 = binaryReader.ReadByte();
            maxTeamsStub13 = binaryReader.ReadByte();
            maxTeamsStub14 = binaryReader.ReadByte();
            maxTeamsStub15 = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(mapID);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(invalidName_, 0, 576);
                binaryWriter.Write(invalidName_0, 0, 2304);
                binaryWriter.Write(path);
                binaryWriter.Write(sortOrder);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(invalidName_1, 0, 3);
                binaryWriter.Write(maxTeamsNone);
                binaryWriter.Write(maxTeamsCTF);
                binaryWriter.Write(maxTeamsSlayer);
                binaryWriter.Write(maxTeamsOddball);
                binaryWriter.Write(maxTeamsKOTH);
                binaryWriter.Write(maxTeamsRace);
                binaryWriter.Write(maxTeamsHeadhunter);
                binaryWriter.Write(maxTeamsJuggernaut);
                binaryWriter.Write(maxTeamsTerritories);
                binaryWriter.Write(maxTeamsAssault);
                binaryWriter.Write(maxTeamsStub10);
                binaryWriter.Write(maxTeamsStub11);
                binaryWriter.Write(maxTeamsStub12);
                binaryWriter.Write(maxTeamsStub13);
                binaryWriter.Write(maxTeamsStub14);
                binaryWriter.Write(maxTeamsStub15);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        {
            Unlockable = 1,
        };
    };
}
