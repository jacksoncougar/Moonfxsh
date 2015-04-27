// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PointBlockReferenceBlock : PointBlockReferenceBlockBase
    {
        public  PointBlockReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PointBlockReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PointBlockReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.Point coordinates;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PointBlockReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            coordinates = binaryReader.ReadPoint();
        }
        public  PointBlockReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            coordinates = binaryReader.ReadPoint();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(coordinates);
                return nextAddress;
            }
        }
    };
}
