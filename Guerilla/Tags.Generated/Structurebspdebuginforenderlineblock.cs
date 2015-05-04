// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspDebugInfoRenderLineBlock : StructureBspDebugInfoRenderLineBlockBase
    {
        public StructureBspDebugInfoRenderLineBlock() : base()
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
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public StructureBspDebugInfoRenderLineBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type)binaryReader.ReadInt16();
            code = binaryReader.ReadInt16();
            padThai = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point0 = binaryReader.ReadVector3();
            point1 = binaryReader.ReadVector3();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
