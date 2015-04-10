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
        public  RenderModelSectionDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  RenderModelSectionDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            section = new GlobalGeometrySectionStructBlock(binaryReader);
            pointData = new GlobalGeometryPointDataStructBlock(binaryReader);
            ReadRenderModelNodeMapBlockArray(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual RenderModelNodeMapBlock[] ReadRenderModelNodeMapBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RenderModelNodeMapBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RenderModelNodeMapBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RenderModelNodeMapBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRenderModelNodeMapBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                section.Write(binaryWriter);
                pointData.Write(binaryWriter);
                WriteRenderModelNodeMapBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
            }
        }
    };
}
