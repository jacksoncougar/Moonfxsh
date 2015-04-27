// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioObjectPermutationStructBlock : ScenarioObjectPermutationStructBlockBase
    {
        public  ScenarioObjectPermutationStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioObjectPermutationStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ScenarioObjectPermutationStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID variantName;
        internal ActiveChangeColors activeChangeColors;
        internal Moonfish.Tags.RGBColor primaryColor;
        internal Moonfish.Tags.RGBColor secondaryColor;
        internal Moonfish.Tags.RGBColor tertiaryColor;
        internal Moonfish.Tags.RGBColor quaternaryColor;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioObjectPermutationStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            variantName = binaryReader.ReadStringID();
            activeChangeColors = (ActiveChangeColors)binaryReader.ReadInt32();
            primaryColor = binaryReader.ReadRGBColor();
            secondaryColor = binaryReader.ReadRGBColor();
            tertiaryColor = binaryReader.ReadRGBColor();
            quaternaryColor = binaryReader.ReadRGBColor();
        }
        public  ScenarioObjectPermutationStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            variantName = binaryReader.ReadStringID();
            activeChangeColors = (ActiveChangeColors)binaryReader.ReadInt32();
            primaryColor = binaryReader.ReadRGBColor();
            secondaryColor = binaryReader.ReadRGBColor();
            tertiaryColor = binaryReader.ReadRGBColor();
            quaternaryColor = binaryReader.ReadRGBColor();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantName);
                binaryWriter.Write((Int32)activeChangeColors);
                binaryWriter.Write(primaryColor);
                binaryWriter.Write(secondaryColor);
                binaryWriter.Write(tertiaryColor);
                binaryWriter.Write(quaternaryColor);
                return nextAddress;
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
