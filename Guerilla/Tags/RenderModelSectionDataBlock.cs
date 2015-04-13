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
    [LayoutAttribute(Size = 112)]
    public class RenderModelSectionDataBlockBase
    {
        internal GlobalGeometrySectionStructBlock section;
        internal GlobalGeometryPointDataStructBlock pointData;
        internal RenderModelNodeMapBlock[] nodeMap;
        internal byte[] invalidName_;
        internal  RenderModelSectionDataBlockBase(BinaryReader binaryReader)
        {
            this.section = new GlobalGeometrySectionStructBlock(binaryReader);
            this.pointData = new GlobalGeometryPointDataStructBlock(binaryReader);
            this.nodeMap = ReadRenderModelNodeMapBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual RenderModelNodeMapBlock[] ReadRenderModelNodeMapBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelNodeMapBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelNodeMapBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelNodeMapBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
