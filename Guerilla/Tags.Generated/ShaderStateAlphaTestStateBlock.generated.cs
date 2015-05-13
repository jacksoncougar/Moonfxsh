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
    
    public partial class ShaderStateAlphaTestStateBlock : GuerillaBlock, IWriteQueueable
    {
        public Flags ShaderStateAlphaTestStateFlags;
        public AlphaCompareFunctionEnum AlphaCompareFunction;
        public short AlphatestRef;
        private byte[] fieldpad = new byte[2];
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
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.ShaderStateAlphaTestStateFlags = ((Flags)(binaryReader.ReadInt16()));
            this.AlphaCompareFunction = ((AlphaCompareFunctionEnum)(binaryReader.ReadInt16()));
            this.AlphatestRef = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
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
            queueableBinaryWriter.Write(((short)(this.ShaderStateAlphaTestStateFlags)));
            queueableBinaryWriter.Write(((short)(this.AlphaCompareFunction)));
            queueableBinaryWriter.Write(this.AlphatestRef);
            queueableBinaryWriter.Write(this.fieldpad);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            AlphatestEnabled = 1,
            SamplealphaToCoverage = 2,
            SamplealphaToOne = 4,
        }
        public enum AlphaCompareFunctionEnum : short
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
    }
}
