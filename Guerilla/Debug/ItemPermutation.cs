// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ItemPermutation : ItemPermutationBase
    {
        public  ItemPermutation(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ItemPermutationBase
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
        internal Moonfish.Tags.StringID variantName;
        internal  ItemPermutationBase(System.IO.BinaryReader binaryReader)
        {
            weight = binaryReader.ReadSingle();
            item = binaryReader.ReadTagReference();
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
                binaryWriter.Write(item);
                binaryWriter.Write(variantName);
            }
        }
    };
}
