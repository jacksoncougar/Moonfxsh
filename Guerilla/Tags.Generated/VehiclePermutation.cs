// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class VehiclePermutation : VehiclePermutationBase
    {
        public  VehiclePermutation(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  VehiclePermutation(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class VehiclePermutationBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  VehiclePermutationBase(BinaryReader binaryReader): base(binaryReader)
        {
            weight = binaryReader.ReadSingle();
            vehicle = binaryReader.ReadTagReference();
            variantName = binaryReader.ReadStringID();
        }
        public  VehiclePermutationBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            weight = binaryReader.ReadSingle();
            vehicle = binaryReader.ReadTagReference();
            variantName = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weight);
                binaryWriter.Write(vehicle);
                binaryWriter.Write(variantName);
                return nextAddress;
            }
        }
    };
}
