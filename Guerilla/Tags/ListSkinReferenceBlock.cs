// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ListSkinReferenceBlock : ListSkinReferenceBlockBase
    {
        public  ListSkinReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ListSkinReferenceBlockBase  : IGuerilla
    {
        [TagReference("skin")]
        internal Moonfish.Tags.TagReference listItemSkins;
        internal  ListSkinReferenceBlockBase(BinaryReader binaryReader)
        {
            listItemSkins = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(listItemSkins);
                return nextAddress;
            }
        }
    };
}
