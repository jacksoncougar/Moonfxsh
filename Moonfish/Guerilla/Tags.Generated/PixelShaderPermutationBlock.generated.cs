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
    [TagBlockOriginalNameAttribute("pixel_shader_permutation_block")]
    public partial class PixelShaderPermutationBlock : GuerillaBlock, IWriteDeferrable
    {
        public short EnumIndex;
        public Flags PixelShaderPermutationFlags;
        public TagBlockIndexStructBlock Constants = new TagBlockIndexStructBlock();
        public TagBlockIndexStructBlock Combiners = new TagBlockIndexStructBlock();
        private byte[] fieldskip = new byte[4];
        private byte[] fieldskip0 = new byte[4];
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.EnumIndex = binaryReader.ReadInt16();
            this.PixelShaderPermutationFlags = ((Flags)(binaryReader.ReadInt16()));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Constants.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Combiners.ReadFields(binaryReader)));
            this.fieldskip = binaryReader.ReadBytes(4);
            this.fieldskip0 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Constants.ReadInstances(binaryReader, pointerQueue);
            this.Combiners.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            this.Constants.DeferReferences(queueableBinaryWriter);
            this.Combiners.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.EnumIndex);
            queueableBinaryWriter.Write(((short)(this.PixelShaderPermutationFlags)));
            this.Constants.Write(queueableBinaryWriter);
            this.Combiners.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.fieldskip);
            queueableBinaryWriter.Write(this.fieldskip0);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            HasFinalCombiner = 1,
        }
    }
}
