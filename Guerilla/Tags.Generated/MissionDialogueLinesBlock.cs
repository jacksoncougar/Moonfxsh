// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MissionDialogueLinesBlock : MissionDialogueLinesBlockBase
    {
        public  MissionDialogueLinesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MissionDialogueLinesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MissionDialogueLinesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal MissionDialogueVariantsBlock[] variants;
        internal Moonfish.Tags.StringIdent defaultSoundEffect;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MissionDialogueLinesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            variants = Guerilla.ReadBlockArray<MissionDialogueVariantsBlock>(binaryReader);
            defaultSoundEffect = binaryReader.ReadStringID();
        }
        public  MissionDialogueLinesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            variants = Guerilla.ReadBlockArray<MissionDialogueVariantsBlock>(binaryReader);
            defaultSoundEffect = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<MissionDialogueVariantsBlock>(binaryWriter, variants, nextAddress);
                binaryWriter.Write(defaultSoundEffect);
                return nextAddress;
            }
        }
    };
}
