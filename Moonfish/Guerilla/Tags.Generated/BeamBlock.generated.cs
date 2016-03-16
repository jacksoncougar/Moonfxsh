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
    
    public partial class BeamBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("shad")]
        public Moonfish.Tags.TagReference Shader;
        public Moonfish.Tags.ShortBlockIndex1 Location;
        private byte[] fieldpad = new byte[2];
        public ColorFunctionStructBlock Color = new ColorFunctionStructBlock();
        public ScalarFunctionStructBlock Alpha = new ScalarFunctionStructBlock();
        public ScalarFunctionStructBlock Width = new ScalarFunctionStructBlock();
        public ScalarFunctionStructBlock Length = new ScalarFunctionStructBlock();
        public ScalarFunctionStructBlock Yaw = new ScalarFunctionStructBlock();
        public ScalarFunctionStructBlock Pitch = new ScalarFunctionStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 60;
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
            this.Shader = binaryReader.ReadTagReference();
            this.Location = binaryReader.ReadShortBlockIndex1();
            this.fieldpad = binaryReader.ReadBytes(2);
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Color.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Alpha.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Width.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Length.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Yaw.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Pitch.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Color.ReadInstances(binaryReader, pointerQueue);
            this.Alpha.ReadInstances(binaryReader, pointerQueue);
            this.Width.ReadInstances(binaryReader, pointerQueue);
            this.Length.ReadInstances(binaryReader, pointerQueue);
            this.Yaw.ReadInstances(binaryReader, pointerQueue);
            this.Pitch.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            this.Color.QueueWrites(queueableBinaryWriter);
            this.Alpha.QueueWrites(queueableBinaryWriter);
            this.Width.QueueWrites(queueableBinaryWriter);
            this.Length.QueueWrites(queueableBinaryWriter);
            this.Yaw.QueueWrites(queueableBinaryWriter);
            this.Pitch.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Shader);
            queueableBinaryWriter.Write(this.Location);
            queueableBinaryWriter.Write(this.fieldpad);
            this.Color.Write_(queueableBinaryWriter);
            this.Alpha.Write_(queueableBinaryWriter);
            this.Width.Write_(queueableBinaryWriter);
            this.Length.Write_(queueableBinaryWriter);
            this.Yaw.Write_(queueableBinaryWriter);
            this.Pitch.Write_(queueableBinaryWriter);
        }
    }
}