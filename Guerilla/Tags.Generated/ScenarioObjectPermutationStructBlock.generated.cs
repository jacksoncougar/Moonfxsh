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
    
    public partial class ScenarioObjectPermutationStructBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent VariantName;
        public ActiveChangeColors ScenarioObjectPermutationStructActiveChangeColors;
        public Moonfish.Tags.ColourR1G1B1 PrimaryColor;
        public Moonfish.Tags.ColourR1G1B1 SecondaryColor;
        public Moonfish.Tags.ColourR1G1B1 TertiaryColor;
        public Moonfish.Tags.ColourR1G1B1 QuaternaryColor;
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.VariantName = binaryReader.ReadStringID();
            this.ScenarioObjectPermutationStructActiveChangeColors = ((ActiveChangeColors)(binaryReader.ReadInt32()));
            this.PrimaryColor = binaryReader.ReadColourR1G1B1();
            this.SecondaryColor = binaryReader.ReadColourR1G1B1();
            this.TertiaryColor = binaryReader.ReadColourR1G1B1();
            this.QuaternaryColor = binaryReader.ReadColourR1G1B1();
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
            queueableBinaryWriter.Write(this.VariantName);
            queueableBinaryWriter.Write(((int)(this.ScenarioObjectPermutationStructActiveChangeColors)));
            queueableBinaryWriter.Write(this.PrimaryColor);
            queueableBinaryWriter.Write(this.SecondaryColor);
            queueableBinaryWriter.Write(this.TertiaryColor);
            queueableBinaryWriter.Write(this.QuaternaryColor);
        }
        [System.FlagsAttribute()]
        public enum ActiveChangeColors : int
        {
            None = 0,
            Primary = 1,
            Secondary = 2,
            Tertiary = 4,
            Quaternary = 8,
        }
    }
}
