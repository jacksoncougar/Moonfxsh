// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspDebugInfoRenderLineBlock : StructureBspDebugInfoRenderLineBlockBase
    {
        public  StructureBspDebugInfoRenderLineBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspDebugInfoRenderLineBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class StructureBspDebugInfoRenderLineBlockBase : GuerillaBlock
    {
        internal Type type;
        internal short code;
        internal short padThai;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 point0;
        internal OpenTK.Vector3 point1;
        
        public override int SerializedSize{get { return 32; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspDebugInfoRenderLineBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            code = binaryReader.ReadInt16();
            padThai = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point0 = binaryReader.ReadVector3();
            point1 = binaryReader.ReadVector3();
        }
        public  StructureBspDebugInfoRenderLineBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            code = binaryReader.ReadInt16();
            padThai = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point0 = binaryReader.ReadVector3();
            point1 = binaryReader.ReadVector3();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(code);
                binaryWriter.Write(padThai);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(point0);
                binaryWriter.Write(point1);
                return nextAddress;
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
