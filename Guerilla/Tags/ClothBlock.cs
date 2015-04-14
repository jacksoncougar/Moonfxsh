// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass ClwdClass = (TagClass)"clwd";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("clwd")]
    public  partial class ClothBlock : ClothBlockBase
    {
        public  ClothBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 108, Alignment = 4)]
    public class ClothBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal Moonfish.Tags.StringID markerAttachmentName;
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
        internal  ClothBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            markerAttachmentName = binaryReader.ReadStringID();
            shader = binaryReader.ReadTagReference();
            gridXDimension = binaryReader.ReadInt16();
            gridYDimension = binaryReader.ReadInt16();
            gridSpacingX = binaryReader.ReadSingle();
            gridSpacingY = binaryReader.ReadSingle();
            properties = new ClothPropertiesBlock(binaryReader);
            vertices = Guerilla.ReadBlockArray<ClothVerticesBlock>(binaryReader);
            indices = Guerilla.ReadBlockArray<ClothIndicesBlock>(binaryReader);
            stripIndices = Guerilla.ReadBlockArray<ClothIndicesBlock>(binaryReader);
            links = Guerilla.ReadBlockArray<ClothLinksBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
                Guerilla.WriteBlockArray<ClothVerticesBlock>(binaryWriter, vertices, nextAddress);
                Guerilla.WriteBlockArray<ClothIndicesBlock>(binaryWriter, indices, nextAddress);
                Guerilla.WriteBlockArray<ClothIndicesBlock>(binaryWriter, stripIndices, nextAddress);
                Guerilla.WriteBlockArray<ClothLinksBlock>(binaryWriter, links, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
