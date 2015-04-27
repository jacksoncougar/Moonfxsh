// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LocalBitmapReferenceBlock : LocalBitmapReferenceBlockBase
    {
        public  LocalBitmapReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LocalBitmapReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LocalBitmapReferenceBlockBase : GuerillaBlock
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LocalBitmapReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
        }
        public  LocalBitmapReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmap);
                return nextAddress;
            }
        }
    };
}
