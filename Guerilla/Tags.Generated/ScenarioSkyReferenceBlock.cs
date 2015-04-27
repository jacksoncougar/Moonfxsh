// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioSkyReferenceBlock : ScenarioSkyReferenceBlockBase
    {
        public  ScenarioSkyReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioSkyReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioSkyReferenceBlockBase : GuerillaBlock
    {
        [TagReference("sky ")]
        internal Moonfish.Tags.TagReference sky;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioSkyReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sky = binaryReader.ReadTagReference();
        }
        public  ScenarioSkyReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sky);
                return nextAddress;
            }
        }
    };
}
