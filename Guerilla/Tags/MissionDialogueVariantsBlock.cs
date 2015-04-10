using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MissionDialogueVariantsBlock : MissionDialogueVariantsBlockBase
    {
        public  MissionDialogueVariantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class MissionDialogueVariantsBlockBase
    {
        /// <summary>
        /// 3-letter designation for the character^
        /// </summary>
        internal Moonfish.Tags.StringID variantDesignation;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal Moonfish.Tags.StringID soundEffect;
        internal  MissionDialogueVariantsBlockBase(BinaryReader binaryReader)
        {
            this.variantDesignation = binaryReader.ReadStringID();
            this.sound = binaryReader.ReadTagReference();
            this.soundEffect = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
