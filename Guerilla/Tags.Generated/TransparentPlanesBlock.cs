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
    public partial class TransparentPlanesBlock : TransparentPlanesBlockBase
    {
        public TransparentPlanesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class TransparentPlanesBlockBase : GuerillaBlock
    {
        internal short sectionIndex;
        internal short partIndex;
        internal OpenTK.Vector4 plane;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public TransparentPlanesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sectionIndex = binaryReader.ReadInt16();
            partIndex = binaryReader.ReadInt16();
            plane = binaryReader.ReadVector4();
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
                binaryWriter.Write(sectionIndex);
                binaryWriter.Write(partIndex);
                binaryWriter.Write(plane);
                return nextAddress;
            }
        }
    };
}
