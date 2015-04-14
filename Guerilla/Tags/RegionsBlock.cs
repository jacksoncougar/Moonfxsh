// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RegionsBlock : RegionsBlockBase
    {
        public  RegionsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class RegionsBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal PermutationsBlock[] permutations;
        internal  RegionsBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            permutations = Guerilla.ReadBlockArray<PermutationsBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                Guerilla.WriteBlockArray<PermutationsBlock>(binaryWriter, permutations, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
