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
        public static readonly TagClass Dcs = (TagClass) "dc*s";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dc*s")]
    public partial class ScenarioDecoratorsResourceBlock : ScenarioDecoratorsResourceBlockBase
    {
        public ScenarioDecoratorsResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecoratorsResourceBlockBase : GuerillaBlock
    {
        internal DecoratorPlacementDefinitionBlock[] decorator;
        internal ScenarioDecoratorSetPaletteEntryBlock[] decoratorPalette;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioDecoratorsResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<DecoratorPlacementDefinitionBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            decorator = ReadBlockArrayData<DecoratorPlacementDefinitionBlock>(binaryReader, blamPointers.Dequeue());
            decoratorPalette = ReadBlockArrayData<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DecoratorPlacementDefinitionBlock>(binaryWriter, decorator,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryWriter,
                    decoratorPalette, nextAddress);
                return nextAddress;
            }
        }
    };
}