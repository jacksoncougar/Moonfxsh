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
        public static readonly TagClass GldfClass = (TagClass)"gldf";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("gldf")]
    public  partial class ChocolateMountainBlock : ChocolateMountainBlockBase
    {
        public  ChocolateMountainBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ChocolateMountainBlockBase  : IGuerilla
    {
        internal LightingVariablesBlock[] lightingVariables;
        internal  ChocolateMountainBlockBase(BinaryReader binaryReader)
        {
            lightingVariables = Guerilla.ReadBlockArray<LightingVariablesBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<LightingVariablesBlock>(binaryWriter, lightingVariables, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
