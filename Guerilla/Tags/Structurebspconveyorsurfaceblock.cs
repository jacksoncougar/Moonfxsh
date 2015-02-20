using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspConveyorSurfaceBlock : StructureBspConveyorSurfaceBlockBase
    {
        public  StructureBspConveyorSurfaceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class StructureBspConveyorSurfaceBlockBase
    {
        internal OpenTK.Vector3 u;
        internal OpenTK.Vector3 v;
        internal  StructureBspConveyorSurfaceBlockBase(BinaryReader binaryReader)
        {
            this.u = binaryReader.ReadVector3();
            this.v = binaryReader.ReadVector3();
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
