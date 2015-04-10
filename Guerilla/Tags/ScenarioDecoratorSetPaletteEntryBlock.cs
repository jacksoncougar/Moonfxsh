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
    [LayoutAttribute(Size = 8)]
    public class ScenarioDecoratorSetPaletteEntryBlockBase
    {
        [TagReference("DECR")]
        internal Moonfish.Tags.TagReference decoratorSet;
        internal  ScenarioDecoratorSetPaletteEntryBlockBase(BinaryReader binaryReader)
        {
            this.decoratorSet = binaryReader.ReadTagReference();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
