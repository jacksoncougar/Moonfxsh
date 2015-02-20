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
    [LayoutAttribute(Size = 16)]
    public class ScenarioStructureBspSphericalHarmonicLightingBlockBase
    {
        [TagReference("sbsp")]
        internal Moonfish.Tags.TagReference bSP;
        internal ScenarioSphericalHarmonicLightingPoint[] lightingPoints;
        internal  ScenarioStructureBspSphericalHarmonicLightingBlockBase(BinaryReader binaryReader)
        {
            this.bSP = binaryReader.ReadTagReference();
            this.lightingPoints = ReadScenarioSphericalHarmonicLightingPointArray(binaryReader);
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
        internal  virtual ScenarioSphericalHarmonicLightingPoint[] ReadScenarioSphericalHarmonicLightingPointArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioSphericalHarmonicLightingPoint));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioSphericalHarmonicLightingPoint[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioSphericalHarmonicLightingPoint(binaryReader);
                }
            }
            return array;
        }
    };
}
