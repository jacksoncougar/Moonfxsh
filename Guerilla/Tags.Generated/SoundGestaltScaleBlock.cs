// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltScaleBlock : SoundGestaltScaleBlockBase
    {
        public  SoundGestaltScaleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundGestaltScaleBlockBase  : IGuerilla
    {
        internal SoundScaleModifiersStructBlock soundScaleModifiersStruct;
        internal  SoundGestaltScaleBlockBase(BinaryReader binaryReader)
        {
            soundScaleModifiersStruct = new SoundScaleModifiersStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                soundScaleModifiersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}