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
        public static readonly TagClass Sslt = (TagClass)"sslt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sslt")]
    public  partial class ScenarioStructureLightingResourceBlock : ScenarioStructureLightingResourceBlockBase
    {
        public  ScenarioStructureLightingResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioStructureLightingResourceBlockBase  : IGuerilla
    {
        internal ScenarioStructureBspSphericalHarmonicLightingBlock[] structureLighting;
        internal  ScenarioStructureLightingResourceBlockBase(BinaryReader binaryReader)
        {
            structureLighting = Guerilla.ReadBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryWriter, structureLighting, nextAddress);
                return nextAddress;
            }
        }
    };
}
