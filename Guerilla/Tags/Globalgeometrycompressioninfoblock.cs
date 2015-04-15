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
        public  GlobalGeometryCompressionInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class GlobalGeometryCompressionInfoBlockBase  : IGuerilla
    {
        internal Moonfish.Model.Range positionBoundsX;
        internal Moonfish.Model.Range positionBoundsY;
        internal Moonfish.Model.Range positionBoundsZ;
        internal Moonfish.Model.Range texcoordBoundsX;
        internal Moonfish.Model.Range texcoordBoundsY;
        internal Moonfish.Model.Range secondaryTexcoordBoundsX;
        internal Moonfish.Model.Range secondaryTexcoordBoundsY;
        internal  GlobalGeometryCompressionInfoBlockBase(BinaryReader binaryReader)
        {
            positionBoundsX = binaryReader.ReadRange();
            positionBoundsY = binaryReader.ReadRange();
            positionBoundsZ = binaryReader.ReadRange();
            texcoordBoundsX = binaryReader.ReadRange();
            texcoordBoundsY = binaryReader.ReadRange();
            secondaryTexcoordBoundsX = binaryReader.ReadRange();
            secondaryTexcoordBoundsY = binaryReader.ReadRange();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress;
            }
        }
    };
}
