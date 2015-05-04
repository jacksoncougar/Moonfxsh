// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterBossBlock : CharacterBossBlockBase
    {
        public CharacterBossBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CharacterBossBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public CharacterBossBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            flurryDamageThreshold01 = binaryReader.ReadSingle();
            flurryTimeSeconds = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
