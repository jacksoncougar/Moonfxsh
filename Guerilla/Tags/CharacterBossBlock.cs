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
    [LayoutAttribute(Size = 12)]
    public class CharacterBossBlockBase
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
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.flurryDamageThreshold01 = binaryReader.ReadSingle();
            this.flurryTimeSeconds = binaryReader.ReadSingle();
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
