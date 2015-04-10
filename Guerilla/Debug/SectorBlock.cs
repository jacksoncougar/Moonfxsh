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
        public  SectorBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class SectorBlockBase
    {
        internal PathFindingSectorFlags pathFindingSectorFlags;
        internal short hintIndex;
        internal int firstLinkDoNotSetManually;
        internal  SectorBlockBase(System.IO.BinaryReader binaryReader)
        {
            pathFindingSectorFlags = (PathFindingSectorFlags)binaryReader.ReadInt16();
            hintIndex = binaryReader.ReadInt16();
            firstLinkDoNotSetManually = binaryReader.ReadInt32();
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
                binaryWriter.Write((Int16)pathFindingSectorFlags);
                binaryWriter.Write(hintIndex);
                binaryWriter.Write(firstLinkDoNotSetManually);
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
