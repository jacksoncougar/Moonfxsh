// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ZoneBlock : ZoneBlockBase
    {
        public  ZoneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ZoneBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 manualBsp;
        internal byte[] invalidName_;
        internal FiringPositionsBlock[] firingPositions;
        internal AreasBlock[] areas;
        internal  ZoneBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            flags = (Flags)binaryReader.ReadInt32();
            manualBsp = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            firingPositions = Guerilla.ReadBlockArray<FiringPositionsBlock>(binaryReader);
            areas = Guerilla.ReadBlockArray<AreasBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(manualBsp);
                binaryWriter.Write(invalidName_, 0, 2);
                Guerilla.WriteBlockArray<FiringPositionsBlock>(binaryWriter, firingPositions, nextAddress);
                Guerilla.WriteBlockArray<AreasBlock>(binaryWriter, areas, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            ManualBspIndex = 1,
        };
    };
}
