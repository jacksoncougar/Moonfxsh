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
        public  ZoneBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ZoneBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            flags = (Flags)binaryReader.ReadInt32();
            manualBsp = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            ReadFiringPositionsBlockArray(binaryReader);
            ReadAreasBlockArray(binaryReader);
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
        internal  virtual FiringPositionsBlock[] ReadFiringPositionsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual AreasBlock[] ReadAreasBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteFiringPositionsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAreasBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(manualBsp);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteFiringPositionsBlockArray(binaryWriter);
                WriteAreasBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ManualBspIndex = 1,
        };
    };
}
