// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspWeatherPolyhedronPlaneBlock : StructureBspWeatherPolyhedronPlaneBlockBase
    {
        public  StructureBspWeatherPolyhedronPlaneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspWeatherPolyhedronPlaneBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class StructureBspWeatherPolyhedronPlaneBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector4 plane;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspWeatherPolyhedronPlaneBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            plane = binaryReader.ReadVector4();
        }
        public  StructureBspWeatherPolyhedronPlaneBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            plane = binaryReader.ReadVector4();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(plane);
                return nextAddress;
            }
        }
    };
}
