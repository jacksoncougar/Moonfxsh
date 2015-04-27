// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioResourceReferenceBlock : ScenarioResourceReferenceBlockBase
    {
        public  ScenarioResourceReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioResourceReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioResourceReferenceBlockBase : GuerillaBlock
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference reference;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioResourceReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            reference = binaryReader.ReadTagReference();
        }
        public  ScenarioResourceReferenceBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(reference);
                return nextAddress;
            }
        }
    };
}
