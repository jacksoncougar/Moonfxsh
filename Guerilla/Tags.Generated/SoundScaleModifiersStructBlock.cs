// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundScaleModifiersStructBlock : SoundScaleModifiersStructBlockBase
    {
        public  oundScaleModifiersStructBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 20, Alignment = 4) ]
    public class SoundScaleModifiersStructBlockBase  GuerillaBlock
    {
        internal Moonfish.Model.Range gainModifierDB;
        internal int pitchModifierCents;
        internal OpenTK.Vector2 skipFractionModifie

          
       public override int SerializedSiz e{get { return 20; }}
         
        internal  SoundScaleModifiersStructBlockBase(Binar yReader binaryReader): base(binaryReader)
        {
             gainModifierDB = binaryReader.ReadRange();
            pi tchModifierCe

        ryReader.ReadInt3 2();
            skipFractionModifier = binaryReader. ReadVector2();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
        { 
            using(binaryWriter.BaseStr eam.Pin())
             {
                binaryWriter.W rite(gainModifierDB) ;
                binaryWriter.Write(pitchModifierCents);
                naryWriter.Write(skipFractionModifier);
                return nextAddress;
            }
        }
    };
}
