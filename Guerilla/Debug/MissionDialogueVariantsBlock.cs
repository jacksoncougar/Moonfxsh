// ReSharper disable All
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
        public  MissionDialogueVariantsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  MissionDialogueVariantsBlockBase(System.IO.BinaryReader binaryReader)
        {
            variantDesignation = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
            soundEffect = binaryReader.ReadStringID();
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
                binaryWriter.Write(variantDesignation);
                binaryWriter.Write(sound);
                binaryWriter.Write(soundEffect);
            }
        }
    };
}
