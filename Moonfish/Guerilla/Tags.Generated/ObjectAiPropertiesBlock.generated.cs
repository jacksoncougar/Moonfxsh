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
    
    public partial class ObjectAiPropertiesBlock : GuerillaBlock, IWriteQueueable
    {
        public AiFlags ObjectAiPropertiesAiFlags;
        public Moonfish.Tags.StringIdent AiTypeName;
        private byte[] fieldpad = new byte[4];
        public AiSizeEnum AiSize;
        public LeapJumpSpeedEnum LeapJumpSpeed;
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
            this.ObjectAiPropertiesAiFlags = ((AiFlags)(binaryReader.ReadInt32()));
            this.AiTypeName = binaryReader.ReadStringIdent();
            this.fieldpad = binaryReader.ReadBytes(4);
            this.AiSize = ((AiSizeEnum)(binaryReader.ReadInt16()));
            this.LeapJumpSpeed = ((LeapJumpSpeedEnum)(binaryReader.ReadInt16()));
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
            queueableBlamBinaryWriter.Write(((int)(this.ObjectAiPropertiesAiFlags)));
            queueableBlamBinaryWriter.Write(this.AiTypeName);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(((short)(this.AiSize)));
            queueableBlamBinaryWriter.Write(((short)(this.LeapJumpSpeed)));
        }
        [System.FlagsAttribute()]
        public enum AiFlags : int
        {
            None = 0,
            DetroyableCover = 1,
            PathfindingIgnoreWhenDead = 2,
            DynamicCover = 4,
        }
        public enum AiSizeEnum : short
        {
            Default = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            Immobile = 6,
        }
        public enum LeapJumpSpeedEnum : short
        {
            NONE = 0,
            Down = 1,
            Step = 2,
            Crouch = 3,
            Stand = 4,
            Storey = 5,
            Tower = 6,
            Infinite = 7,
        }
    }
}
