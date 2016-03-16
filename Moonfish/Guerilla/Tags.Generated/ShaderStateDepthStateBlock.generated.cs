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
    
    public partial class ShaderStateDepthStateBlock : GuerillaBlock, IWriteQueueable
    {
        public ModeEnum Mode;
        public DepthCompareFunctionEnum DepthCompareFunction;
        public Flags ShaderStateDepthStateFlags;
        private byte[] fieldpad = new byte[2];
        public float DepthBiasSlopeScale;
        public float DepthBias;
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
            this.Mode = ((ModeEnum)(binaryReader.ReadInt16()));
            this.DepthCompareFunction = ((DepthCompareFunctionEnum)(binaryReader.ReadInt16()));
            this.ShaderStateDepthStateFlags = ((Flags)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.DepthBiasSlopeScale = binaryReader.ReadSingle();
            this.DepthBias = binaryReader.ReadSingle();
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
            queueableBinaryWriter.Write(((short)(this.Mode)));
            queueableBinaryWriter.Write(((short)(this.DepthCompareFunction)));
            queueableBinaryWriter.Write(((short)(this.ShaderStateDepthStateFlags)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.DepthBiasSlopeScale);
            queueableBinaryWriter.Write(this.DepthBias);
        }
        public enum ModeEnum : short
        {
            UseZ = 0,
            UseW = 1,
        }
        public enum DepthCompareFunctionEnum : short
        {
            Never = 0,
            Less = 1,
            Equal = 2,
            LessOrEqual = 3,
            Greater = 4,
            NotEqual = 5,
            GreaterOrEqual = 6,
            Always = 7,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            DepthWrite = 1,
            OffsetPoints = 2,
            OffsetLines = 4,
            OffsetTriangles = 8,
            ClipControlDontCullPrimitive = 16,
            ClipControlClamp = 32,
            ClipControlIgnoreWSign = 64,
        }
    }
}