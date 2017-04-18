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
    
    public partial class AnimationAimingScreenStructBlock : GuerillaBlock, IWriteQueueable
    {
        public float RightYawPerFrame;
        public float LeftYawPerFrame;
        public short RightFrameCount;
        public short LeftFrameCount;
        public float DownPitchPerFrame;
        public float UpPitchPerFrame;
        public short DownPitchFrameCount;
        public short UpPitchFrameCount;
        public override int SerializedSize
        {
            get
            {
                return 24;
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
            this.RightYawPerFrame = binaryReader.ReadSingle();
            this.LeftYawPerFrame = binaryReader.ReadSingle();
            this.RightFrameCount = binaryReader.ReadInt16();
            this.LeftFrameCount = binaryReader.ReadInt16();
            this.DownPitchPerFrame = binaryReader.ReadSingle();
            this.UpPitchPerFrame = binaryReader.ReadSingle();
            this.DownPitchFrameCount = binaryReader.ReadInt16();
            this.UpPitchFrameCount = binaryReader.ReadInt16();
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
            queueableBlamBinaryWriter.Write(this.RightYawPerFrame);
            queueableBlamBinaryWriter.Write(this.LeftYawPerFrame);
            queueableBlamBinaryWriter.Write(this.RightFrameCount);
            queueableBlamBinaryWriter.Write(this.LeftFrameCount);
            queueableBlamBinaryWriter.Write(this.DownPitchPerFrame);
            queueableBlamBinaryWriter.Write(this.UpPitchPerFrame);
            queueableBlamBinaryWriter.Write(this.DownPitchFrameCount);
            queueableBlamBinaryWriter.Write(this.UpPitchFrameCount);
        }
    }
}
