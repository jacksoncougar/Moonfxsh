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
    
    public partial class ObjectAnimationBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Label;
        public AnimationIndexStructBlock Animation = new AnimationIndexStructBlock();
        private byte[] fieldpad = new byte[2];
        public FunctionControlsEnum FunctionControls;
        public Moonfish.Tags.StringIdent Function;
        private byte[] fieldpad0 = new byte[4];
        public override int SerializedSize
        {
            get
            {
                return 20;
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
            this.Label = binaryReader.ReadStringIdent();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Animation.ReadFields(binaryReader)));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.FunctionControls = ((FunctionControlsEnum)(binaryReader.ReadInt16()));
            this.Function = binaryReader.ReadStringIdent();
            this.fieldpad0 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Animation.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.Animation.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Label);
            this.Animation.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((short)(this.FunctionControls)));
            queueableBinaryWriter.Write(this.Function);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
        public enum FunctionControlsEnum : short
        {
            Frame = 0,
            Scale = 1,
        }
    }
}
