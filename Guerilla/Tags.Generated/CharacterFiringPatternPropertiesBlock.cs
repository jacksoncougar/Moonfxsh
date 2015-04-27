// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterFiringPatternPropertiesBlock : CharacterFiringPatternPropertiesBlockBase
    {
        public  CharacterFiringPatternPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class CharacterFiringPatternPropertiesBlockBase : GuerillaBlock
    {
        [TagReference("weap")]
        internal Moonfish.Tags.TagReference weapon;
        internal CharacterFiringPatternBlock[] firingPatterns;
        
        public override int SerializedSize{get { return 16; }}
        
        internal  CharacterFiringPatternPropertiesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            weapon = binaryReader.ReadTagReference();
            firingPatterns = Guerilla.ReadBlockArray<CharacterFiringPatternBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(weapon);
                nextAddress = Guerilla.WriteBlockArray<CharacterFiringPatternBlock>(binaryWriter, firingPatterns, nextAddress);
                return nextAddress;
            }
        }
    };
}
