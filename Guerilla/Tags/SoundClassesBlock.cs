using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("sncl")]
    public  partial class SoundClassesBlock : SoundClassesBlockBase
    {
        public  SoundClassesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class SoundClassesBlockBase
    {
        internal SoundClassBlock[] soundClasses;
        internal  SoundClassesBlockBase(BinaryReader binaryReader)
        {
            this.soundClasses = ReadSoundClassBlockArray(binaryReader);
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
        internal  virtual SoundClassBlock[] ReadSoundClassBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundClassBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundClassBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundClassBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
