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
    [TagBlockOriginalNameAttribute("object_change_color_initial_permutation")]
    public partial class ObjectChangeColorInitialPermutation : GuerillaBlock, IWriteDeferrable
    {
        public float Weight;
        public Moonfish.Tags.ColourR8G8B8 ColorLowerBound;
        public Moonfish.Tags.ColourR8G8B8 ColorUpperBound;
        public Moonfish.Tags.StringIdent VariantName;
        public override int SerializedSize
        {
            get
            {
                return 32;
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
            this.Weight = binaryReader.ReadSingle();
            this.ColorLowerBound = binaryReader.ReadColourR8G8B8();
            this.ColorUpperBound = binaryReader.ReadColourR8G8B8();
            this.VariantName = binaryReader.ReadStringIdent();
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
            queueableBinaryWriter.Write(this.Weight);
            queueableBinaryWriter.Write(this.ColorLowerBound);
            queueableBinaryWriter.Write(this.ColorUpperBound);
            queueableBinaryWriter.Write(this.VariantName);
        }
    }
}
