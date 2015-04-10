// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltExtraInfoBlock : SoundGestaltExtraInfoBlockBase
    {
        public  SoundGestaltExtraInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class SoundGestaltExtraInfoBlockBase
    {
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal  SoundGestaltExtraInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadSoundEncodedDialogueSectionBlockArray(binaryReader);
            geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual SoundEncodedDialogueSectionBlock[] ReadSoundEncodedDialogueSectionBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SoundEncodedDialogueSectionBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SoundEncodedDialogueSectionBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SoundEncodedDialogueSectionBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSoundEncodedDialogueSectionBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteSoundEncodedDialogueSectionBlockArray(binaryWriter);
                geometryBlockInfo.Write(binaryWriter);
            }
        }
    };
}
