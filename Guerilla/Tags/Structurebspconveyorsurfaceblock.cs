// ReSharper disable All
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
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class StructureBspConveyorSurfaceBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 u;
        internal OpenTK.Vector3 v;
        internal  StructureBspConveyorSurfaceBlockBase(BinaryReader binaryReader)
        {
            u = binaryReader.ReadVector3();
            v = binaryReader.ReadVector3();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(u);
                binaryWriter.Write(v);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
