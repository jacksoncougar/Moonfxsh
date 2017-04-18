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
    
    public partial class DecoratorProjectedDecalBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.ByteBlockIndex1 DecoratorSet;
        public byte DecoratorClass;
        public byte DecoratorPermutation;
        public byte SpriteIndex;
        public OpenTK.Vector3 Position;
        public OpenTK.Vector3 Left;
        public OpenTK.Vector3 Up;
        public OpenTK.Vector3 Extents;
        public OpenTK.Vector3 PreviousPosition;
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
            this.DecoratorSet = binaryReader.ReadByteBlockIndex1();
            this.DecoratorClass = binaryReader.ReadByte();
            this.DecoratorPermutation = binaryReader.ReadByte();
            this.SpriteIndex = binaryReader.ReadByte();
            this.Position = binaryReader.ReadVector3();
            this.Left = binaryReader.ReadVector3();
            this.Up = binaryReader.ReadVector3();
            this.Extents = binaryReader.ReadVector3();
            this.PreviousPosition = binaryReader.ReadVector3();
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
            queueableBlamBinaryWriter.Write(this.DecoratorSet);
            queueableBlamBinaryWriter.Write(this.DecoratorClass);
            queueableBlamBinaryWriter.Write(this.DecoratorPermutation);
            queueableBlamBinaryWriter.Write(this.SpriteIndex);
            queueableBlamBinaryWriter.Write(this.Position);
            queueableBlamBinaryWriter.Write(this.Left);
            queueableBlamBinaryWriter.Write(this.Up);
            queueableBlamBinaryWriter.Write(this.Extents);
            queueableBlamBinaryWriter.Write(this.PreviousPosition);
        }
    }
}
