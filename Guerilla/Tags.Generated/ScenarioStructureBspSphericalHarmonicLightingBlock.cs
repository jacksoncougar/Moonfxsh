// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioStructureBspSphericalHarmonicLightingBlock : ScenarioStructureBspSphericalHarmonicLightingBlockBase
    {
        public  ScenarioStructureBspSphericalHarmonicLightingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioStructureBspSphericalHarmonicLightingBlockBase  : IGuerilla
    {
        [TagReference("sbsp")]
        internal Moonfish.Tags.TagReference bSP;
        internal ScenarioSphericalHarmonicLightingPoint[] lightingPoints;
        internal  ScenarioStructureBspSphericalHarmonicLightingBlockBase(BinaryReader binaryReader)
        {
            bSP = binaryReader.ReadTagReference();
            lightingPoints = Guerilla.ReadBlockArray<ScenarioSphericalHarmonicLightingPoint>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSP);
                nextAddress = Guerilla.WriteBlockArray<ScenarioSphericalHarmonicLightingPoint>(binaryWriter, lightingPoints, nextAddress);
                return nextAddress;
            }
        }
    };
}
