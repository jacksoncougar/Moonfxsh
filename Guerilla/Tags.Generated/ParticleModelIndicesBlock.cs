// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleModelIndicesBlock : ParticleModelIndicesBlockBase
    {
        public  ParticleModelIndicesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ParticleModelIndicesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ParticleModelIndicesBlockBase : GuerillaBlock
    {
        internal short index;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ParticleModelIndicesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            index = binaryReader.ReadInt16();
        }
        public  ParticleModelIndicesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                return nextAddress;
            }
        }
    };
}
