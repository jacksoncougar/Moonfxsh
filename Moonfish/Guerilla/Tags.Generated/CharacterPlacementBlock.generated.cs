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
    
    public partial class CharacterPlacementBlock : GuerillaBlock, IWriteQueueable
    {
        private byte[] fieldpad = new byte[4];
        public float FewUpgradeChance;
        public float FewUpgradeChance0;
        public float FewUpgradeChance1;
        public float FewUpgradeChance2;
        public float NormalUpgradeChance;
        public float NormalUpgradeChance0;
        public float NormalUpgradeChance1;
        public float NormalUpgradeChance2;
        public float ManyUpgradeChance;
        public float ManyUpgradeChance0;
        public float ManyUpgradeChance1;
        public float ManyUpgradeChance2;
        public override int SerializedSize
        {
            get
            {
                return 52;
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
            this.fieldpad = binaryReader.ReadBytes(4);
            this.FewUpgradeChance = binaryReader.ReadSingle();
            this.FewUpgradeChance0 = binaryReader.ReadSingle();
            this.FewUpgradeChance1 = binaryReader.ReadSingle();
            this.FewUpgradeChance2 = binaryReader.ReadSingle();
            this.NormalUpgradeChance = binaryReader.ReadSingle();
            this.NormalUpgradeChance0 = binaryReader.ReadSingle();
            this.NormalUpgradeChance1 = binaryReader.ReadSingle();
            this.NormalUpgradeChance2 = binaryReader.ReadSingle();
            this.ManyUpgradeChance = binaryReader.ReadSingle();
            this.ManyUpgradeChance0 = binaryReader.ReadSingle();
            this.ManyUpgradeChance1 = binaryReader.ReadSingle();
            this.ManyUpgradeChance2 = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.FewUpgradeChance);
            queueableBlamBinaryWriter.Write(this.FewUpgradeChance0);
            queueableBlamBinaryWriter.Write(this.FewUpgradeChance1);
            queueableBlamBinaryWriter.Write(this.FewUpgradeChance2);
            queueableBlamBinaryWriter.Write(this.NormalUpgradeChance);
            queueableBlamBinaryWriter.Write(this.NormalUpgradeChance0);
            queueableBlamBinaryWriter.Write(this.NormalUpgradeChance1);
            queueableBlamBinaryWriter.Write(this.NormalUpgradeChance2);
            queueableBlamBinaryWriter.Write(this.ManyUpgradeChance);
            queueableBlamBinaryWriter.Write(this.ManyUpgradeChance0);
            queueableBlamBinaryWriter.Write(this.ManyUpgradeChance1);
            queueableBlamBinaryWriter.Write(this.ManyUpgradeChance2);
        }
    }
}
