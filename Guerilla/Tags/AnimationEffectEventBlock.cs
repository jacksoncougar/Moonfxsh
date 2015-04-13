// ReSharper disable All
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
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class AnimationEffectEventBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 effect;
        internal short frame;
        internal  AnimationEffectEventBlockBase(BinaryReader binaryReader)
        {
            effect = binaryReader.ReadShortBlockIndex1();
            frame = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(effect);
                binaryWriter.Write(frame);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
