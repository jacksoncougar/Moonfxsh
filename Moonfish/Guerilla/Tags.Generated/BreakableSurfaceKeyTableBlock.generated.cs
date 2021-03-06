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
    
    public partial class BreakableSurfaceKeyTableBlock : GuerillaBlock, IWriteQueueable
    {
        public short InstancedGeometryIndex;
        public short BreakableSurfaceIndex;
        public int SeedSurfaceIndex;
        public float x0;
        public float x1;
        public float y0;
        public float y1;
        public float z0;
        public float z1;
        public override int SerializedSize
        {
            get
            {
                return 32;
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
            this.InstancedGeometryIndex = binaryReader.ReadInt16();
            this.BreakableSurfaceIndex = binaryReader.ReadInt16();
            this.SeedSurfaceIndex = binaryReader.ReadInt32();
            this.x0 = binaryReader.ReadSingle();
            this.x1 = binaryReader.ReadSingle();
            this.y0 = binaryReader.ReadSingle();
            this.y1 = binaryReader.ReadSingle();
            this.z0 = binaryReader.ReadSingle();
            this.z1 = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(this.InstancedGeometryIndex);
            queueableBinaryWriter.Write(this.BreakableSurfaceIndex);
            queueableBinaryWriter.Write(this.SeedSurfaceIndex);
            queueableBinaryWriter.Write(this.x0);
            queueableBinaryWriter.Write(this.x1);
            queueableBinaryWriter.Write(this.y0);
            queueableBinaryWriter.Write(this.y1);
            queueableBinaryWriter.Write(this.z0);
            queueableBinaryWriter.Write(this.z1);
        }
    }
}
