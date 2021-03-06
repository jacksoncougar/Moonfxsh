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
    
    public partial class ScenarioObjectIdStructBlock : GuerillaBlock, IWriteQueueable
    {
        public int UniqueID;
        public Moonfish.Tags.ShortBlockIndex1 OriginBSPIndex;
        public TypeEnum Type;
        public SourceEnum Source;
        public override int SerializedSize
        {
            get
            {
                return 8;
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
            this.UniqueID = binaryReader.ReadInt32();
            this.OriginBSPIndex = binaryReader.ReadShortBlockIndex1();
            this.Type = ((TypeEnum)(binaryReader.ReadByte()));
            this.Source = ((SourceEnum)(binaryReader.ReadByte()));
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
            queueableBinaryWriter.Write(this.UniqueID);
            queueableBinaryWriter.Write(this.OriginBSPIndex);
            queueableBinaryWriter.Write(((byte)(this.Type)));
            queueableBinaryWriter.Write(((byte)(this.Source)));
        }
        public enum TypeEnum : byte
        {
            Biped = 0,
            Vehicle = 1,
            Weapon = 2,
            Equipment = 3,
            Garbage = 4,
            Projectile = 5,
            Scenery = 6,
            Machine = 7,
            Control = 8,
            LightFixture = 9,
            SoundScenery = 10,
            Crate = 11,
            Creature = 12,
        }
        public enum SourceEnum : byte
        {
            Structure = 0,
            Editor = 1,
            Dynamic = 2,
            Legacy = 3,
        }
    }
}
