// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class VehiclePermutation : VehiclePermutationBase
    {
        public VehiclePermutation() : base()
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
        [TagReference("vehi")] internal Moonfish.Tags.TagReference vehicle;

        internal Moonfish.Tags.StringIdent variantName;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public VehiclePermutationBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            weight = binaryReader.ReadSingle();
            vehicle = binaryReader.ReadTagReference();
            variantName = binaryReader.ReadStringID();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weight);
                binaryWriter.Write(vehicle);
                binaryWriter.Write(variantName);
                return nextAddress;
            }
        }
    };
}