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
    [TagBlockOriginalNameAttribute("sound_gestalt_permutations_block")]
    public partial class SoundGestaltPermutationsBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.ShortBlockIndex1 Name;
        public short EncodedSkipFraction;
        public byte EncodedGain;
        public byte PermutationInfoIndex;
        public short LanguageNeutralTime;
        public int SampleSize;
        public Moonfish.Tags.ShortBlockIndex1 FirstChunk;
        public short ChunkCount;
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
            this.Name = binaryReader.ReadShortBlockIndex1();
            this.EncodedSkipFraction = binaryReader.ReadInt16();
            this.EncodedGain = binaryReader.ReadByte();
            this.PermutationInfoIndex = binaryReader.ReadByte();
            this.LanguageNeutralTime = binaryReader.ReadInt16();
            this.SampleSize = binaryReader.ReadInt32();
            this.FirstChunk = binaryReader.ReadShortBlockIndex1();
            this.ChunkCount = binaryReader.ReadInt16();
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
            queueableBinaryWriter.Write(this.Name);
            queueableBinaryWriter.Write(this.EncodedSkipFraction);
            queueableBinaryWriter.Write(this.EncodedGain);
            queueableBinaryWriter.Write(this.PermutationInfoIndex);
            queueableBinaryWriter.Write(this.LanguageNeutralTime);
            queueableBinaryWriter.Write(this.SampleSize);
            queueableBinaryWriter.Write(this.FirstChunk);
            queueableBinaryWriter.Write(this.ChunkCount);
        }
    }
}
