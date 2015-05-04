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
    public partial class ObjectChangeColorInitialPermutation : ObjectChangeColorInitialPermutationBase
    {
        public ObjectChangeColorInitialPermutation() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ObjectChangeColorInitialPermutationBase : GuerillaBlock
    {
        internal float weight;
        internal Moonfish.Tags.ColourR8G8B8 colorLowerBound;
        internal Moonfish.Tags.ColourR8G8B8 colorUpperBound;
        /// <summary>
        /// if empty, may be used by any model variant
        /// </summary>
        internal Moonfish.Tags.StringIdent variantName;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public ObjectChangeColorInitialPermutationBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            weight = binaryReader.ReadSingle();
            colorLowerBound = binaryReader.ReadColorR8G8B8();
            colorUpperBound = binaryReader.ReadColorR8G8B8();
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
                binaryWriter.Write(colorLowerBound);
                binaryWriter.Write(colorUpperBound);
                binaryWriter.Write(variantName);
                return nextAddress;
            }
        }
    };
}
