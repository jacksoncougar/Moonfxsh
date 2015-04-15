// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectAttachmentBlock : ObjectAttachmentBlockBase
    {
        public  ObjectAttachmentBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ObjectAttachmentBlockBase  : IGuerilla
    {
        [TagReference("null")]
        internal Moonfish.Tags.TagReference type;
        internal Moonfish.Tags.StringID marker;
        internal ChangeColor changeColor;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID primaryScale;
        internal Moonfish.Tags.StringID secondaryScale;
        internal  ObjectAttachmentBlockBase(BinaryReader binaryReader)
        {
            type = binaryReader.ReadTagReference();
            marker = binaryReader.ReadStringID();
            changeColor = (ChangeColor)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            primaryScale = binaryReader.ReadStringID();
            secondaryScale = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(marker);
                binaryWriter.Write((Int16)changeColor);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(primaryScale);
                binaryWriter.Write(secondaryScale);
                return nextAddress;
            }
        }
        internal enum ChangeColor : short
        {
            None = 0,
            Primary = 1,
            Secondary = 2,
            Tertiary = 3,
            Quaternary = 4,
        };
    };
}
