// ReSharper disable All
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
        public  StructureBspDebugInfoRenderLineBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspDebugInfoRenderLineBlockBase(System.IO.BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            code = binaryReader.ReadInt16();
            padThai = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point0 = binaryReader.ReadVector3();
            point1 = binaryReader.ReadVector3();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(code);
                binaryWriter.Write(padThai);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(point0);
                binaryWriter.Write(point1);
            }
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
