// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundScaleModifiersStructBlock : SoundScaleModifiersStructBlockBase
    {
        public  SoundScaleModifiersStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundScaleModifiersStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundScaleModifiersStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Model.Range gainModifierDB;
        internal int pitchModifierCents;
        internal OpenTK.Vector2 skipFractionModifier;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundScaleModifiersStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            gainModifierDB = binaryReader.ReadRange();
            pitchModifierCents = binaryReader.ReadInt32();
            skipFractionModifier = binaryReader.ReadVector2();
        }
        public  SoundScaleModifiersStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(gainModifierDB);
                binaryWriter.Write(pitchModifierCents);
                binaryWriter.Write(skipFractionModifier);
                return nextAddress;
            }
        }
    };
}
