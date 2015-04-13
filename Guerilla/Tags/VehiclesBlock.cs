// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VehiclesBlock : VehiclesBlockBase
    {
        public  VehiclesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class VehiclesBlockBase  : IGuerilla
    {
        [TagReference("vehi")]
        internal Moonfish.Tags.TagReference vehicle;
        internal  VehiclesBlockBase(BinaryReader binaryReader)
        {
            vehicle = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vehicle);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
