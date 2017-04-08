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
    
    public partial class PlayerRepresentationBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("mode")]
        public Moonfish.Tags.TagReference FirstPersonHands;
        [Moonfish.Tags.TagReferenceAttribute("mode")]
        public Moonfish.Tags.TagReference FirstPersonBody;
        private byte[] fieldpad = new byte[40];
        private byte[] fieldpad0 = new byte[120];
        [Moonfish.Tags.TagReferenceAttribute("unit")]
        public Moonfish.Tags.TagReference ThirdPersonUnit;
        public Moonfish.Tags.StringIdent ThirdPersonVariant;
        public override int SerializedSize
        {
            get
            {
                return 188;
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
            this.FirstPersonHands = binaryReader.ReadTagReference();
            this.FirstPersonBody = binaryReader.ReadTagReference();
            this.fieldpad = binaryReader.ReadBytes(40);
            this.fieldpad0 = binaryReader.ReadBytes(120);
            this.ThirdPersonUnit = binaryReader.ReadTagReference();
            this.ThirdPersonVariant = binaryReader.ReadStringIdent();
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
            queueableBinaryWriter.Write(this.FirstPersonHands);
            queueableBinaryWriter.Write(this.FirstPersonBody);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.ThirdPersonUnit);
            queueableBinaryWriter.Write(this.ThirdPersonVariant);
        }
    }
}
