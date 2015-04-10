using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sslt")]
    public  partial class ScenarioStructureLightingResourceBlock : ScenarioStructureLightingResourceBlockBase
    {
        public  ScenarioStructureLightingResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ScenarioStructureLightingResourceBlockBase
    {
        internal ScenarioStructureBspSphericalHarmonicLightingBlock[] structureLighting;
        internal  ScenarioStructureLightingResourceBlockBase(BinaryReader binaryReader)
        {
            this.structureLighting = ReadScenarioStructureBspSphericalHarmonicLightingBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ScenarioStructureBspSphericalHarmonicLightingBlock[] ReadScenarioStructureBspSphericalHarmonicLightingBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioStructureBspSphericalHarmonicLightingBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioStructureBspSphericalHarmonicLightingBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioStructureBspSphericalHarmonicLightingBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
