// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class MouseCursorBitmapReferenceBlock : MouseCursorBitmapReferenceBlockBase
    {
        public  ouseCursorBitmapReferenceBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 8, Alignment = 4) ]
    public class MouseCursorBitmapReferenceBlockBase  GuerillaBlock
    {
        [TagReferenc e("bit m"   internal Moonfish.Tags.TagReference bitma

          
       public override int SerializedSize {get { return 8; }}
         
        internal  MouseCursorBitmapReferenceBlockBase(Binar yReader binar

        base(binaryReader )
        {
            bitmap = binaryReader.ReadTa gReference();
        }
          public override int Write( S ystem.IO.BinaryWriter binaryWriter, Int32 nextAddress )
         {
            using(binaryWriter.BaseStream.Pin())
            {
              binaryWriter.Write(bitmap);
                return nextAddress;
            }
        }
    };
}
