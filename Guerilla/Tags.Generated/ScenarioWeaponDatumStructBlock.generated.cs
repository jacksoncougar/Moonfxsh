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
    
    public partial class ScenarioWeaponDatumStructBlock : GuerillaBlock, IWriteQueueable
    {
        public short RoundsLeft;
        public short RoundsLoaded;
        public Flags ScenarioWeaponDatumStructFlags;
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
            this.RoundsLeft = binaryReader.ReadInt16();
            this.RoundsLoaded = binaryReader.ReadInt16();
            this.ScenarioWeaponDatumStructFlags = ((Flags)(binaryReader.ReadInt32()));
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
            queueableBinaryWriter.Write(this.RoundsLeft);
            queueableBinaryWriter.Write(this.RoundsLoaded);
            queueableBinaryWriter.Write(((int)(this.ScenarioWeaponDatumStructFlags)));
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            InitiallyAtRestDoesNotFall = 1,
            Obsolete = 2,
            DoesAccelerateMovesDueToExplosions = 4,
        }
    }
}
