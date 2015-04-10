// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioObjectPermutationStructBlock : ScenarioObjectPermutationStructBlockBase
    {
        public  ScenarioObjectPermutationStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class ScenarioObjectPermutationStructBlockBase
    {
        internal Moonfish.Tags.StringID variantName;
        internal ActiveChangeColors activeChangeColors;
        internal Moonfish.Tags.RGBColor primaryColor;
        internal Moonfish.Tags.RGBColor secondaryColor;
        internal Moonfish.Tags.RGBColor tertiaryColor;
        internal Moonfish.Tags.RGBColor quaternaryColor;
        internal  ScenarioObjectPermutationStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            variantName = binaryReader.ReadStringID();
            activeChangeColors = (ActiveChangeColors)binaryReader.ReadInt32();
            primaryColor = binaryReader.ReadRGBColor();
            secondaryColor = binaryReader.ReadRGBColor();
            tertiaryColor = binaryReader.ReadRGBColor();
            quaternaryColor = binaryReader.ReadRGBColor();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantName);
                binaryWriter.Write((Int32)activeChangeColors);
                binaryWriter.Write(primaryColor);
                binaryWriter.Write(secondaryColor);
                binaryWriter.Write(tertiaryColor);
                binaryWriter.Write(quaternaryColor);
            }
        }
        [FlagsAttribute]
        internal enum ActiveChangeColors : int
        
        {
            Primary = 1,
            Secondary = 2,
            Tertiary = 4,
            Quaternary = 8,
        };
    };
}
