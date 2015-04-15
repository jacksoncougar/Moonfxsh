// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationBlendScreenBlock : AnimationBlendScreenBlockBase
    {
        public  AnimationBlendScreenBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class AnimationBlendScreenBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationAimingScreenStructBlock aimingScreen;
        internal  AnimationBlendScreenBlockBase(BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            aimingScreen = new AnimationAimingScreenStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
