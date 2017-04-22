//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("shader_texture_state_address_state_block")]
    public partial class ShaderTextureStateAddressStateBlock : GuerillaBlock, IWriteQueueable
    {
        public UAddressModeEnum UAddressMode;
        public VAddressModeEnum VAddressMode;
        public WAddressModeEnum WAddressMode;
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.UAddressMode = ((UAddressModeEnum)(binaryReader.ReadInt16()));
            this.VAddressMode = ((VAddressModeEnum)(binaryReader.ReadInt16()));
            this.WAddressMode = ((WAddressModeEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.UAddressMode)));
            queueableBinaryWriter.Write(((short)(this.VAddressMode)));
            queueableBinaryWriter.Write(((short)(this.WAddressMode)));
            queueableBinaryWriter.Write(this.fieldpad);
        }
        public enum UAddressModeEnum : short
        {
            Wrap = 0,
            Mirror = 1,
            Clamp = 2,
            Border = 3,
            ClampToEdge = 4,
        }
        public enum VAddressModeEnum : short
        {
            Wrap = 0,
            Mirror = 1,
            Clamp = 2,
            Border = 3,
            ClampToEdge = 4,
        }
        public enum WAddressModeEnum : short
        {
            Wrap = 0,
            Mirror = 1,
            Clamp = 2,
            Border = 3,
            ClampToEdge = 4,
        }
    }
}
