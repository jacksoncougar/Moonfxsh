// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlanesBlock : PlanesBlockBase
    {
        public  PlanesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlanesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 16)]
    public class PlanesBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector4 plane;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 16; }}
        
        public  PlanesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            plane = binaryReader.ReadVector4();
        }
        public  PlanesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
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
