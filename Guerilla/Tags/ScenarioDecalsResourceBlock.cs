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
        public static readonly TagClass Dec*Class = (TagClass)"dec*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("dec*")]
    public  partial class ScenarioDecalsResourceBlock : ScenarioDecalsResourceBlockBase
    {
        public  ScenarioDecalsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioDecalsResourceBlockBase  : IGuerilla
    {
        internal ScenarioDecalPaletteBlock[] palette;
        internal ScenarioDecalsBlock[] decals;
        internal  ScenarioDecalsResourceBlockBase(BinaryReader binaryReader)
        {
            palette = Guerilla.ReadBlockArray<ScenarioDecalPaletteBlock>(binaryReader);
            decals = Guerilla.ReadBlockArray<ScenarioDecalsBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<ScenarioDecalPaletteBlock>(binaryWriter, palette, nextAddress);
                Guerilla.WriteBlockArray<ScenarioDecalsBlock>(binaryWriter, decals, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
