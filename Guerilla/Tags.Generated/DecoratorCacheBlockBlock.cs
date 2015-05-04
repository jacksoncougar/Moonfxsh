// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DecoratorCacheBlockBlock : DecoratorCacheBlockBlockBase
    {
        public  DecoratorCacheBlockBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DecoratorCacheBlockBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class DecoratorCacheBlockBlockBase : GuerillaBlock
    {
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal DecoratorCacheBlockDataBlock[] cacheBlockData;
        
        public override int SerializedSize{get { return 44; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DecoratorCacheBlockBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            cacheBlockData = Guerilla.ReadBlockArray<DecoratorCacheBlockDataBlock>(binaryReader);
        }
        public  DecoratorCacheBlockBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            cacheBlockData = Guerilla.ReadBlockArray<DecoratorCacheBlockDataBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                geometryBlockInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<DecoratorCacheBlockDataBlock>(binaryWriter, cacheBlockData, nextAddress);
                return nextAddress;
            }
        }
    };
}
