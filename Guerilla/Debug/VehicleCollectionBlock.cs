// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("vehc")]
    public  partial class VehicleCollectionBlock : VehicleCollectionBlockBase
    {
        public  VehicleCollectionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class VehicleCollectionBlockBase
    {
        internal VehiclePermutation[] vehiclePermutations;
        internal short spawnTimeInSeconds0Default;
        internal byte[] invalidName_;
        internal  VehicleCollectionBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadVehiclePermutationArray(binaryReader);
            spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
        internal  virtual VehiclePermutation[] ReadVehiclePermutationArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(VehiclePermutation));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new VehiclePermutation[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new VehiclePermutation(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteVehiclePermutationArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteVehiclePermutationArray(binaryWriter);
                binaryWriter.Write(spawnTimeInSeconds0Default);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
    };
}
