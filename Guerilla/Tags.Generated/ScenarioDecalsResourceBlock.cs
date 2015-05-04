// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Dec = (TagClass) "dec*";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dec*")]
    public partial class ScenarioDecalsResourceBlock : ScenarioDecalsResourceBlockBase
    {
        public ScenarioDecalsResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecalsResourceBlockBase : GuerillaBlock
    {
        internal ScenarioDecalPaletteBlock[] palette;
        internal ScenarioDecalsBlock[] decals;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioDecalsResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDecalPaletteBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDecalsBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            palette = ReadBlockArrayData<ScenarioDecalPaletteBlock>(binaryReader, blamPointers.Dequeue());
            decals = ReadBlockArrayData<ScenarioDecalsBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecalPaletteBlock>(binaryWriter, palette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecalsBlock>(binaryWriter, decals, nextAddress);
                return nextAddress;
            }
        }
    };
}