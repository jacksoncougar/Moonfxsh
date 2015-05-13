//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class GlobalUiMultiplayerLevelBlock : GuerillaBlock, IWriteQueueable
    {
        public int MapID;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference Bitmap;
        private byte[] fieldskip = new byte[576];
        private byte[] fieldskip0 = new byte[2304];
        public Moonfish.Tags.String256 Path;
        public int SortOrder;
        public Flags GlobalUiMultiplayerLevelFlags;
        private byte[] fieldpad = new byte[3];
        public byte MaxTeamsNone;
        public byte MaxTeamsCTF;
        public byte MaxTeamsSlayer;
        public byte MaxTeamsOddball;
        public byte MaxTeamsKOTH;
        public byte MaxTeamsRace;
        public byte MaxTeamsHeadhunter;
        public byte MaxTeamsJuggernaut;
        public byte MaxTeamsTerritories;
        public byte MaxTeamsAssault;
        public byte MaxTeamsStub10;
        public byte MaxTeamsStub11;
        public byte MaxTeamsStub12;
        public byte MaxTeamsStub13;
        public byte MaxTeamsStub14;
        public byte MaxTeamsStub15;
        public override int SerializedSize
        {
            get
            {
                return 3172;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.MapID = binaryReader.ReadInt32();
            this.Bitmap = binaryReader.ReadTagReference();
            this.fieldskip = binaryReader.ReadBytes(576);
            this.fieldskip0 = binaryReader.ReadBytes(2304);
            this.Path = binaryReader.ReadString256();
            this.SortOrder = binaryReader.ReadInt32();
            this.GlobalUiMultiplayerLevelFlags = ((Flags)(binaryReader.ReadByte()));
            this.fieldpad = binaryReader.ReadBytes(3);
            this.MaxTeamsNone = binaryReader.ReadByte();
            this.MaxTeamsCTF = binaryReader.ReadByte();
            this.MaxTeamsSlayer = binaryReader.ReadByte();
            this.MaxTeamsOddball = binaryReader.ReadByte();
            this.MaxTeamsKOTH = binaryReader.ReadByte();
            this.MaxTeamsRace = binaryReader.ReadByte();
            this.MaxTeamsHeadhunter = binaryReader.ReadByte();
            this.MaxTeamsJuggernaut = binaryReader.ReadByte();
            this.MaxTeamsTerritories = binaryReader.ReadByte();
            this.MaxTeamsAssault = binaryReader.ReadByte();
            this.MaxTeamsStub10 = binaryReader.ReadByte();
            this.MaxTeamsStub11 = binaryReader.ReadByte();
            this.MaxTeamsStub12 = binaryReader.ReadByte();
            this.MaxTeamsStub13 = binaryReader.ReadByte();
            this.MaxTeamsStub14 = binaryReader.ReadByte();
            this.MaxTeamsStub15 = binaryReader.ReadByte();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.MapID);
            queueableBinaryWriter.Write(this.Bitmap);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.fieldskip0);
            queueableBinaryWriter.Write(this.Path);
            queueableBinaryWriter.Write(this.SortOrder);
            queueableBinaryWriter.Write(((byte)(this.GlobalUiMultiplayerLevelFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.MaxTeamsNone);
            queueableBinaryWriter.Write(this.MaxTeamsCTF);
            queueableBinaryWriter.Write(this.MaxTeamsSlayer);
            queueableBinaryWriter.Write(this.MaxTeamsOddball);
            queueableBinaryWriter.Write(this.MaxTeamsKOTH);
            queueableBinaryWriter.Write(this.MaxTeamsRace);
            queueableBinaryWriter.Write(this.MaxTeamsHeadhunter);
            queueableBinaryWriter.Write(this.MaxTeamsJuggernaut);
            queueableBinaryWriter.Write(this.MaxTeamsTerritories);
            queueableBinaryWriter.Write(this.MaxTeamsAssault);
            queueableBinaryWriter.Write(this.MaxTeamsStub10);
            queueableBinaryWriter.Write(this.MaxTeamsStub11);
            queueableBinaryWriter.Write(this.MaxTeamsStub12);
            queueableBinaryWriter.Write(this.MaxTeamsStub13);
            queueableBinaryWriter.Write(this.MaxTeamsStub14);
            queueableBinaryWriter.Write(this.MaxTeamsStub15);
        }
        [System.FlagsAttribute()]
        public enum Flags : byte
        {
            None = 0,
            Unlockable = 1,
        }
    }
}
