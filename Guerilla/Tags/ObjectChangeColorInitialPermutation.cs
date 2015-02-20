using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectChangeColorInitialPermutation : ObjectChangeColorInitialPermutationBase
    {
        public  ObjectChangeColorInitialPermutation(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class ObjectChangeColorInitialPermutationBase
    {
        internal float weight;
        internal Moonfish.Tags.ColorR8G8B8 colorLowerBound;
        internal Moonfish.Tags.ColorR8G8B8 colorUpperBound;
        /// <summary>
        /// if empty, may be used by any model variant
        /// </summary>
        internal Moonfish.Tags.StringID variantName;
        internal  ObjectChangeColorInitialPermutationBase(BinaryReader binaryReader)
        {
            this.weight = binaryReader.ReadSingle();
            this.colorLowerBound = binaryReader.ReadColorR8G8B8();
            this.colorUpperBound = binaryReader.ReadColorR8G8B8();
            this.variantName = binaryReader.ReadStringID();
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
    };
}
