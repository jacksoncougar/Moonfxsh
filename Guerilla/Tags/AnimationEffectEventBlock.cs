using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationEffectEventBlock : AnimationEffectEventBlockBase
    {
        public  AnimationEffectEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class AnimationEffectEventBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 effect;
        internal short frame;
        internal  AnimationEffectEventBlockBase(BinaryReader binaryReader)
        {
            this.effect = binaryReader.ReadShortBlockIndex1();
            this.frame = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
