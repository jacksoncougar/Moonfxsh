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
    
    public partial class MultiSpheresBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public Moonfish.Tags.ShortBlockIndex1 Material;
        public Flags MultiSpheresFlags;
        public float RelativeMassScale;
        public float Friction;
        public float Restitution;
        public float Volume;
        public float Mass;
        private byte[] fieldskip = new byte[2];
        public Moonfish.Tags.ShortBlockIndex1 Phantom;
        private byte[] fieldskip0 = new byte[4];
        public short Size;
        public short Count;
        private byte[] fieldskip1 = new byte[4];
        public int NumSpheres;
        public FourVectorsStorageBlock[] FourVectorsStorage00 = new FourVectorsStorageBlock[8];
        public override int SerializedSize
        {
            get
            {
                return 176;
            }
        }
        public override int Alignment
        {
            get
            {
                return 16;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.Name = binaryReader.ReadStringID();
            this.Material = binaryReader.ReadShortBlockIndex1();
            this.MultiSpheresFlags = ((Flags)(binaryReader.ReadInt16()));
            this.RelativeMassScale = binaryReader.ReadSingle();
            this.Friction = binaryReader.ReadSingle();
            this.Restitution = binaryReader.ReadSingle();
            this.Volume = binaryReader.ReadSingle();
            this.Mass = binaryReader.ReadSingle();
            this.fieldskip = binaryReader.ReadBytes(2);
            this.Phantom = binaryReader.ReadShortBlockIndex1();
            this.fieldskip0 = binaryReader.ReadBytes(4);
            this.Size = binaryReader.ReadInt16();
            this.Count = binaryReader.ReadInt16();
            this.fieldskip1 = binaryReader.ReadBytes(4);
            this.NumSpheres = binaryReader.ReadInt32();
            int i;
            for (i = 0; (i < 8); i = (i + 1))
            {
                this.FourVectorsStorage00[i] = new FourVectorsStorageBlock();
                pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.FourVectorsStorage00[i].ReadFields(binaryReader)));
            }
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            int i;
            for (i = 0; (i < 8); i = (i + 1))
            {
                this.FourVectorsStorage00[i].ReadInstances(binaryReader, pointerQueue);
            }
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            int i;
            for (i = 0; (i < 8); i = (i + 1))
            {
                this.FourVectorsStorage00[i].QueueWrites(queueableBinaryWriter);
            }
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.Material);
            queueableBinaryWriter.Write(((short)(this.MultiSpheresFlags)));
            queueableBinaryWriter.Write(this.RelativeMassScale);
            queueableBinaryWriter.Write(this.Friction);
            queueableBinaryWriter.Write(this.Restitution);
            queueableBinaryWriter.Write(this.Volume);
            queueableBinaryWriter.Write(this.Mass);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.Phantom);
            queueableBinaryWriter.Write(this.fieldskip0);
            queueableBinaryWriter.Write(this.Size);
            queueableBinaryWriter.Write(this.Count);
            queueableBinaryWriter.Write(this.fieldskip1);
            queueableBinaryWriter.Write(this.NumSpheres);
            int i;
            for (i = 0; (i < 8); i = (i + 1))
            {
                this.FourVectorsStorage00[i].Write_(queueableBinaryWriter);
            }
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Unused = 1,
        }
        public class FourVectorsStorageBlock : GuerillaBlock, IWriteQueueable
        {
            public OpenTK.Vector3 Sphere;
            private byte[] fieldskip = new byte[4];
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
                    return 1;
                }
            }
            public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
            {
                System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
                this.Sphere = binaryReader.ReadVector3();
                this.fieldskip = binaryReader.ReadBytes(4);
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
                queueableBinaryWriter.Write(this.Sphere);
                queueableBinaryWriter.Write(this.fieldskip);
            }
        }
    }
}