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
    
    public partial class LimitedHingeConstraintsBlock : GuerillaBlock, IWriteQueueable
    {
        public ConstraintBodiesStructBlock ConstraintBodies = new ConstraintBodiesStructBlock();
        private byte[] fieldpad = new byte[4];
        public float LimitFriction;
        public float LimitMinAngle;
        public float LimitMaxAngle;
        public override int SerializedSize
        {
            get
            {
                return 132;
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
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ConstraintBodies.ReadFields(binaryReader)));
            this.fieldpad = binaryReader.ReadBytes(4);
            this.LimitFriction = binaryReader.ReadSingle();
            this.LimitMinAngle = binaryReader.ReadSingle();
            this.LimitMaxAngle = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ConstraintBodies.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.ConstraintBodies.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            this.ConstraintBodies.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.LimitFriction);
            queueableBinaryWriter.Write(this.LimitMinAngle);
            queueableBinaryWriter.Write(this.LimitMaxAngle);
        }
    }
}
