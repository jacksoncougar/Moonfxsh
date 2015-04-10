// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalGeometryCompressionInfoBlock : GlobalGeometryCompressionInfoBlockBase
    {
        public  GlobalGeometryCompressionInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class GlobalGeometryCompressionInfoBlockBase
    {
        internal Moonfish.Model.Range positionBoundsX;
        internal Moonfish.Model.Range positionBoundsY;
        internal Moonfish.Model.Range positionBoundsZ;
        internal Moonfish.Model.Range texcoordBoundsX;
        internal Moonfish.Model.Range texcoordBoundsY;
        internal Moonfish.Model.Range secondaryTexcoordBoundsX;
        internal Moonfish.Model.Range secondaryTexcoordBoundsY;
        internal  GlobalGeometryCompressionInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            positionBoundsX = binaryReader.ReadRange();
            positionBoundsY = binaryReader.ReadRange();
            positionBoundsZ = binaryReader.ReadRange();
            texcoordBoundsX = binaryReader.ReadRange();
            texcoordBoundsY = binaryReader.ReadRange();
            secondaryTexcoordBoundsX = binaryReader.ReadRange();
            secondaryTexcoordBoundsY = binaryReader.ReadRange();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(positionBoundsX);
                binaryWriter.Write(positionBoundsY);
                binaryWriter.Write(positionBoundsZ);
                binaryWriter.Write(texcoordBoundsX);
                binaryWriter.Write(texcoordBoundsY);
                binaryWriter.Write(secondaryTexcoordBoundsX);
                binaryWriter.Write(secondaryTexcoordBoundsY);
            }
        }
    };
}
