// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ZoneBlock : ZoneBlockBase
    {
        public  ZoneBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ZoneBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class ZoneBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 manualBsp;
        internal byte[] invalidName_;
        internal FiringPositionsBlock[] firingPositions;
        internal AreasBlock[] areas;
        
        public override int SerializedSize{get { return 56; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ZoneBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            flags = (Flags)binaryReader.ReadInt32();
            manualBsp = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            firingPositions = Guerilla.ReadBlockArray<FiringPositionsBlock>(binaryReader);
            areas = Guerilla.ReadBlockArray<AreasBlock>(binaryReader);
        }
        public  ZoneBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            flags = (Flags)binaryReader.ReadInt32();
            manualBsp = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            firingPositions = Guerilla.ReadBlockArray<FiringPositionsBlock>(binaryReader);
            areas = Guerilla.ReadBlockArray<AreasBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(manualBsp);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<FiringPositionsBlock>(binaryWriter, firingPositions, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<AreasBlock>(binaryWriter, areas, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            ManualBspIndex = 1,
        };
    };
}
