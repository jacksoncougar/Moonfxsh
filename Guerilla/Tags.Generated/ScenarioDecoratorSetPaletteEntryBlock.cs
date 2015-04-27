// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioDecoratorSetPaletteEntryBlock : ScenarioDecoratorSetPaletteEntryBlockBase
    {
        public  ScenarioDecoratorSetPaletteEntryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioDecoratorSetPaletteEntryBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioDecoratorSetPaletteEntryBlockBase : GuerillaBlock
    {
        [TagReference("DECR")]
        internal Moonfish.Tags.TagReference decoratorSet;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioDecoratorSetPaletteEntryBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            decoratorSet = binaryReader.ReadTagReference();
        }
        public  ScenarioDecoratorSetPaletteEntryBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(decoratorSet);
                return nextAddress;
            }
        }
    };
}
