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
        public  AreasBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  AreasBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.areaFlags = (AreaFlags)binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(20);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.invalidName_1 = binaryReader.ReadBytes(64);
            this.manualReferenceFrame = binaryReader.ReadInt16();
            this.invalidName_2 = binaryReader.ReadBytes(2);
            this.flightHints = ReadFlightReferenceBlockArray(binaryReader);
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
        internal  virtual FlightReferenceBlock[] ReadFlightReferenceBlockArray(BinaryReader binaryReader)
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
        [FlagsAttribute]
        internal enum AreaFlags : int
        
        {
            VehicleArea = 1,
            Perch = 2,
            ManualReferenceFrame = 4,
        };
    };
}
