//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
    
    public partial class ListsBlock : GuerillaBlock, IWriteQueueable
    {
        private byte[] fieldskip = new byte[4];
        public short Size;
        public short Count;
        private byte[] fieldskip0 = new byte[4];
        private byte[] fieldskip1 = new byte[4];
        public int ChildShapesSize;
        public int ChildShapesCapacity;
        public ChildShapesStorageBlock[] ChildShapesStorage00 = new ChildShapesStorageBlock[4];
        public override int SerializedSize
        {
            get
            {
                return 56;
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
            this.fieldskip = binaryReader.ReadBytes(4);
            this.Size = binaryReader.ReadInt16();
            this.Count = binaryReader.ReadInt16();
            this.fieldskip0 = binaryReader.ReadBytes(4);
            this.fieldskip1 = binaryReader.ReadBytes(4);
            this.ChildShapesSize = binaryReader.ReadInt32();
            this.ChildShapesCapacity = binaryReader.ReadInt32();
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.ChildShapesStorage00[i] = new ChildShapesStorageBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ChildShapesStorage00[i].ReadFields(binaryReader)));
            }
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.ChildShapesStorage00[i].ReadInstances(binaryReader, pointerQueue);
            }
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.ChildShapesStorage00[i].QueueWrites(queueableBinaryWriter);
            }
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.Size);
            queueableBinaryWriter.Write(this.Count);
            queueableBinaryWriter.Write(this.fieldskip0);
            queueableBinaryWriter.Write(this.fieldskip1);
            queueableBinaryWriter.Write(this.ChildShapesSize);
            queueableBinaryWriter.Write(this.ChildShapesCapacity);
            int i;
            for (i = 0; (i < 4); i = (i + 1))
            {
                this.ChildShapesStorage00[i].Write_(queueableBinaryWriter);
            }
        }
        public class ChildShapesStorageBlock : GuerillaBlock, IWriteQueueable
        {
            public ShapeTypeEnum ShapeType;
            public Moonfish.Tags.ShortBlockIndex2 Shape;
            public int CollisionFilter;
            public override int SerializedSize
            {
                get
                {
                    return 8;
                }
            }
            public override int Alignment
            {
                get
                {
                    return 1;
                }
            }
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.ShapeType = ((ShapeTypeEnum)(binaryReader.ReadInt16()));
                this.Shape = binaryReader.ReadShortBlockIndex2();
                this.CollisionFilter = binaryReader.ReadInt32();
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
                queueableBinaryWriter.Write(((short)(this.ShapeType)));
                queueableBinaryWriter.Write(this.Shape);
                queueableBinaryWriter.Write(this.CollisionFilter);
            }
            public enum ShapeTypeEnum : short
            {
                Sphere = 0,
                Pill = 1,
                Box = 2,
                Triangle = 3,
                Polyhedron = 4,
                MultiSphere = 5,
                Unused0 = 6,
                Unused1 = 7,
                Unused2 = 8,
                Unused3 = 9,
                Unused4 = 10,
                Unused5 = 11,
                Unused6 = 12,
                Unused7 = 13,
                List = 14,
                Mopp = 15,
            }
        }
    }
}
