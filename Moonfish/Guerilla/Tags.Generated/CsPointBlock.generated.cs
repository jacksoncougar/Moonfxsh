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
    
    public partial class CsPointBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.String32 Name;
        public OpenTK.Vector3 Position;
        public short ReferenceFrame;
        private byte[] fieldpad = new byte[2];
        public int SurfaceIndex;
        public OpenTK.Vector2 FacingDirection;
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
            this.Name = binaryReader.ReadString32();
            this.Position = binaryReader.ReadVector3();
            this.ReferenceFrame = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.SurfaceIndex = binaryReader.ReadInt32();
            this.FacingDirection = binaryReader.ReadVector2();
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
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.Position);
            queueableBinaryWriter.Write(this.ReferenceFrame);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.SurfaceIndex);
            queueableBinaryWriter.Write(this.FacingDirection);
        }
    }
}
