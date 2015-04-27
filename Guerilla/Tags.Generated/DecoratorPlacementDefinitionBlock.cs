// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorPlacementDefinitionBlock : DecoratorPlacementDefinitionBlockBase
    {
        public  DecoratorPlacementDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DecoratorPlacementDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class DecoratorPlacementDefinitionBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 gridOrigin;
        internal int cellCountPerDimension;
        internal DecoratorCacheBlockBlock[] cacheBlocks;
        internal DecoratorGroupBlock[] groups;
        internal DecoratorCellCollectionBlock[] cells;
        internal DecoratorProjectedDecalBlock[] decals;
        
        public override int SerializedSize{get { return 48; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DecoratorPlacementDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            gridOrigin = binaryReader.ReadVector3();
            cellCountPerDimension = binaryReader.ReadInt32();
            cacheBlocks = Guerilla.ReadBlockArray<DecoratorCacheBlockBlock>(binaryReader);
            groups = Guerilla.ReadBlockArray<DecoratorGroupBlock>(binaryReader);
            cells = Guerilla.ReadBlockArray<DecoratorCellCollectionBlock>(binaryReader);
            decals = Guerilla.ReadBlockArray<DecoratorProjectedDecalBlock>(binaryReader);
        }
        public  DecoratorPlacementDefinitionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            gridOrigin = binaryReader.ReadVector3();
            cellCountPerDimension = binaryReader.ReadInt32();
            cacheBlocks = Guerilla.ReadBlockArray<DecoratorCacheBlockBlock>(binaryReader);
            groups = Guerilla.ReadBlockArray<DecoratorGroupBlock>(binaryReader);
            cells = Guerilla.ReadBlockArray<DecoratorCellCollectionBlock>(binaryReader);
            decals = Guerilla.ReadBlockArray<DecoratorProjectedDecalBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(gridOrigin);
                binaryWriter.Write(cellCountPerDimension);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCacheBlockBlock>(binaryWriter, cacheBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorGroupBlock>(binaryWriter, groups, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCellCollectionBlock>(binaryWriter, cells, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorProjectedDecalBlock>(binaryWriter, decals, nextAddress);
                return nextAddress;
            }
        }
    };
}
