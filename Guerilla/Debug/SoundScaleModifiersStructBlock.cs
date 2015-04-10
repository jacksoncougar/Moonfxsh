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
        public  SoundScaleModifiersStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class SoundScaleModifiersStructBlockBase
    {
        internal Moonfish.Model.Range gainModifierDB;
        internal int pitchModifierCents;
        internal OpenTK.Vector2 skipFractionModifier;
        internal  SoundScaleModifiersStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            gainModifierDB = binaryReader.ReadRange();
            pitchModifierCents = binaryReader.ReadInt32();
            skipFractionModifier = binaryReader.ReadVector2();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(gainModifierDB);
                binaryWriter.Write(pitchModifierCents);
                binaryWriter.Write(skipFractionModifier);
            }
        }
    };
}
