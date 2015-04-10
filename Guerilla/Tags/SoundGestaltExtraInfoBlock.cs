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
        public  SoundGestaltExtraInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class SoundGestaltExtraInfoBlockBase
    {
        internal SoundEncodedDialogueSectionBlock[] encodedPermutationSection;
        internal GlobalGeometryBlockInfoStructBlock geometryBlockInfo;
        internal  SoundGestaltExtraInfoBlockBase(BinaryReader binaryReader)
        {
            this.encodedPermutationSection = ReadSoundEncodedDialogueSectionBlockArray(binaryReader);
            this.geometryBlockInfo = new GlobalGeometryBlockInfoStructBlock(binaryReader);
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
        internal  virtual SoundEncodedDialogueSectionBlock[] ReadSoundEncodedDialogueSectionBlockArray(BinaryReader binaryReader)
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
    };
}