using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspDebugInfoRenderLineBlock : StructureBspDebugInfoRenderLineBlockBase
    {
        public  StructureBspDebugInfoRenderLineBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class StructureBspDebugInfoRenderLineBlockBase
    {
        internal Type type;
        internal short code;
        internal short padThai;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 point0;
        internal OpenTK.Vector3 point1;
        internal  StructureBspDebugInfoRenderLineBlockBase(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.code = binaryReader.ReadInt16();
            this.padThai = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.point0 = binaryReader.ReadVector3();
            this.point1 = binaryReader.ReadVector3();
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
        internal enum Type : short
        {
            FogPlaneBoundaryEdge = 0,
            FogPlaneInternalEdge = 1,
            FogZoneFloodfill = 2,
            FogZoneClusterCentroid = 3,
            FogZoneClusterGeometry = 4,
            FogZonePortalCentroid = 5,
            FogZonePortalGeometry = 6,
        };
    };
}
