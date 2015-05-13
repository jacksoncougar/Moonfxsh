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
    
    public partial class MeleeDamageParametersStructBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// damage pyramid angles: defines the frustum from the camera that the melee-attack uses to find targets
        ///damage pyramid depth: how far the melee attack searches for a target
        /// </summary>
        public OpenTK.Vector2 DamagePyramidAngles;
        public float DamagePyramidDepth;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference _1stHitMeleeDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference _1stHitMeleeResponse;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference _2ndHitMeleeDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference _2ndHitMeleeResponse;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference _3rdHitMeleeDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference _3rdHitMeleeResponse;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference LungeMeleeDamage;
        [Moonfish.Tags.TagReferenceAttribute("jpt!")]
        public Moonfish.Tags.TagReference LungeMeleeResponse;
        public override int SerializedSize
        {
            get
            {
                return 76;
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
            this.DamagePyramidAngles = binaryReader.ReadVector2();
            this.DamagePyramidDepth = binaryReader.ReadSingle();
            this._1stHitMeleeDamage = binaryReader.ReadTagReference();
            this._1stHitMeleeResponse = binaryReader.ReadTagReference();
            this._2ndHitMeleeDamage = binaryReader.ReadTagReference();
            this._2ndHitMeleeResponse = binaryReader.ReadTagReference();
            this._3rdHitMeleeDamage = binaryReader.ReadTagReference();
            this._3rdHitMeleeResponse = binaryReader.ReadTagReference();
            this.LungeMeleeDamage = binaryReader.ReadTagReference();
            this.LungeMeleeResponse = binaryReader.ReadTagReference();
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
            queueableBinaryWriter.Write(this.DamagePyramidAngles);
            queueableBinaryWriter.Write(this.DamagePyramidDepth);
            queueableBinaryWriter.Write(this._1stHitMeleeDamage);
            queueableBinaryWriter.Write(this._1stHitMeleeResponse);
            queueableBinaryWriter.Write(this._2ndHitMeleeDamage);
            queueableBinaryWriter.Write(this._2ndHitMeleeResponse);
            queueableBinaryWriter.Write(this._3rdHitMeleeDamage);
            queueableBinaryWriter.Write(this._3rdHitMeleeResponse);
            queueableBinaryWriter.Write(this.LungeMeleeDamage);
            queueableBinaryWriter.Write(this.LungeMeleeResponse);
        }
    }
}
