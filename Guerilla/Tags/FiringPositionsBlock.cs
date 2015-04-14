// ReSharper disable All
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
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class FiringPositionsBlockBase  : IGuerilla
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
            positionLocal = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            area = binaryReader.ReadShortBlockIndex1();
            clusterIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(4);
            normal = binaryReader.ReadVector2();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(positionLocal);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(area);
                binaryWriter.Write(clusterIndex);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(normal);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
