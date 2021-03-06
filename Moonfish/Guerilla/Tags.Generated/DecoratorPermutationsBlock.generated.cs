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
    
    public partial class DecoratorPermutationsBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public Moonfish.Tags.ByteBlockIndex1 Shader;
        private byte[] fieldpad = new byte[3];
        public Flags DecoratorPermutationsFlags;
        public FadeDistanceEnum FadeDistance;
        public byte Index;
        public byte DistributionWeight;
        public Moonfish.Model.Range Scale;
        public Moonfish.Tags.ColourR1G1B1 Tint1;
        private byte[] fieldpad0 = new byte[1];
        public Moonfish.Tags.ColourR1G1B1 Tint2;
        private byte[] fieldpad1 = new byte[1];
        public float BaseMapTintPercentage;
        public float LightmapTintPercentage;
        public float WindScale;
        public override int SerializedSize
        {
            get
            {
                return 40;
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
            this.Name = binaryReader.ReadStringID();
            this.Shader = binaryReader.ReadByteBlockIndex1();
            this.fieldpad = binaryReader.ReadBytes(3);
            this.DecoratorPermutationsFlags = ((Flags)(binaryReader.ReadByte()));
            this.FadeDistance = ((FadeDistanceEnum)(binaryReader.ReadByte()));
            this.Index = binaryReader.ReadByte();
            this.DistributionWeight = binaryReader.ReadByte();
            this.Scale = binaryReader.ReadRange();
            this.Tint1 = binaryReader.ReadColourR1G1B1();
            this.fieldpad0 = binaryReader.ReadBytes(1);
            this.Tint2 = binaryReader.ReadColourR1G1B1();
            this.fieldpad1 = binaryReader.ReadBytes(1);
            this.BaseMapTintPercentage = binaryReader.ReadSingle();
            this.LightmapTintPercentage = binaryReader.ReadSingle();
            this.WindScale = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(this.Shader);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(((byte)(this.DecoratorPermutationsFlags)));
            queueableBinaryWriter.Write(((byte)(this.FadeDistance)));
            queueableBinaryWriter.Write(this.Index);
            queueableBinaryWriter.Write(this.DistributionWeight);
            queueableBinaryWriter.Write(this.Scale);
            queueableBinaryWriter.Write(this.Tint1);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.Tint2);
            queueableBinaryWriter.Write(this.fieldpad1);
            queueableBinaryWriter.Write(this.BaseMapTintPercentage);
            queueableBinaryWriter.Write(this.LightmapTintPercentage);
            queueableBinaryWriter.Write(this.WindScale);
        }
        [System.FlagsAttribute()]
        public enum Flags : byte
        {
            None = 0,
            AlignToNormal = 1,
            OnlyOnGround = 2,
            Upright = 4,
        }
        public enum FadeDistanceEnum : byte
        {
            Close = 0,
            Medium = 1,
            Far = 2,
        }
    }
}
