// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationSoundEventBlock : AnimationSoundEventBlockBase
    {
        public  AnimationSoundEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationSoundEventBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationSoundEventBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 sound;
        internal short frame;
        internal Moonfish.Tags.StringIdent markerName;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationSoundEventBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            sound = binaryReader.ReadShortBlockIndex1();
            frame = binaryReader.ReadInt16();
            markerName = binaryReader.ReadStringID();
        }
        public  AnimationSoundEventBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            sound = binaryReader.ReadShortBlockIndex1();
            frame = binaryReader.ReadInt16();
            markerName = binaryReader.ReadStringID();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sound);
                binaryWriter.Write(frame);
                binaryWriter.Write(markerName);
                return nextAddress;
            }
        }
    };
}
