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
    [TagBlockOriginalNameAttribute("unit_boarding_melee_struct_block")]
    public partial class UnitBoardingMeleeStructBlock : GuerillaBlock, IWriteDeferrable
    {
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference BoardingMeleeDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference BoardingMeleeResponse;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference LandingMeleeDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference FlurryMeleeDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference ObstacleSmashDamage;
        public override int SerializedSize
        {
            get
            {
                return 40;
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
            this.BoardingMeleeDamage = binaryReader.ReadTagReference();
            this.BoardingMeleeResponse = binaryReader.ReadTagReference();
            this.LandingMeleeDamage = binaryReader.ReadTagReference();
            this.FlurryMeleeDamage = binaryReader.ReadTagReference();
            this.ObstacleSmashDamage = binaryReader.ReadTagReference();
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
            queueableBinaryWriter.Write(this.BoardingMeleeDamage);
            queueableBinaryWriter.Write(this.BoardingMeleeResponse);
            queueableBinaryWriter.Write(this.LandingMeleeDamage);
            queueableBinaryWriter.Write(this.FlurryMeleeDamage);
            queueableBinaryWriter.Write(this.ObstacleSmashDamage);
        }
    }
}
