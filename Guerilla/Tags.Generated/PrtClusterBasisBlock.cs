// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrtClusterBasisBlock : PrtClusterBasisBlockBase
    {
        public  PrtClusterBasisBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PrtClusterBasisBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PrtClusterBasisBlockBase : GuerillaBlock
    {
        internal float basisData;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PrtClusterBasisBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            basisData = binaryReader.ReadSingle();
        }
        public  PrtClusterBasisBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(basisData);
                return nextAddress;
            }
        }
    };
}
