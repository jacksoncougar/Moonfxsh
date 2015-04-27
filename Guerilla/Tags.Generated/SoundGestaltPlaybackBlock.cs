// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltPlaybackBlock : SoundGestaltPlaybackBlockBase
    {
        public  SoundGestaltPlaybackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltPlaybackBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class SoundGestaltPlaybackBlockBase : GuerillaBlock
    {
        internal SoundPlaybackParametersStructBlock soundPlaybackParametersStruct;
        
        public override int SerializedSize{get { return 56; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltPlaybackBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            soundPlaybackParametersStruct = new SoundPlaybackParametersStructBlock(binaryReader);
        }
        public  SoundGestaltPlaybackBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            soundPlaybackParametersStruct = new SoundPlaybackParametersStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                soundPlaybackParametersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
