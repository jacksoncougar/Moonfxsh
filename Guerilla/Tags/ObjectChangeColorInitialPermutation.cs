// ReSharper disable All
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
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ObjectChangeColorInitialPermutationBase  : IGuerilla
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
            weight = binaryReader.ReadSingle();
            colorLowerBound = binaryReader.ReadColorR8G8B8();
            colorUpperBound = binaryReader.ReadColorR8G8B8();
            variantName = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weight);
                binaryWriter.Write(colorLowerBound);
                binaryWriter.Write(colorUpperBound);
                binaryWriter.Write(variantName);
                return nextAddress;
            }
        }
    };
}
