// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltPlaybackBlock : SoundGestaltPlaybackBlockBase
    {
        public  SoundGestaltPlaybackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class SoundGestaltPlaybackBlockBase  : IGuerilla
    {
        internal SoundPlaybackParametersStructBlock soundPlaybackParametersStruct;
        internal  SoundGestaltPlaybackBlockBase(BinaryReader binaryReader)
        {
            soundPlaybackParametersStruct = new SoundPlaybackParametersStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                soundPlaybackParametersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
