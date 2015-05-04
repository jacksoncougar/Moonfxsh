// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class InstancedGeometryReferenceBlock : InstancedGeometryReferenceBlockBase
    {
        public  InstancedGeometryReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  InstancedGeometryReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class InstancedGeometryReferenceBlockBase : GuerillaBlock
    {
        internal short pathfindingObjectIndex;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  InstancedGeometryReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            pathfindingObjectIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  InstancedGeometryReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            pathfindingObjectIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(pathfindingObjectIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
