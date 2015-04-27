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
    public partial class ScenarioDecoratorsResourceBlock : ScenarioDecoratorsResourceBlockBase
    {
        public  ScenarioDecoratorsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioDecoratorsResourceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecoratorsResourceBlockBase : GuerillaBlock
    {
        internal DecoratorPlacementDefinitionBlock[] decorator;
        internal ScenarioDecoratorSetPaletteEntryBlock[] decoratorPalette;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioDecoratorsResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            decorator = Guerilla.ReadBlockArray<DecoratorPlacementDefinitionBlock>(binaryReader);
            decoratorPalette = Guerilla.ReadBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader);
        }
        public  ScenarioDecoratorsResourceBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            decorator = Guerilla.ReadBlockArray<DecoratorPlacementDefinitionBlock>(binaryReader);
            decoratorPalette = Guerilla.ReadBlockArray<ScenarioDecoratorSetPaletteEntryBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
