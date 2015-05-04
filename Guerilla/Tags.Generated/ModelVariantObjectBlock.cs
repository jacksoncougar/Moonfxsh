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
    public partial class ModelVariantObjectBlock : ModelVariantObjectBlockBase
    {
        public ModelVariantObjectBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ModelVariantObjectBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent parentMarker;
        internal Moonfish.Tags.StringIdent childMarker;
        [TagReference("obje")]
        internal Moonfish.Tags.TagReference childObject;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ModelVariantObjectBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parentMarker = binaryReader.ReadStringID();
            childMarker = binaryReader.ReadStringID();
            childObject = binaryReader.ReadTagReference();
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
                binaryWriter.Write(parentMarker);
                binaryWriter.Write(childMarker);
                binaryWriter.Write(childObject);
                return nextAddress;
            }
        }
    };
}
