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
        public  ScenarioObjectPermutationStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioObjectPermutationStructBlockBase(BinaryReader binaryReader)
        {
            this.variantName = binaryReader.ReadStringID();
            this.activeChangeColors = (ActiveChangeColors)binaryReader.ReadInt32();
            this.primaryColor = binaryReader.ReadRGBColor();
            this.secondaryColor = binaryReader.ReadRGBColor();
            this.tertiaryColor = binaryReader.ReadRGBColor();
            this.quaternaryColor = binaryReader.ReadRGBColor();
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
