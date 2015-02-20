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
    [LayoutAttribute(Size = 56)]
    public class ZoneBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 manualBsp;
        internal byte[] invalidName_;
        internal FiringPositionsBlock[] firingPositions;
        internal AreasBlock[] areas;
        internal  ZoneBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.manualBsp = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.firingPositions = ReadFiringPositionsBlockArray(binaryReader);
            this.areas = ReadAreasBlockArray(binaryReader);
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
        internal  virtual FiringPositionsBlock[] ReadFiringPositionsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FiringPositionsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FiringPositionsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FiringPositionsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual AreasBlock[] ReadAreasBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AreasBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AreasBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AreasBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ManualBspIndex = 1,
        };
    };
}
