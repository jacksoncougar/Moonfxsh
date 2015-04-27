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
        public static readonly TagClass Dec = (TagClass)"dec*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dec*")]
    public partial class ScenarioDecalsResourceBlock : ScenarioDecalsResourceBlockBase
    {
        public  ScenarioDecalsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioDecalsResourceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecalsResourceBlockBase : GuerillaBlock
    {
        internal ScenarioDecalPaletteBlock[] palette;
        internal ScenarioDecalsBlock[] decals;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioDecalsResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            palette = Guerilla.ReadBlockArray<ScenarioDecalPaletteBlock>(binaryReader);
            decals = Guerilla.ReadBlockArray<ScenarioDecalsBlock>(binaryReader);
        }
        public  ScenarioDecalsResourceBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            palette = Guerilla.ReadBlockArray<ScenarioDecalPaletteBlock>(binaryReader);
            decals = Guerilla.ReadBlockArray<ScenarioDecalsBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecalPaletteBlock>(binaryWriter, palette, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioDecalsBlock>(binaryWriter, decals, nextAddress);
                return nextAddress;
            }
        }
    };
}
