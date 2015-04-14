// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass VehcClass = (TagClass)"vehc";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("vehc")]
    public  partial class VehicleCollectionBlock : VehicleCollectionBlockBase
    {
        public  VehicleCollectionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class VehicleCollectionBlockBase  : IGuerilla
    {
        internal VehiclePermutation[] vehiclePermutations;
        internal short spawnTimeInSeconds0Default;
        internal byte[] invalidName_;
        internal  VehicleCollectionBlockBase(BinaryReader binaryReader)
        {
            vehiclePermutations = Guerilla.ReadBlockArray<VehiclePermutation>(binaryReader);
            spawnTimeInSeconds0Default = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<VehiclePermutation>(binaryWriter, vehiclePermutations, nextAddress);
                binaryWriter.Write(spawnTimeInSeconds0Default);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
