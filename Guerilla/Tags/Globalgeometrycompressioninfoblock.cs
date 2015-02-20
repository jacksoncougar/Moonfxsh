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
        internal  GlobalGeometryCompressionInfoBlockBase(BinaryReader binaryReader)
        {
            this.positionBoundsX = binaryReader.ReadRange();
            this.positionBoundsY = binaryReader.ReadRange();
            this.positionBoundsZ = binaryReader.ReadRange();
            this.texcoordBoundsX = binaryReader.ReadRange();
            this.texcoordBoundsY = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsX = binaryReader.ReadRange();
            this.secondaryTexcoordBoundsY = binaryReader.ReadRange();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
