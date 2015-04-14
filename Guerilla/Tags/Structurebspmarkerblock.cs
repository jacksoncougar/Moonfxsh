// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspMarkerBlock : StructureBspMarkerBlockBase
    {
        public  StructureBspMarkerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class StructureBspMarkerBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Quaternion rotation;
        internal OpenTK.Vector3 position;
        internal  StructureBspMarkerBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            rotation = binaryReader.ReadQuaternion();
            position = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(rotation);
                binaryWriter.Write(position);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
