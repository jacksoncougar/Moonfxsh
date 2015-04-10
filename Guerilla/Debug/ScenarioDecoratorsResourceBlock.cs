// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dc*s")]
    public  partial class ScenarioDecoratorsResourceBlock : ScenarioDecoratorsResourceBlockBase
    {
        public  ScenarioDecoratorsResourceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ScenarioDecoratorsResourceBlockBase
    {
        internal DecoratorPlacementDefinitionBlock[] decorator;
        internal ScenarioDecoratorSetPaletteEntryBlock[] decoratorPalette;
        internal  ScenarioDecoratorsResourceBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadDecoratorPlacementDefinitionBlockArray(binaryReader);
            ReadScenarioDecoratorSetPaletteEntryBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual DecoratorPlacementDefinitionBlock[] ReadDecoratorPlacementDefinitionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(DecoratorPlacementDefinitionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new DecoratorPlacementDefinitionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new DecoratorPlacementDefinitionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioDecoratorSetPaletteEntryBlock[] ReadScenarioDecoratorSetPaletteEntryBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioDecoratorSetPaletteEntryBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioDecoratorSetPaletteEntryBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioDecoratorSetPaletteEntryBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteDecoratorPlacementDefinitionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioDecoratorSetPaletteEntryBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteDecoratorPlacementDefinitionBlockArray(binaryWriter);
                WriteScenarioDecoratorSetPaletteEntryBlockArray(binaryWriter);
            }
        }
    };
}
