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
    
    public partial class PixelShaderConstantBlock : GuerillaBlock, IWriteQueueable
    {
        public ParameterTypeEnum ParameterType;
        public byte CombinerIndex;
        public byte RegisterIndex;
        public ComponentMaskEnum ComponentMask;
        private byte[] fieldpad = new byte[1];
        private byte[] fieldpad0 = new byte[1];
        public override int SerializedSize
        {
            get
            {
                return 6;
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
            this.ParameterType = ((ParameterTypeEnum)(binaryReader.ReadByte()));
            this.CombinerIndex = binaryReader.ReadByte();
            this.RegisterIndex = binaryReader.ReadByte();
            this.ComponentMask = ((ComponentMaskEnum)(binaryReader.ReadByte()));
            this.fieldpad = binaryReader.ReadBytes(1);
            this.fieldpad0 = binaryReader.ReadBytes(1);
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
            queueableBinaryWriter.Write(((byte)(this.ParameterType)));
            queueableBinaryWriter.Write(this.CombinerIndex);
            queueableBinaryWriter.Write(this.RegisterIndex);
            queueableBinaryWriter.Write(((byte)(this.ComponentMask)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
        }
        public enum ParameterTypeEnum : byte
        {
            Bitmap = 0,
            Value = 1,
            Color = 2,
            Switch = 3,
        }
        public enum ComponentMaskEnum : byte
        {
            Xvalue = 0,
            Yvalue = 1,
            Zvalue = 2,
            Wvalue = 3,
            Xyzrgbcolor = 4,
        }
    }
}