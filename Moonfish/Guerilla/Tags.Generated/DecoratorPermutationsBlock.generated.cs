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
    using Moonfish.Guerilla;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("decorator_permutations_block")]
    public partial class DecoratorPermutationsBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.StringIdent Name;
        public Moonfish.Tags.ByteBlockIndex1 Shader;
        private byte[] fieldpad = new byte[3];
        public Flags DecoratorPermutationsFlags;
        public FadeDistanceEnum FadeDistance;
        public byte Index;
        public byte DistributionWeight;
        public Moonfish.Model.Range Scale;
        public Moonfish.Tags.ColourR1G1B1 Tint1;
        public Moonfish.Tags.ColourR1G1B1 Tint2;
        private byte[] padding = new byte[2];
        public float BaseMapTintPercentage;
        public float LightmapTintPercentage;
        public float WindScale;
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
            this.Name = binaryReader.ReadStringIdent();
            this.Shader = binaryReader.ReadByteBlockIndex1();
            this.fieldpad = binaryReader.ReadBytes(3);
            this.DecoratorPermutationsFlags = ((Flags)(binaryReader.ReadByte()));
            this.FadeDistance = ((FadeDistanceEnum)(binaryReader.ReadByte()));
            this.Index = binaryReader.ReadByte();
            this.DistributionWeight = binaryReader.ReadByte();
            this.Scale = binaryReader.ReadRange();
            this.Tint1 = binaryReader.ReadColourR1G1B1();
            this.Tint2 = binaryReader.ReadColourR1G1B1();
            this.padding = binaryReader.ReadBytes(2);
            this.BaseMapTintPercentage = binaryReader.ReadSingle();
            this.LightmapTintPercentage = binaryReader.ReadSingle();
            this.WindScale = binaryReader.ReadSingle();
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.DeferReferences(writer);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(this.Name);
            writer.Write(this.Shader);
            writer.Write(this.fieldpad);
            writer.Write(((byte)(this.DecoratorPermutationsFlags)));
            writer.Write(((byte)(this.FadeDistance)));
            writer.Write(this.Index);
            writer.Write(this.DistributionWeight);
            writer.Write(this.Scale);
            writer.Write(this.Tint1);
            writer.Write(this.Tint2);
            writer.Write(this.padding);
            writer.Write(this.BaseMapTintPercentage);
            writer.Write(this.LightmapTintPercentage);
            writer.Write(this.WindScale);
        }
        [System.FlagsAttribute()]
        public enum Flags : byte
        {
            None = 0,
            AlignToNormal = 1,
            OnlyOnGround = 2,
            Upright = 4,
        }
        public enum FadeDistanceEnum : byte
        {
            Close = 0,
            Medium = 1,
            Far = 2,
        }
    }
}
