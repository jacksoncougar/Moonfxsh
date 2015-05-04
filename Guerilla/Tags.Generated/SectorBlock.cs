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
    public partial class SectorBlock : SectorBlockBase
    {
        public SectorBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class SectorBlockBase : GuerillaBlock
    {
        internal PathFindingSectorFlags pathFindingSectorFlags;
        internal short hintIndex;
        internal int firstLinkDoNotSetManually;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public SectorBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            pathFindingSectorFlags = (PathFindingSectorFlags)binaryReader.ReadInt16();
            hintIndex = binaryReader.ReadInt16();
            firstLinkDoNotSetManually = binaryReader.ReadInt32();
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
