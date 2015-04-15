// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterBossBlock : CharacterBossBlockBase
    {
        public  CharacterBossBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CharacterBossBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        /// <summary>
        /// when more than x damage is caused a juggernaut flurry is triggered
        /// </summary>
        internal float flurryDamageThreshold01;
        /// <summary>
        /// flurry lasts this long
        /// </summary>
        internal float flurryTimeSeconds;
        internal  CharacterBossBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            flurryDamageThreshold01 = binaryReader.ReadSingle();
            flurryTimeSeconds = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(flurryDamageThreshold01);
                binaryWriter.Write(flurryTimeSeconds);
                return nextAddress;
            }
        }
    };
}
