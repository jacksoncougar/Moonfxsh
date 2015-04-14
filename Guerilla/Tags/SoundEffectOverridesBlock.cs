// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectOverridesBlock : SoundEffectOverridesBlockBase
    {
        public  SoundEffectOverridesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundEffectOverridesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal SoundEffectOverrideParametersBlock[] overrides;
        internal  SoundEffectOverridesBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            overrides = Guerilla.ReadBlockArray<SoundEffectOverrideParametersBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectOverrideParametersBlock>(binaryWriter, overrides, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
