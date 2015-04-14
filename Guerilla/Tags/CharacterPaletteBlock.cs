// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterPaletteBlock : CharacterPaletteBlockBase
    {
        public  CharacterPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class CharacterPaletteBlockBase  : IGuerilla
    {
        [TagReference("char")]
        internal Moonfish.Tags.TagReference reference;
        internal  CharacterPaletteBlockBase(BinaryReader binaryReader)
        {
            reference = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(reference);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
