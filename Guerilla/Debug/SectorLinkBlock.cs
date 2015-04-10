// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SectorLinkBlock : SectorLinkBlockBase
    {
        public  SectorLinkBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SectorLinkBlockBase
    {
        internal short vertex1;
        internal short vertex2;
        internal LinkFlags linkFlags;
        internal short hintIndex;
        internal short forwardLink;
        internal short reverseLink;
        internal short leftSector;
        internal short rightSector;
        internal  SectorLinkBlockBase(System.IO.BinaryReader binaryReader)
        {
            vertex1 = binaryReader.ReadInt16();
            vertex2 = binaryReader.ReadInt16();
            linkFlags = (LinkFlags)binaryReader.ReadInt16();
            hintIndex = binaryReader.ReadInt16();
            forwardLink = binaryReader.ReadInt16();
            reverseLink = binaryReader.ReadInt16();
            leftSector = binaryReader.ReadInt16();
            rightSector = binaryReader.ReadInt16();
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
                binaryWriter.Write(vertex1);
                binaryWriter.Write(vertex2);
                binaryWriter.Write((Int16)linkFlags);
                binaryWriter.Write(hintIndex);
                binaryWriter.Write(forwardLink);
                binaryWriter.Write(reverseLink);
                binaryWriter.Write(leftSector);
                binaryWriter.Write(rightSector);
            }
        }
        [FlagsAttribute]
        internal enum LinkFlags : short
        
        {
            SectorLinkFromCollisionEdge = 1,
            SectorIntersectionLink = 2,
            SectorLinkBsp2dCreationError = 4,
            SectorLinkTopologyError = 8,
            SectorLinkChainError = 16,
            SectorLinkBothSectorsWalkable = 32,
            SectorLinkMagicHangingLink = 64,
            SectorLinkThreshold = 128,
            SectorLinkCrouchable = 256,
            SectorLinkWallBase = 512,
            SectorLinkLedge = 1024,
            SectorLinkLeanable = 2048,
            SectorLinkStartCorner = 4096,
            SectorLinkEndCorner = 8192,
        };
    };
}
