// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VehiclesBlock : VehiclesBlockBase
    {
        public  VehiclesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  VehiclesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class VehiclesBlockBase : GuerillaBlock
    {
        [TagReference("vehi")]
        internal Moonfish.Tags.TagReference vehicle;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  VehiclesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vehicle = binaryReader.ReadTagReference();
        }
        public  VehiclesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            vehicle = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vehicle);
                return nextAddress;
            }
        }
    };
}
