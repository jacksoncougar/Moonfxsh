// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AreasBlock : AreasBlockBase
    {
        public  AreasBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 136)]
    public class AreasBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal AreaFlags areaFlags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal short manualReferenceFrame;
        internal byte[] invalidName_2;
        internal FlightReferenceBlock[] flightHints;
        internal  AreasBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            areaFlags = (AreaFlags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(20);
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(64);
            manualReferenceFrame = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            ReadFlightReferenceBlockArray(binaryReader);
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
        internal  virtual FlightReferenceBlock[] ReadFlightReferenceBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FlightReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FlightReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FlightReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteFlightReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32)areaFlags);
                binaryWriter.Write(invalidName_, 0, 20);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(invalidName_1, 0, 64);
                binaryWriter.Write(manualReferenceFrame);
                binaryWriter.Write(invalidName_2, 0, 2);
                WriteFlightReferenceBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum AreaFlags : int
        
        {
            VehicleArea = 1,
            Perch = 2,
            ManualReferenceFrame = 4,
        };
    };
}
