// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioStructureBspSphericalHarmonicLightingBlock : ScenarioStructureBspSphericalHarmonicLightingBlockBase
    {
        public  ScenarioStructureBspSphericalHarmonicLightingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioStructureBspSphericalHarmonicLightingBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioStructureBspSphericalHarmonicLightingBlockBase : GuerillaBlock
    {
        [TagReference("sbsp")]
        internal Moonfish.Tags.TagReference bSP;
        internal ScenarioSphericalHarmonicLightingPoint[] lightingPoints;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioStructureBspSphericalHarmonicLightingBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bSP = binaryReader.ReadTagReference();
            lightingPoints = Guerilla.ReadBlockArray<ScenarioSphericalHarmonicLightingPoint>(binaryReader);
        }
        public  ScenarioStructureBspSphericalHarmonicLightingBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            bSP = binaryReader.ReadTagReference();
            lightingPoints = Guerilla.ReadBlockArray<ScenarioSphericalHarmonicLightingPoint>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
