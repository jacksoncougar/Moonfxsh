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
    
    public partial class BipedLockOnDataStructBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags BipedLockOnDataStructFlags;
        public float LockOnDistance;
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
            this.BipedLockOnDataStructFlags = ((Flags)(binaryReader.ReadInt32()));
            this.LockOnDistance = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(((int)(this.BipedLockOnDataStructFlags)));
            queueableBinaryWriter.Write(this.LockOnDistance);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            LockedByHumanTargeting = 1,
            LockedByPlasmaTargeting = 2,
            AlwaysLockedByPlasmaTargeting = 4,
        }
    }
}