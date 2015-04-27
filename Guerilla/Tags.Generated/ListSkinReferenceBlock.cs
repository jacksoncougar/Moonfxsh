// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ListSkinReferenceBlock : ListSkinReferenceBlockBase
    {
        public  ListSkinReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ListSkinReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ListSkinReferenceBlockBase : GuerillaBlock
    {
        [TagReference("skin")]
        internal Moonfish.Tags.TagReference listItemSkins;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ListSkinReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            listItemSkins = binaryReader.ReadTagReference();
        }
        public  ListSkinReferenceBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            listItemSkins = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(listItemSkins);
                return nextAddress;
            }
        }
    };
}
