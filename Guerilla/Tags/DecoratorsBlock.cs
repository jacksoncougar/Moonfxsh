// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass DECPClass = (TagClass)"DECP";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("DECP")]
    public  partial class DecoratorsBlock : DecoratorsBlockBase
    {
        public  DecoratorsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class DecoratorsBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 gridOrigin;
        internal int cellCountPerDimension;
        internal DecoratorCacheBlockBlock[] cacheBlocks;
        internal DecoratorGroupBlock[] groups;
        internal DecoratorCellCollectionBlock[] cells;
        internal DecoratorProjectedDecalBlock[] decals;
        internal  DecoratorsBlockBase(BinaryReader binaryReader)
        {
            gridOrigin = binaryReader.ReadVector3();
            cellCountPerDimension = binaryReader.ReadInt32();
            cacheBlocks = Guerilla.ReadBlockArray<DecoratorCacheBlockBlock>(binaryReader);
            groups = Guerilla.ReadBlockArray<DecoratorGroupBlock>(binaryReader);
            cells = Guerilla.ReadBlockArray<DecoratorCellCollectionBlock>(binaryReader);
            decals = Guerilla.ReadBlockArray<DecoratorProjectedDecalBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(gridOrigin);
                binaryWriter.Write(cellCountPerDimension);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCacheBlockBlock>(binaryWriter, cacheBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorGroupBlock>(binaryWriter, groups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCellCollectionBlock>(binaryWriter, cells, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorProjectedDecalBlock>(binaryWriter, decals, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
