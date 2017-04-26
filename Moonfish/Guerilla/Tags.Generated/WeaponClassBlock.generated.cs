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
    [TagBlockOriginalNameAttribute("weapon_class_block")]
    public partial class WeaponClassBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.StringIdent Label;
        public WeaponTypeBlock[] WeaponTypeAABBCC = new WeaponTypeBlock[0];
        public AnimationIkBlock[] WeaponIkAABBCC = new AnimationIkBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 20;
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
            this.Label = binaryReader.ReadStringIdent();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(52));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.WeaponTypeAABBCC = base.ReadBlockArrayData<WeaponTypeBlock>(binaryReader, pointerQueue.Dequeue());
            this.WeaponIkAABBCC = base.ReadBlockArrayData<AnimationIkBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
            queueableBinaryWriter.Defer(this.WeaponTypeAABBCC);
            queueableBinaryWriter.Defer(this.WeaponIkAABBCC);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Label);
            queueableBinaryWriter.WritePointer(this.WeaponTypeAABBCC);
            queueableBinaryWriter.WritePointer(this.WeaponIkAABBCC);
        }
    }
}
