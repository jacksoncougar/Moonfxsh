// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SectorBlock : SectorBlockBase
    {
        public  SectorBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SectorBlockBase  : IGuerilla
    {
        internal PathFindingSectorFlags pathFindingSectorFlags;
        internal short hintIndex;
        internal int firstLinkDoNotSetManually;
        internal  SectorBlockBase(BinaryReader binaryReader)
        {
            pathFindingSectorFlags = (PathFindingSectorFlags)binaryReader.ReadInt16();
            hintIndex = binaryReader.ReadInt16();
            firstLinkDoNotSetManually = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)pathFindingSectorFlags);
                binaryWriter.Write(hintIndex);
                binaryWriter.Write(firstLinkDoNotSetManually);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum PathFindingSectorFlags : short
        {
            SectorWalkable = 1,
            SectorBreakable = 2,
            SectorMobile = 4,
            SectorBspSource = 8,
            Floor = 16,
            Ceiling = 32,
            WallNorth = 64,
            WallSouth = 128,
            WallEast = 256,
            WallWest = 512,
            Crouchable = 1024,
            Aligned = 2048,
            SectorStep = 4096,
            SectorInterior = 8192,
        };
    };
}
