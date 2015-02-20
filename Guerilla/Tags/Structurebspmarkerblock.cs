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
    [LayoutAttribute(Size = 60)]
    public class StructureBspMarkerBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Quaternion rotation;
        internal OpenTK.Vector3 position;
        internal  StructureBspMarkerBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.rotation = binaryReader.ReadQuaternion();
            this.position = binaryReader.ReadVector3();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
