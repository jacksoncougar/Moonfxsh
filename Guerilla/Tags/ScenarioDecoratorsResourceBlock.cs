// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Dcs = (TagClass)"dc*s";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dc*s")]
    public  partial class ScenarioDecoratorsResourceBlock : ScenarioDecoratorsResourceBlockBase
    {
        public  ScenarioDecoratorsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecoratorsResourceBlockBase  : IGuerilla
    {
        internal DecoratorPlacementDefinitionBlock[] decorator;
        internal ScenarioDecoratorSetPaletteEntryBlock[] decoratorPalette;
        internal  ScenarioDecoratorsResourceBlockBase(BinaryReader binaryReader)
        {
            decorator = Guerilla.ReadBlockArray<DecoratorPlacementDefinitionBlock>(binaryReader);
            decoratorPalette = Guerilla.ReadBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DecoratorPlacementDefinitionBlock>(binaryWriter, decorator, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryWriter, decoratorPalette, nextAddress);
                return nextAddress;
            }
        }
    };
}
