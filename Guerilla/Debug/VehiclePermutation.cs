// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VehiclePermutation : VehiclePermutationBase
    {
        public  VehiclePermutation(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class VehiclePermutationBase
    {
        /// <summary>
        /// relatively how likely this vehicle will be chosen
        /// </summary>
        internal float weight;
        /// <summary>
        /// which vehicle to
        /// </summary>
        [TagReference("vehi")]
        internal Moonfish.Tags.TagReference vehicle;
        internal Moonfish.Tags.StringID variantName;
        internal  VehiclePermutationBase(System.IO.BinaryReader binaryReader)
        {
            weight = binaryReader.ReadSingle();
            vehicle = binaryReader.ReadTagReference();
            variantName = binaryReader.ReadStringID();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weight);
                binaryWriter.Write(vehicle);
                binaryWriter.Write(variantName);
            }
        }
    };
}
