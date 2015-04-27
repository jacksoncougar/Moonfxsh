// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGestaltImportNamesBlock : SoundGestaltImportNamesBlockBase
    {
        public  oundGestaltImportNamesBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 4, Alignment = 4) ]
    public class SoundGestaltImportNamesBlockBase  GuerillaBlock
    {
        internal Moonfish.Tags.StringID importNam

          
       public override int SerializedS ize{get { return 4; }}
         
        internal  SoundGestaltImportNamesBlockBase(Binar yReader binar

        base(binaryReader )
        {
            importName = binaryReader.Re adStringID();
        }
          public override int Write( S ystem.IO.BinaryWriter binaryWriter, Int32 nextAddress )
         {
            using(binaryWriter.BaseStream.Pin())
            {
              binaryWriter.Write(importName);
                return nextAddress;
            }
        }
    };
}
