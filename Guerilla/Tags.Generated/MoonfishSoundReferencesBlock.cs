// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MoonfishSoundReferencesBlock : MoonfishSoundReferencesBlockBase
    {
        public  MoonfishSoundReferencesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MoonfishSoundReferencesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class MoonfishSoundReferencesBlockBase : GuerillaBlock
    {
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MoonfishSoundReferencesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sound = binaryReader.ReadTagReference();
        }
        public  MoonfishSoundReferencesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sound);
                return nextAddress;
            }
        }
    };
}
