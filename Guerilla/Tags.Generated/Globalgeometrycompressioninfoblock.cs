// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometryCompressionInfoBlock : GlobalGeometryCompressionInfoBlockBase
    {
        public GlobalGeometryCompressionInfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class GlobalGeometryCompressionInfoBlockBase : GuerillaBlock
    {
        internal Moonfish.Model.Range positionBoundsX;
        internal Moonfish.Model.Range positionBoundsY;
        internal Moonfish.Model.Range positionBoundsZ;
        internal Moonfish.Model.Range texcoordBoundsX;
        internal Moonfish.Model.Range texcoordBoundsY;
        internal Moonfish.Model.Range secondaryTexcoordBoundsX;
        internal Moonfish.Model.Range secondaryTexcoordBoundsY;

        public override int SerializedSize
        {
            get { return 56; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalGeometryCompressionInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            positionBoundsX = binaryReader.ReadRange();
            positionBoundsY = binaryReader.ReadRange();
            positionBoundsZ = binaryReader.ReadRange();
            texcoordBoundsX = binaryReader.ReadRange();
            texcoordBoundsY = binaryReader.ReadRange();
            secondaryTexcoordBoundsX = binaryReader.ReadRange();
            secondaryTexcoordBoundsY = binaryReader.ReadRange();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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