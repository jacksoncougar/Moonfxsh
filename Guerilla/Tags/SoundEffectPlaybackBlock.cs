// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectPlaybackBlock : SoundEffectPlaybackBlockBase
    {
        public  SoundEffectPlaybackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundEffectPlaybackBlockBase  : IGuerilla
    {
        internal SoundEffectStructDefinitionBlock soundEffectStruct;
        internal  SoundEffectPlaybackBlockBase(BinaryReader binaryReader)
        {
            soundEffectStruct = new SoundEffectStructDefinitionBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                soundEffectStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
