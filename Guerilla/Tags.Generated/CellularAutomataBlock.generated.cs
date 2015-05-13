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
    
    [TagClassAttribute("devo")]
    public partial class CellularAutomataBlock : GuerillaBlock, IWriteQueueable
    {
        public short UpdatesPerSecond;
        public short X;
        public short Y;
        public short Z;
        public float X0;
        public float Y0;
        public float Z0;
        private byte[] fieldpad = new byte[32];
        public Moonfish.Tags.StringIdent Marker;
        public float CellBirthChance;
        private byte[] fieldpad0 = new byte[32];
        public int CellGeneMutates1In;
        public int VirusGeneMutations1In;
        private byte[] fieldpad1 = new byte[32];
        public int InfectedCellLifespan;
        public short MinimumInfectionAge;
        private byte[] fieldpad2 = new byte[2];
        public float CellInfectionChance;
        public float InfectionThreshold;
        private byte[] fieldpad3 = new byte[32];
        public float NewCellFilledChance;
        public float NewCellInfectedChance;
        private byte[] fieldpad4 = new byte[32];
        public float DetailTextureChangeChance;
        private byte[] fieldpad5 = new byte[32];
        public short DetailTextureWidth;
        private byte[] fieldpad6 = new byte[2];
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference DetailTexture;
        private byte[] fieldpad7 = new byte[32];
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference MaskBitmap;
        private byte[] fieldpad8 = new byte[240];
        public override int SerializedSize
        {
            get
            {
                return 548;
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
            this.UpdatesPerSecond = binaryReader.ReadInt16();
            this.X = binaryReader.ReadInt16();
            this.Y = binaryReader.ReadInt16();
            this.Z = binaryReader.ReadInt16();
            this.X0 = binaryReader.ReadSingle();
            this.Y0 = binaryReader.ReadSingle();
            this.Z0 = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(32);
            this.Marker = binaryReader.ReadStringID();
            this.CellBirthChance = binaryReader.ReadSingle();
            this.fieldpad0 = binaryReader.ReadBytes(32);
            this.CellGeneMutates1In = binaryReader.ReadInt32();
            this.VirusGeneMutations1In = binaryReader.ReadInt32();
            this.fieldpad1 = binaryReader.ReadBytes(32);
            this.InfectedCellLifespan = binaryReader.ReadInt32();
            this.MinimumInfectionAge = binaryReader.ReadInt16();
            this.fieldpad2 = binaryReader.ReadBytes(2);
            this.CellInfectionChance = binaryReader.ReadSingle();
            this.InfectionThreshold = binaryReader.ReadSingle();
            this.fieldpad3 = binaryReader.ReadBytes(32);
            this.NewCellFilledChance = binaryReader.ReadSingle();
            this.NewCellInfectedChance = binaryReader.ReadSingle();
            this.fieldpad4 = binaryReader.ReadBytes(32);
            this.DetailTextureChangeChance = binaryReader.ReadSingle();
            this.fieldpad5 = binaryReader.ReadBytes(32);
            this.DetailTextureWidth = binaryReader.ReadInt16();
            this.fieldpad6 = binaryReader.ReadBytes(2);
            this.DetailTexture = binaryReader.ReadTagReference();
            this.fieldpad7 = binaryReader.ReadBytes(32);
            this.MaskBitmap = binaryReader.ReadTagReference();
            this.fieldpad8 = binaryReader.ReadBytes(240);
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
            queueableBinaryWriter.Write(this.UpdatesPerSecond);
            queueableBinaryWriter.Write(this.X);
            queueableBinaryWriter.Write(this.Y);
            queueableBinaryWriter.Write(this.Z);
            queueableBinaryWriter.Write(this.X0);
            queueableBinaryWriter.Write(this.Y0);
            queueableBinaryWriter.Write(this.Z0);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.Marker);
            queueableBinaryWriter.Write(this.CellBirthChance);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.CellGeneMutates1In);
            queueableBinaryWriter.Write(this.VirusGeneMutations1In);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.InfectedCellLifespan);
            queueableBinaryWriter.Write(this.MinimumInfectionAge);
            queueableBinaryWriter.Write(this.fieldpad2);
            queueableBinaryWriter.Write(this.CellInfectionChance);
            queueableBinaryWriter.Write(this.InfectionThreshold);
            queueableBinaryWriter.Write(this.fieldpad3);
            queueableBinaryWriter.Write(this.NewCellFilledChance);
            queueableBinaryWriter.Write(this.NewCellInfectedChance);
            queueableBinaryWriter.Write(this.fieldpad4);
            queueableBinaryWriter.Write(this.DetailTextureChangeChance);
            queueableBinaryWriter.Write(this.fieldpad5);
            queueableBinaryWriter.Write(this.DetailTextureWidth);
            queueableBinaryWriter.Write(this.fieldpad6);
            queueableBinaryWriter.Write(this.DetailTexture);
            queueableBinaryWriter.Write(this.fieldpad7);
            queueableBinaryWriter.Write(this.MaskBitmap);
            queueableBinaryWriter.Write(this.fieldpad8);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Devo = ((TagClass)("devo"));
    }
}
