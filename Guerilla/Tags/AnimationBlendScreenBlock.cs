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
    [LayoutAttribute(Size = 28)]
    public class AnimationBlendScreenBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationAimingScreenStructBlock aimingScreen;
        internal  AnimationBlendScreenBlockBase(BinaryReader binaryReader)
        {
            this.label = binaryReader.ReadStringID();
            this.aimingScreen = new AnimationAimingScreenStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
