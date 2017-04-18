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
    
    public partial class StructureBspFogPlaneBlock : GuerillaBlock, IWriteQueueable
    {
        public short ScenarioPlanarFogIndex;
        private byte[] fieldpad = new byte[2];
        public OpenTK.Vector4 Plane;
        public Flags StructureBspFogPlaneFlags;
        public short Priority;
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
            this.ScenarioPlanarFogIndex = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.Plane = binaryReader.ReadVector4();
            this.StructureBspFogPlaneFlags = ((Flags)(binaryReader.ReadInt16()));
            this.Priority = binaryReader.ReadInt16();
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
            queueableBlamBinaryWriter.Write(this.ScenarioPlanarFogIndex);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.Plane);
            queueableBlamBinaryWriter.Write(((short)(this.StructureBspFogPlaneFlags)));
            queueableBlamBinaryWriter.Write(this.Priority);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            ExtendInfinitelyWhileVisible = 1,
            DoNotFloodfill = 2,
            AggressiveFloodfill = 4,
        }
    }
}
