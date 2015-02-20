using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioSphericalHarmonicLightingPoint : ScenarioSphericalHarmonicLightingPointBase
    {
        public  ScenarioSphericalHarmonicLightingPoint(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ScenarioSphericalHarmonicLightingPointBase
    {
        internal OpenTK.Vector3 position;
        internal  ScenarioSphericalHarmonicLightingPointBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
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
    };
}
