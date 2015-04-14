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
        public  AreasBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 136, Alignment = 4)]
    public class AreasBlockBase  : IGuerilla
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
            name = binaryReader.ReadString32();
            areaFlags = (AreaFlags)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(20);
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(64);
            manualReferenceFrame = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            flightHints = Guerilla.ReadBlockArray<FlightReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                nextAddress = Guerilla.WriteBlockArray<FlightReferenceBlock>(binaryWriter, flightHints, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
