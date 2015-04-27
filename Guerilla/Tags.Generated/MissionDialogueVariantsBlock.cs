// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MissionDialogueVariantsBlock : MissionDialogueVariantsBlockBase
    {
        public  MissionDialogueVariantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MissionDialogueVariantsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MissionDialogueVariantsBlockBase : GuerillaBlock
    {
        /// <summary>
        /// 3-letter designation for the character^
        /// </summary>
        internal Moonfish.Tags.StringID variantDesignation;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal Moonfish.Tags.StringID soundEffect;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MissionDialogueVariantsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            variantDesignation = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
            soundEffect = binaryReader.ReadStringID();
        }
        public  MissionDialogueVariantsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            variantDesignation = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
            soundEffect = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(variantDesignation);
                binaryWriter.Write(sound);
                binaryWriter.Write(soundEffect);
                return nextAddress;
            }
        }
    };
}
