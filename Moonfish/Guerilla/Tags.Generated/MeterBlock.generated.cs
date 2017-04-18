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
    
    [TagClassAttribute("metr")]
    public partial class MeterBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags MeterFlags;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference StencilBitmaps;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference SourceBitmap;
        public short StencilSequenceIndex;
        public short SourceSequenceIndex;
        private byte[] fieldpad = new byte[16];
        private byte[] fieldpad0 = new byte[4];
        public InterpolateColorsEnum InterpolateColors;
        public AnchorColorsEnum AnchorColors;
        private byte[] fieldpad1 = new byte[8];
        public OpenTK.Vector4 EmptyColor;
        public OpenTK.Vector4 FullColor;
        private byte[] fieldpad2 = new byte[20];
        public float UnmaskDistance;
        public float MaskDistance;
        private byte[] fieldpad3 = new byte[20];
        public byte[] EncodedStencil;
        public override int SerializedSize
        {
            get
            {
                return 144;
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
            this.MeterFlags = ((Flags)(binaryReader.ReadInt32()));
            this.StencilBitmaps = binaryReader.ReadTagReference();
            this.SourceBitmap = binaryReader.ReadTagReference();
            this.StencilSequenceIndex = binaryReader.ReadInt16();
            this.SourceSequenceIndex = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(16);
            this.fieldpad0 = binaryReader.ReadBytes(4);
            this.InterpolateColors = ((InterpolateColorsEnum)(binaryReader.ReadInt16()));
            this.AnchorColors = ((AnchorColorsEnum)(binaryReader.ReadInt16()));
            this.fieldpad1 = binaryReader.ReadBytes(8);
            this.EmptyColor = binaryReader.ReadVector4();
            this.FullColor = binaryReader.ReadVector4();
            this.fieldpad2 = binaryReader.ReadBytes(20);
            this.UnmaskDistance = binaryReader.ReadSingle();
            this.MaskDistance = binaryReader.ReadSingle();
            this.fieldpad3 = binaryReader.ReadBytes(20);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.EncodedStencil = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.EncodedStencil);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((int)(this.MeterFlags)));
            queueableBlamBinaryWriter.Write(this.StencilBitmaps);
            queueableBlamBinaryWriter.Write(this.SourceBitmap);
            queueableBlamBinaryWriter.Write(this.StencilSequenceIndex);
            queueableBlamBinaryWriter.Write(this.SourceSequenceIndex);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(((short)(this.InterpolateColors)));
            queueableBlamBinaryWriter.Write(((short)(this.AnchorColors)));
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(this.EmptyColor);
            queueableBlamBinaryWriter.Write(this.FullColor);
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.UnmaskDistance);
            queueableBlamBinaryWriter.Write(this.MaskDistance);
            queueableBlamBinaryWriter.Write(this.fieldpad3);
            queueableBlamBinaryWriter.WritePointer(this.EncodedStencil);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
        }
        public enum InterpolateColorsEnum : short
        {
            Linearly = 0,
            FasterNearEmpty = 1,
            FasterNearFull = 2,
            ThroughRandomNoise = 3,
        }
        public enum AnchorColorsEnum : short
        {
            AtBothEnds = 0,
            AtEmpty = 1,
            AtFull = 2,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Metr = ((TagClass)("metr"));
    }
}
