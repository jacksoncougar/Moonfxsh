// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundScaleModifiersStructBlock : SoundScaleModifiersStructBlockBase
    {
        public  SoundScaleModifiersStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundScaleModifiersStructBlockBase  : IGuerilla
    {
        internal Moonfish.Model.Range gainModifierDB;
        internal int pitchModifierCents;
        internal OpenTK.Vector2 skipFractionModifier;
        internal  SoundScaleModifiersStructBlockBase(BinaryReader binaryReader)
        {
            gainModifierDB = binaryReader.ReadRange();
            pitchModifierCents = binaryReader.ReadInt32();
            skipFractionModifier = binaryReader.ReadVector2();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(gainModifierDB);
                binaryWriter.Write(pitchModifierCents);
                binaryWriter.Write(skipFractionModifier);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
