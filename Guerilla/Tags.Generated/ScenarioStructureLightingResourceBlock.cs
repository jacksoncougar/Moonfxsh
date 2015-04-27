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
    public partial class ScenarioStructureLightingResourceBlock : ScenarioStructureLightingResourceBlockBase
    {
        public  ScenarioStructureLightingResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioStructureLightingResourceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioStructureLightingResourceBlockBase : GuerillaBlock
    {
        internal ScenarioStructureBspSphericalHarmonicLightingBlock[] structureLighting;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioStructureLightingResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            structureLighting = Guerilla.ReadBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryReader);
        }
        public  ScenarioStructureLightingResourceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioStructureBspSphericalHarmonicLightingBlock>(binaryWriter, structureLighting, nextAddress);
                return nextAddress;
            }
        }
    };
}
