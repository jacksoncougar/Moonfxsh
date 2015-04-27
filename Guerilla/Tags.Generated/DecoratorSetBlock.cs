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
        public static readonly TagClass DECR = (TagClass)"DECR";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("DECR")]
    public partial class DecoratorSetBlock : DecoratorSetBlockBase
    {
        public  DecoratorSetBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DecoratorSetBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class DecoratorSetBlockBase : GuerillaBlock
    {
        internal DecoratorShaderReferenceBlock[] shaders;
        /// <summary>
        /// 0.0 defaults to 0.4
        /// </summary>
        internal float lightingMinScale;
        /// <summary>
        /// 0.0 defaults to 2.0
        /// </summary>
        internal float lightingMaxScale;
        internal DecoratorClassesBlock[] classes;
        internal DecoratorModelsBlock[] models;
        internal DecoratorModelVerticesBlock[] rawVertices;
        internal DecoratorModelIndicesBlock[] indices;
        internal CachedDataBlock[] cachedData;
        internal GlobalGeometryBlockInfoStructBlock geometrySectionInfo;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 108; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DecoratorSetBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            shaders = Guerilla.ReadBlockArray<DecoratorShaderReferenceBlock>(binaryReader);
            lightingMinScale = binaryReader.ReadSingle();
            lightingMaxScale = binaryReader.ReadSingle();
            classes = Guerilla.ReadBlockArray<DecoratorClassesBlock>(binaryReader);
            models = Guerilla.ReadBlockArray<DecoratorModelsBlock>(binaryReader);
            rawVertices = Guerilla.ReadBlockArray<DecoratorModelVerticesBlock>(binaryReader);
            indices = Guerilla.ReadBlockArray<DecoratorModelIndicesBlock>(binaryReader);
            cachedData = Guerilla.ReadBlockArray<CachedDataBlock>(binaryReader);
            geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(16);
        }
        public  DecoratorSetBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            shaders = Guerilla.ReadBlockArray<DecoratorShaderReferenceBlock>(binaryReader);
            lightingMinScale = binaryReader.ReadSingle();
            lightingMaxScale = binaryReader.ReadSingle();
            classes = Guerilla.ReadBlockArray<DecoratorClassesBlock>(binaryReader);
            models = Guerilla.ReadBlockArray<DecoratorModelsBlock>(binaryReader);
            rawVertices = Guerilla.ReadBlockArray<DecoratorModelVerticesBlock>(binaryReader);
            indices = Guerilla.ReadBlockArray<DecoratorModelIndicesBlock>(binaryReader);
            cachedData = Guerilla.ReadBlockArray<CachedDataBlock>(binaryReader);
            geometrySectionInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(16);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<DecoratorShaderReferenceBlock>(binaryWriter, shaders, nextAddress);
                binaryWriter.Write(lightingMinScale);
                binaryWriter.Write(lightingMaxScale);
                nextAddress = Guerilla.WriteBlockArray<DecoratorClassesBlock>(binaryWriter, classes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorModelsBlock>(binaryWriter, models, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorModelVerticesBlock>(binaryWriter, rawVertices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<DecoratorModelIndicesBlock>(binaryWriter, indices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CachedDataBlock>(binaryWriter, cachedData, nextAddress);
                geometrySectionInfo.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 16);
                return nextAddress;
            }
        }
    };
}
