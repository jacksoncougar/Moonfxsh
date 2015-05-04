// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Vrtx = (TagClass)"vrtx";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("vrtx")]
    public partial class VertexShaderBlock : VertexShaderBlockBase
    {
        public VertexShaderBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class VertexShaderBlockBase : GuerillaBlock
    {
        internal Platform platform;
        internal byte[] invalidName_;
        internal VertexShaderClassificationBlock[] geometryClassifications;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public VertexShaderBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            platform = (Platform)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<VertexShaderClassificationBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            geometryClassifications = ReadBlockArrayData<VertexShaderClassificationBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)platform);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<VertexShaderClassificationBlock>(binaryWriter, geometryClassifications, nextAddress);
                return nextAddress;
            }
        }
        internal enum Platform : short
        {
            Pc = 0,
            Xbox = 1,
        };
    };
}
