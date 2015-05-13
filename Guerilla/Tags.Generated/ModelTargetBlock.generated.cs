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
    
    public partial class ModelTargetBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent MarkerName;
        public float Size;
        public float ConeAngle;
        public Moonfish.Tags.ShortBlockIndex2 DamageSection;
        public Moonfish.Tags.ShortBlockIndex1 Variant;
        public float TargetingRelevance;
        public ModelTargetLockOnDataStructBlock LockonData = new ModelTargetLockOnDataStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 28;
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
            this.MarkerName = binaryReader.ReadStringID();
            this.Size = binaryReader.ReadSingle();
            this.ConeAngle = binaryReader.ReadSingle();
            this.DamageSection = binaryReader.ReadShortBlockIndex2();
            this.Variant = binaryReader.ReadShortBlockIndex1();
            this.TargetingRelevance = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.LockonData.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.LockonData.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.LockonData.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.MarkerName);
            queueableBinaryWriter.Write(this.Size);
            queueableBinaryWriter.Write(this.ConeAngle);
            queueableBinaryWriter.Write(this.DamageSection);
            queueableBinaryWriter.Write(this.Variant);
            queueableBinaryWriter.Write(this.TargetingRelevance);
            this.LockonData.Write_(queueableBinaryWriter);
        }
    }
}
