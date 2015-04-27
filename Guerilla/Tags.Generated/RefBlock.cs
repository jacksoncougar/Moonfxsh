// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RefBlock : RefBlockBase
    {
        public  RefBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RefBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class RefBlockBase : GuerillaBlock
    {
        internal int nodeRefOrSectorRef;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RefBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            nodeRefOrSectorRef = binaryReader.ReadInt32();
        }
        public  RefBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            nodeRefOrSectorRef = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeRefOrSectorRef);
                return nextAddress;
            }
        }
    };
}
