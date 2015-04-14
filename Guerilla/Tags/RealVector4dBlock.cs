// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RealVector4dBlock : RealVector4dBlockBase
    {
        public  RealVector4dBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class RealVector4dBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 vector3;
        internal float w;
        internal  RealVector4dBlockBase(BinaryReader binaryReader)
        {
            vector3 = binaryReader.ReadVector3();
            w = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(vector3);
                binaryWriter.Write(w);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
