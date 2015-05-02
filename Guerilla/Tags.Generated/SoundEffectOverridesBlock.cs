// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectOverridesBlock : SoundEffectOverridesBlockBase
    {
        public  SoundEffectOverridesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEffectOverridesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundEffectOverridesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal SoundEffectOverrideParametersBlock[] overrides;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEffectOverridesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            overrides = Guerilla.ReadBlockArray<SoundEffectOverrideParametersBlock>(binaryReader);
        }
        public  SoundEffectOverridesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            overrides = Guerilla.ReadBlockArray<SoundEffectOverrideParametersBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<SoundEffectOverrideParametersBlock>(binaryWriter, overrides, nextAddress);
                return nextAddress;
            }
        }
    };
}
