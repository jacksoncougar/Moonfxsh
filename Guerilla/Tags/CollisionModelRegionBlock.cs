// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionModelRegionBlock : CollisionModelRegionBlockBase
    {
        public  CollisionModelRegionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CollisionModelRegionBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal CollisionModelPermutationBlock[] permutations;
        internal  CollisionModelRegionBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            permutations = Guerilla.ReadBlockArray<CollisionModelPermutationBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<CollisionModelPermutationBlock>(binaryWriter, permutations, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
