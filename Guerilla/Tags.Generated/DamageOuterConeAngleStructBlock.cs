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
    public partial class DamageOuterConeAngleStructBlock : DamageOuterConeAngleStructBlockBase
    {
        public DamageOuterConeAngleStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class DamageOuterConeAngleStructBlockBase : GuerillaBlock
    {
        internal float dmgOuterConeAngle;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public DamageOuterConeAngleStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            dmgOuterConeAngle = binaryReader.ReadSingle();
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
                binaryWriter.Write(dmgOuterConeAngle);
                return nextAddress;
            }
        }
    };
}
