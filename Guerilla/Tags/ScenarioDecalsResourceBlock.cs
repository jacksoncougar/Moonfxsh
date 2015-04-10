using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dec*")]
    public  partial class ScenarioDecalsResourceBlock : ScenarioDecalsResourceBlockBase
    {
        public  ScenarioDecalsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ScenarioDecalsResourceBlockBase
    {
        internal ScenarioDecalPaletteBlock[] palette;
        internal ScenarioDecalsBlock[] decals;
        internal  ScenarioDecalsResourceBlockBase(BinaryReader binaryReader)
        {
            this.palette = ReadScenarioDecalPaletteBlockArray(binaryReader);
            this.decals = ReadScenarioDecalsBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ScenarioDecalPaletteBlock[] ReadScenarioDecalPaletteBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDecalPaletteBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDecalPaletteBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDecalPaletteBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioDecalsBlock[] ReadScenarioDecalsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDecalsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDecalsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDecalsBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
