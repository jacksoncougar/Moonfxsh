// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundReferencesBlock : SoundReferencesBlockBase
    {
        public  SoundReferencesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundReferencesBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID vocalization;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal  SoundReferencesBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            vocalization = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(vocalization);
                binaryWriter.Write(sound);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            NewVocalization = 1,
        };
    };
}
