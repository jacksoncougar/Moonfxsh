// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundEffectConstantBlock : PlatformSoundEffectConstantBlockBase
    {
        public  PlatformSoundEffectConstantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PlatformSoundEffectConstantBlockBase  : IGuerilla
    {
        internal float constantValue;
        internal  PlatformSoundEffectConstantBlockBase(BinaryReader binaryReader)
        {
            constantValue = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(constantValue);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
