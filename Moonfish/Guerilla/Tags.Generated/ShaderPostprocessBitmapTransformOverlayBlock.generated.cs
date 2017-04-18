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
    
    public partial class ShaderPostprocessBitmapTransformOverlayBlock : GuerillaBlock, IWriteQueueable
    {
        public byte ParameterIndex;
        public byte TransformIndex;
        public byte AnimationPropertyType;
        public Moonfish.Tags.StringIdent InputName;
        public Moonfish.Tags.StringIdent RangeName;
        public float TimePeriodInSeconds;
        public ScalarFunctionStructBlock Function = new ScalarFunctionStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 23;
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
            this.ParameterIndex = binaryReader.ReadByte();
            this.TransformIndex = binaryReader.ReadByte();
            this.AnimationPropertyType = binaryReader.ReadByte();
            this.InputName = binaryReader.ReadStringIdent();
            this.RangeName = binaryReader.ReadStringIdent();
            this.TimePeriodInSeconds = binaryReader.ReadSingle();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Function.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Function.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.Function.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.ParameterIndex);
            queueableBlamBinaryWriter.Write(this.TransformIndex);
            queueableBlamBinaryWriter.Write(this.AnimationPropertyType);
            queueableBlamBinaryWriter.Write(this.InputName);
            queueableBlamBinaryWriter.Write(this.RangeName);
            queueableBlamBinaryWriter.Write(this.TimePeriodInSeconds);
            this.Function.Write_(queueableBlamBinaryWriter);
        }
    }
}
