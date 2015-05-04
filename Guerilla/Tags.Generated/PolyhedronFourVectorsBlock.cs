// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PolyhedronFourVectorsBlock : PolyhedronFourVectorsBlockBase
    {
        public PolyhedronFourVectorsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 16)]
    public class PolyhedronFourVectorsBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 fourVectorsX;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 fourVectorsY;
        internal byte[] invalidName_0;
        internal OpenTK.Vector3 fourVectorsZ;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 48; } }
        public override int Alignment { get { return 16; } }
        public PolyhedronFourVectorsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            fourVectorsX = binaryReader.ReadVector3();
            invalidName_ = binaryReader.ReadBytes(4);
            fourVectorsY = binaryReader.ReadVector3();
            invalidName_0 = binaryReader.ReadBytes(4);
            fourVectorsZ = binaryReader.ReadVector3();
            invalidName_1 = binaryReader.ReadBytes(4);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fourVectorsX);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(fourVectorsY);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(fourVectorsZ);
                binaryWriter.Write(invalidName_1, 0, 4);
                return nextAddress;
            }
        }
    };
}
