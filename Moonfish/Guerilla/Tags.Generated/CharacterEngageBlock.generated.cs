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
    
    public partial class CharacterEngageBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags CharacterEngageFlags;
        public float CrouchDangerThreshold;
        public float StandDangerThreshold;
        public float FightDangerMoveThreshold;
        public override int SerializedSize
        {
            get
            {
                return 16;
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
            this.CharacterEngageFlags = ((Flags)(binaryReader.ReadInt32()));
            this.CrouchDangerThreshold = binaryReader.ReadSingle();
            this.StandDangerThreshold = binaryReader.ReadSingle();
            this.FightDangerMoveThreshold = binaryReader.ReadSingle();
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
            queueableBlamBinaryWriter.Write(((int)(this.CharacterEngageFlags)));
            queueableBlamBinaryWriter.Write(this.CrouchDangerThreshold);
            queueableBlamBinaryWriter.Write(this.StandDangerThreshold);
            queueableBlamBinaryWriter.Write(this.FightDangerMoveThreshold);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            EngagePerch = 1,
            FightConstantMovement = 2,
            FlightFightConstantMovement = 4,
        }
    }
}
