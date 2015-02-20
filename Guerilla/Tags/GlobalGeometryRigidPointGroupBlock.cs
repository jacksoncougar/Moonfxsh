using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryRigidPointGroupBlock : GlobalGeometryRigidPointGroupBlockBase
    {
        public  GlobalGeometryRigidPointGroupBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class GlobalGeometryRigidPointGroupBlockBase
    {
        internal byte rigidNodeIndex;
        internal byte nodesPoint;
        internal short pointCount;
        internal  GlobalGeometryRigidPointGroupBlockBase(BinaryReader binaryReader)
        {
            this.rigidNodeIndex = binaryReader.ReadByte();
            this.nodesPoint = binaryReader.ReadByte();
            this.pointCount = binaryReader.ReadInt16();
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
