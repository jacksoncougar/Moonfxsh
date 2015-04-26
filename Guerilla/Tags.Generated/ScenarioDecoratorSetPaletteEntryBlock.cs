// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioDecoratorSetPaletteEntryBlock : ScenarioDecoratorSetPaletteEntryBlockBase
    {
        public  ScenarioDecoratorSetPaletteEntryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioDecoratorSetPaletteEntryBlockBase  : IGuerilla
    {
        [TagReference("DECR")]
        internal Moonfish.Tags.TagReference decoratorSet;
        internal  ScenarioDecoratorSetPaletteEntryBlockBase(BinaryReader binaryReader)
        {
            decoratorSet = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(decoratorSet);
                return nextAddress;
            }
        }
    };
}
