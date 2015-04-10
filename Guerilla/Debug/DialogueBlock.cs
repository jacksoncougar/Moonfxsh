// ReSharper disable All
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
        public  DialogueBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DialogueBlockBase(System.IO.BinaryReader binaryReader)
        {
            globalDialogueInfo = binaryReader.ReadTagReference();
            flags = (Flags)binaryReader.ReadInt32();
            ReadSoundReferencesBlockArray(binaryReader);
            missionDialogueDesignator = binaryReader.ReadStringID();
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
        internal  virtual SoundReferencesBlock[] ReadSoundReferencesBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundReferencesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundReferencesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundReferencesBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundReferencesBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(globalDialogueInfo);
                binaryWriter.Write((Int32)flags);
                WriteSoundReferencesBlockArray(binaryWriter);
                binaryWriter.Write(missionDialogueDesignator);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Female = 1,
        };
    };
}
