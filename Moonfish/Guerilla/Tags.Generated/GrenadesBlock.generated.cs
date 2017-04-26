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
    [TagBlockOriginalNameAttribute("grenades_block")]
    public partial class GrenadesBlock : GuerillaBlock, IWriteDeferrable
    {
        public short MaximumCount;
        private byte[] fieldpad = new byte[2];
        [Moonfish.Tags.TagReferenceAttribute("effe")]
        public Moonfish.Tags.TagReference ThrowingEffect;
        private byte[] fieldpad0 = new byte[16];
        [Moonfish.Tags.TagReferenceAttribute("eqip")]
        public Moonfish.Tags.TagReference Equipment;
        [Moonfish.Tags.TagReferenceAttribute("proj")]
        public Moonfish.Tags.TagReference Projectile;
        public override int SerializedSize
        {
            get
            {
                return 44;
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
            this.MaximumCount = binaryReader.ReadInt16();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.ThrowingEffect = binaryReader.ReadTagReference();
            this.fieldpad0 = binaryReader.ReadBytes(16);
            this.Equipment = binaryReader.ReadTagReference();
            this.Projectile = binaryReader.ReadTagReference();
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
            queueableBinaryWriter.Write(this.MaximumCount);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.ThrowingEffect);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.Equipment);
            queueableBinaryWriter.Write(this.Projectile);
        }
    }
}
