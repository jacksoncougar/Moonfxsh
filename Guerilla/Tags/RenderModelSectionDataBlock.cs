// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelSectionDataBlock : RenderModelSectionDataBlockBase
    {
        public  RenderModelSectionDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 112, Alignment = 4)]
    public class RenderModelSectionDataBlockBase  : IGuerilla
    {
        internal GlobalGeometrySectionStructBlock section;
        internal GlobalGeometryPointDataStructBlock pointData;
        internal RenderModelNodeMapBlock[] nodeMap;
        internal byte[] invalidName_;
        internal  RenderModelSectionDataBlockBase(BinaryReader binaryReader)
        {
            section = new GlobalGeometrySectionStructBlock(binaryReader);
            pointData = new GlobalGeometryPointDataStructBlock(binaryReader);
            nodeMap = Guerilla.ReadBlockArray<RenderModelNodeMapBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                section.Write(binaryWriter);
                pointData.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<RenderModelNodeMapBlock>(binaryWriter, nodeMap, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}
