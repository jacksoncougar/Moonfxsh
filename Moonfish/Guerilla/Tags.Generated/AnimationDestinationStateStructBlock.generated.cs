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
    [TagBlockOriginalNameAttribute("animation_destination_state_struct_block")]
    public partial class AnimationDestinationStateStructBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.StringIdent StateName;
        public FrameEventLinkEnum FrameEventLink;
        private byte[] fieldpad = new byte[1];
        public byte IndexA;
        public byte IndexB;
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
            this.StateName = binaryReader.ReadStringIdent();
            this.FrameEventLink = ((FrameEventLinkEnum)(binaryReader.ReadByte()));
            this.fieldpad = binaryReader.ReadBytes(1);
            this.IndexA = binaryReader.ReadByte();
            this.IndexB = binaryReader.ReadByte();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.StateName);
            queueableBinaryWriter.Write(((byte)(this.FrameEventLink)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.IndexA);
            queueableBinaryWriter.Write(this.IndexB);
        }
        public enum FrameEventLinkEnum : byte
        {
            NOKEYFRAME = 0,
            KEYFRAMETYPEA = 1,
            KEYFRAMETYPEB = 2,
            KEYFRAMETYPEC = 3,
            KEYFRAMETYPED = 4,
        }
    }
}
