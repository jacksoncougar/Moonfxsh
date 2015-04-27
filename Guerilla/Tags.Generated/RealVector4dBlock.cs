// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RealVector4dBlock : RealVector4dBlockBase
    {
        public  RealVector4dBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RealVector4dBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class RealVector4dBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 vector3;
        internal float w;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RealVector4dBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            vector3 = binaryReader.ReadVector3();
            w = binaryReader.ReadSingle();
        }
        public  RealVector4dBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            vector3 = binaryReader.ReadVector3();
            w = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vector3);
                binaryWriter.Write(w);
                return nextAddress;
            }
        }
    };
}
