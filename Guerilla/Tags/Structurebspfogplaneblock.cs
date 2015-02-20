using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspFogPlaneBlock : StructureBspFogPlaneBlockBase
    {
        public  StructureBspFogPlaneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class StructureBspFogPlaneBlockBase
    {
        internal short scenarioPlanarFogIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector4 plane;
        internal Flags flags;
        internal short priority;
        internal  StructureBspFogPlaneBlockBase(BinaryReader binaryReader)
        {
            this.scenarioPlanarFogIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.plane = binaryReader.ReadVector4();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.priority = binaryReader.ReadInt16();
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
        internal enum Flags : short
        {
            ExtendInfinitelyWhileVisible = 1,
            DoNotFloodfill = 2,
            AggressiveFloodfill = 4,
        };
    };
}
