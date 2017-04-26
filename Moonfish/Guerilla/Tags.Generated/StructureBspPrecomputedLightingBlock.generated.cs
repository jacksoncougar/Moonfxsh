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
    [TagBlockOriginalNameAttribute("structure_bsp_precomputed_lighting_block")]
    public partial class StructureBspPrecomputedLightingBlock : GuerillaBlock, IWriteDeferrable
    {
        public int Index;
        public LightTypeEnum LightType;
        public byte AttachmentIndex;
        public byte ObjectType;
        public VisibilityStructBlock Visibility = new VisibilityStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 48;
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
            this.Index = binaryReader.ReadInt32();
            this.LightType = ((LightTypeEnum)(binaryReader.ReadInt16()));
            this.AttachmentIndex = binaryReader.ReadByte();
            this.ObjectType = binaryReader.ReadByte();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Visibility.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Visibility.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            this.Visibility.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Index);
            queueableBinaryWriter.Write(((short)(this.LightType)));
            queueableBinaryWriter.Write(this.AttachmentIndex);
            queueableBinaryWriter.Write(this.ObjectType);
            this.Visibility.Write(queueableBinaryWriter);
        }
        public enum LightTypeEnum : short
        {
            FreeStanding = 0,
            AttachedToEditorObject = 1,
            AttachedToStructureObject = 2,
        }
    }
}
