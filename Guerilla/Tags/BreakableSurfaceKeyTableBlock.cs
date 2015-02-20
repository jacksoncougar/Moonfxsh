using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BreakableSurfaceKeyTableBlock : BreakableSurfaceKeyTableBlockBase
    {
        public  BreakableSurfaceKeyTableBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class BreakableSurfaceKeyTableBlockBase
    {
        internal short instancedGeometryIndex;
        internal short breakableSurfaceIndex;
        internal int seedSurfaceIndex;
        internal float x0;
        internal float x1;
        internal float y0;
        internal float y1;
        internal float z0;
        internal float z1;
        internal  BreakableSurfaceKeyTableBlockBase(BinaryReader binaryReader)
        {
            this.instancedGeometryIndex = binaryReader.ReadInt16();
            this.breakableSurfaceIndex = binaryReader.ReadInt16();
            this.seedSurfaceIndex = binaryReader.ReadInt32();
            this.x0 = binaryReader.ReadSingle();
            this.x1 = binaryReader.ReadSingle();
            this.y0 = binaryReader.ReadSingle();
            this.y1 = binaryReader.ReadSingle();
            this.z0 = binaryReader.ReadSingle();
            this.z1 = binaryReader.ReadSingle();
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
