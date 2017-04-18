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
    
    public partial class ShaderTemplateParameterBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public byte[] Explanation;
        public TypeEnum Type;
        public Flags ShaderTemplateParameterFlags;
        [Moonfish.Tags.TagReferenceAttribute("bitm")]
        public Moonfish.Tags.TagReference DefaultBitmap;
        public float DefaultConstValue;
        public Moonfish.Tags.ColourR8G8B8 DefaultConstColor;
        public BitmapTypeEnum BitmapType;
        private byte[] fieldpad = new byte[2];
        public BitmapAnimationFlags ShaderTemplateParameterBitmapAnimationFlags;
        private byte[] fieldpad0 = new byte[2];
        public float BitmapScale;
        public override int SerializedSize
        {
            get
            {
                return 52;
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
            this.Name = binaryReader.ReadStringIdent();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(1));
            this.Type = ((TypeEnum)(binaryReader.ReadInt16()));
            this.ShaderTemplateParameterFlags = ((Flags)(binaryReader.ReadInt16()));
            this.DefaultBitmap = binaryReader.ReadTagReference();
            this.DefaultConstValue = binaryReader.ReadSingle();
            this.DefaultConstColor = binaryReader.ReadColorR8G8B8();
            this.BitmapType = ((BitmapTypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.ShaderTemplateParameterBitmapAnimationFlags = ((BitmapAnimationFlags)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.BitmapScale = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Explanation = base.ReadDataByteArray(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Explanation);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.Name);
            queueableBlamBinaryWriter.WritePointer(this.Explanation);
            queueableBlamBinaryWriter.Write(((short)(this.Type)));
            queueableBlamBinaryWriter.Write(((short)(this.ShaderTemplateParameterFlags)));
            queueableBlamBinaryWriter.Write(this.DefaultBitmap);
            queueableBlamBinaryWriter.Write(this.DefaultConstValue);
            queueableBlamBinaryWriter.Write(this.DefaultConstColor);
            queueableBlamBinaryWriter.Write(((short)(this.BitmapType)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(((short)(this.ShaderTemplateParameterBitmapAnimationFlags)));
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.BitmapScale);
        }
        public enum TypeEnum : short
        {
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Animated = 1,
            HideBitmapReference = 2,
        }
        public enum BitmapTypeEnum : short
        {
            _2D = 0,
            _3D = 1,
            CubeMap = 2,
        }
        [System.FlagsAttribute()]
        public enum BitmapAnimationFlags : short
        {
            None = 0,
            ScaleUniform = 1,
            Scale = 2,
            Translation = 4,
            Rotation = 8,
            Index = 16,
        }
    }
}
