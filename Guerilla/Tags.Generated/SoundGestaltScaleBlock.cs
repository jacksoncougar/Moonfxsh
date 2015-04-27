// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGestaltScaleBlock : SoundGestaltScaleBlockBase
    {
        public  SoundGestaltScaleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundGestaltScaleBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundGestaltScaleBlockBase : GuerillaBlock
    {
        internal SoundScaleModifiersStructBlock soundScaleModifiersStruct;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundGestaltScaleBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            soundScaleModifiersStruct = new SoundScaleModifiersStructBlock(binaryReader);
        }
        public  SoundGestaltScaleBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                soundScaleModifiersStruct.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
