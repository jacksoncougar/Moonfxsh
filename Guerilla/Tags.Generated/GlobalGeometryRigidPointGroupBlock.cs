// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryRigidPointGroupBlock : GlobalGeometryRigidPointGroupBlockBase
    {
        public  GlobalGeometryRigidPointGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalGeometryRigidPointGroupBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class GlobalGeometryRigidPointGroupBlockBase : GuerillaBlock
    {
        internal byte rigidNodeIndex;
        internal byte nodesPoint;
        internal short pointCount;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalGeometryRigidPointGroupBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            rigidNodeIndex = binaryReader.ReadByte();
            nodesPoint = binaryReader.ReadByte();
            pointCount = binaryReader.ReadInt16();
        }
        public  GlobalGeometryRigidPointGroupBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            rigidNodeIndex = binaryReader.ReadByte();
            nodesPoint = binaryReader.ReadByte();
            pointCount = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(rigidNodeIndex);
                binaryWriter.Write(nodesPoint);
                binaryWriter.Write(pointCount);
                return nextAddress;
            }
        }
    };
}
