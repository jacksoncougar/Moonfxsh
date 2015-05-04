// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioSphericalHarmonicLightingPoint : ScenarioSphericalHarmonicLightingPointBase
    {
        public  ScenarioSphericalHarmonicLightingPoint(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioSphericalHarmonicLightingPoint(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ScenarioSphericalHarmonicLightingPointBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioSphericalHarmonicLightingPointBase(BinaryReader binaryReader): base(binaryReader)
        {
            position = binaryReader.ReadVector3();
        }
        public  ScenarioSphericalHarmonicLightingPointBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                return nextAddress;
            }
        }
    };
}
