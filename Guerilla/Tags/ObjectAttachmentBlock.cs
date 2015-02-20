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
    [LayoutAttribute(Size = 24)]
    public class ObjectAttachmentBlockBase
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
            this.type = binaryReader.ReadTagReference();
            this.marker = binaryReader.ReadStringID();
            this.changeColor = (ChangeColor)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.primaryScale = binaryReader.ReadStringID();
            this.secondaryScale = binaryReader.ReadStringID();
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
