using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class FiringPositionsBlock : FiringPositionsBlockBase
    {
        public  FiringPositionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class FiringPositionsBlockBase
    {
        internal OpenTK.Vector3 positionLocal;
        internal short referenceFrame;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 area;
        internal short clusterIndex;
        internal byte[] invalidName_;
        internal OpenTK.Vector2 normal;
        internal  FiringPositionsBlockBase(BinaryReader binaryReader)
        {
            this.positionLocal = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.area = binaryReader.ReadShortBlockIndex1();
            this.clusterIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.normal = binaryReader.ReadVector2();
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Open = 1,
            Partial = 2,
            Closed = 4,
            Mobile = 8,
            WallLean = 16,
            Perch = 32,
            GroundPoint = 64,
            DynamicCoverPoint = 128,
        };
    };
}
