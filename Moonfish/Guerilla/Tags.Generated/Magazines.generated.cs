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
    
    public partial class Magazines : GuerillaBlock, IWriteQueueable
    {
        public Flags MagazinesFlags;
        public short RoundsRecharged;
        public short RoundsTotalInitial;
        public short RoundsTotalMaximum;
        public short RoundsLoadedMaximum;
        private byte[] fieldpad = new byte[4];
        public float ReloadTime;
        public short RoundsReloaded;
        private byte[] fieldpad0 = new byte[2];
        public float ChamberTime;
        private byte[] fieldpad1 = new byte[8];
        private byte[] fieldpad2 = new byte[16];
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference ReloadingEffect;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference ReloadingDamageEffect;
        [Moonfish.Tags.TagReferenceAttribute("null")]
        public Moonfish.Tags.TagReference ChamberingEffect;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference ChamberingDamageEffect;
        public MagazineObjects[] Magazines0 = new MagazineObjects[0];
        public override int SerializedSize
        {
            get
            {
                return 92;
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
            this.MagazinesFlags = ((Flags)(binaryReader.ReadInt32()));
            this.RoundsRecharged = binaryReader.ReadInt16();
            this.RoundsTotalInitial = binaryReader.ReadInt16();
            this.RoundsTotalMaximum = binaryReader.ReadInt16();
            this.RoundsLoadedMaximum = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.ReloadTime = binaryReader.ReadSingle();
            this.RoundsReloaded = binaryReader.ReadInt16();
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.ChamberTime = binaryReader.ReadSingle();
            this.fieldpad1 = binaryReader.ReadBytes(8);
            this.fieldpad2 = binaryReader.ReadBytes(16);
            this.ReloadingEffect = binaryReader.ReadTagReference();
            this.ReloadingDamageEffect = binaryReader.ReadTagReference();
            this.ChamberingEffect = binaryReader.ReadTagReference();
            this.ChamberingDamageEffect = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(12));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Magazines0 = base.ReadBlockArrayData<MagazineObjects>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Magazines0);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((int)(this.MagazinesFlags)));
            queueableBlamBinaryWriter.Write(this.RoundsRecharged);
            queueableBlamBinaryWriter.Write(this.RoundsTotalInitial);
            queueableBlamBinaryWriter.Write(this.RoundsTotalMaximum);
            queueableBlamBinaryWriter.Write(this.RoundsLoadedMaximum);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.ReloadTime);
            queueableBlamBinaryWriter.Write(this.RoundsReloaded);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.ChamberTime);
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.ReloadingEffect);
            queueableBlamBinaryWriter.Write(this.ReloadingDamageEffect);
            queueableBlamBinaryWriter.Write(this.ChamberingEffect);
            queueableBlamBinaryWriter.Write(this.ChamberingDamageEffect);
            queueableBlamBinaryWriter.WritePointer(this.Magazines0);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            WastesRoundsWhenReloaded = 1,
            EveryRoundMustBeChambered = 2,
        }
    }
}
