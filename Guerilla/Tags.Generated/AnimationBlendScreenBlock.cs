// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationBlendScreenBlock : AnimationBlendScreenBlockBase
    {
        public  AnimationBlendScreenBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationBlendScreenBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class AnimationBlendScreenBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal AnimationAimingScreenStructBlock aimingScreen;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationBlendScreenBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            label = binaryReader.ReadStringID();
            aimingScreen = new AnimationAimingScreenStructBlock(binaryReader);
        }
        public  AnimationBlendScreenBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            aimingScreen = new AnimationAimingScreenStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                aimingScreen.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
