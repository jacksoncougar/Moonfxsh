// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundReferencesBlock : SoundReferencesBlockBase
    {
        public  SoundReferencesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundReferencesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundReferencesBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID vocalization;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundReferencesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            vocalization = binaryReader.ReadStringID();
            sound = binaryReader.ReadTagReference();
        }
        public  SoundReferencesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(vocalization);
                binaryWriter.Write(sound);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            NewVocalization = 1,
        };
    };
}
