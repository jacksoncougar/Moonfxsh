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
    [LayoutAttribute(Size = 20)]
    public class SoundScaleModifiersStructBlockBase
    {
        internal Moonfish.Model.Range gainModifierDB;
        internal int pitchModifierCents;
        internal OpenTK.Vector2 skipFractionModifier;
        internal  SoundScaleModifiersStructBlockBase(BinaryReader binaryReader)
        {
            this.gainModifierDB = binaryReader.ReadRange();
            this.pitchModifierCents = binaryReader.ReadInt32();
            this.skipFractionModifier = binaryReader.ReadVector2();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
