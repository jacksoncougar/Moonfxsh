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
        public static readonly TagClass Clwd = (TagClass)"clwd";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("clwd")]
    public partial class ClothBlock : ClothBlockBase
    {
        public ClothBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class ClothBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Moonfish.Tags.StringIdent markerAttachmentName;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal short gridXDimension;
        internal short gridYDimension;
        internal float gridSpacingX;
        internal float gridSpacingY;
        internal ClothPropertiesBlock properties;
        internal ClothVerticesBlock[] vertices;
        internal ClothIndicesBlock[] indices;
        internal ClothIndicesBlock[] stripIndices;
        internal ClothLinksBlock[] links;
        public override int SerializedSize { get { return 108; } }
        public override int Alignment { get { return 4; } }
        public ClothBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            markerAttachmentName = binaryReader.ReadStringID();
            shader = binaryReader.ReadTagReference();
            gridXDimension = binaryReader.ReadInt16();
            gridYDimension = binaryReader.ReadInt16();
            gridSpacingX = binaryReader.ReadSingle();
            gridSpacingY = binaryReader.ReadSingle();
            properties = new ClothPropertiesBlock();
            blamPointers.Concat(properties.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ClothVerticesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ClothIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ClothIndicesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ClothLinksBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            properties.ReadPointers(binaryReader, blamPointers);
            vertices = ReadBlockArrayData<ClothVerticesBlock>(binaryReader, blamPointers.Dequeue());
            indices = ReadBlockArrayData<ClothIndicesBlock>(binaryReader, blamPointers.Dequeue());
            stripIndices = ReadBlockArrayData<ClothIndicesBlock>(binaryReader, blamPointers.Dequeue());
            links = ReadBlockArrayData<ClothLinksBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(markerAttachmentName);
                binaryWriter.Write(shader);
                binaryWriter.Write(gridXDimension);
                binaryWriter.Write(gridYDimension);
                binaryWriter.Write(gridSpacingX);
                binaryWriter.Write(gridSpacingY);
                properties.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<ClothVerticesBlock>(binaryWriter, vertices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ClothIndicesBlock>(binaryWriter, indices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ClothIndicesBlock>(binaryWriter, stripIndices, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ClothLinksBlock>(binaryWriter, links, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            DoesntUseWind = 1,
            UsesGridAttachTop = 2,
        };
    };
}
