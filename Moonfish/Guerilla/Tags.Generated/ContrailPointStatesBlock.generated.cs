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
    
    public partial class ContrailPointStatesBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Model.Range Duration;
        public Moonfish.Model.Range TransitionDuration;
        [Moonfish.Tags.TagReferenceAttribute("pphy")]
        public Moonfish.Tags.TagReference Physics;
        public float Width;
        public OpenTK.Vector4 ColorLowerBound;
        public OpenTK.Vector4 ColorUpperBound;
        public ScaleFlags ContrailPointStatesScaleFlags;
        public override int SerializedSize
        {
            get
            {
                return 64;
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
            this.Duration = binaryReader.ReadRange();
            this.TransitionDuration = binaryReader.ReadRange();
            this.Physics = binaryReader.ReadTagReference();
            this.Width = binaryReader.ReadSingle();
            this.ColorLowerBound = binaryReader.ReadVector4();
            this.ColorUpperBound = binaryReader.ReadVector4();
            this.ContrailPointStatesScaleFlags = ((ScaleFlags)(binaryReader.ReadInt32()));
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
            queueableBlamBinaryWriter.Write(this.Duration);
            queueableBlamBinaryWriter.Write(this.TransitionDuration);
            queueableBlamBinaryWriter.Write(this.Physics);
            queueableBlamBinaryWriter.Write(this.Width);
            queueableBlamBinaryWriter.Write(this.ColorLowerBound);
            queueableBlamBinaryWriter.Write(this.ColorUpperBound);
            queueableBlamBinaryWriter.Write(((int)(this.ContrailPointStatesScaleFlags)));
        }
        [System.FlagsAttribute()]
        public enum ScaleFlags : int
        {
            None = 0,
            Duration = 1,
            DurationDelta = 2,
            TransitionDuration = 4,
            TransitionDurationDelta = 8,
            Width = 16,
            Color = 32,
        }
    }
}
