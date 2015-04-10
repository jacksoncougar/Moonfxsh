using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("udlg")]
    public  partial class DialogueBlock : DialogueBlockBase
    {
        public  DialogueBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class DialogueBlockBase
    {
        [TagReference("adlg")]
        internal Moonfish.Tags.TagReference globalDialogueInfo;
        internal Flags flags;
        internal SoundReferencesBlock[] vocalizations;
        /// <summary>
        /// 3-letter missionDialogueDesignator name
        /// </summary>
        internal Moonfish.Tags.StringID missionDialogueDesignator;
        internal  DialogueBlockBase(BinaryReader binaryReader)
        {
            this.globalDialogueInfo = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.vocalizations = ReadSoundReferencesBlockArray(binaryReader);
            this.missionDialogueDesignator = binaryReader.ReadStringID();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual SoundReferencesBlock[] ReadSoundReferencesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundReferencesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundReferencesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundReferencesBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Female = 1,
        };
    };
}
