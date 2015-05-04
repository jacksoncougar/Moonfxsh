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
    public partial class ItemPermutation : ItemPermutationBase
    {
        public ItemPermutation() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ItemPermutationBase : GuerillaBlock
    {
        /// <summary>
        /// relatively how likely this item will be chosen
        /// </summary>
        internal float weight;
        /// <summary>
        /// which item to 
        /// </summary>
        [TagReference("item")]
        internal Moonfish.Tags.TagReference item;
        internal Moonfish.Tags.StringIdent variantName;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ItemPermutationBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            weight = binaryReader.ReadSingle();
            item = binaryReader.ReadTagReference();
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
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weight);
                binaryWriter.Write(item);
                binaryWriter.Write(variantName);
                return nextAddress;
            }
        }
    };
}
