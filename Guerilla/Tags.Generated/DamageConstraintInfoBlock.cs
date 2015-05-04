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
    public partial class DamageConstraintInfoBlock : DamageConstraintInfoBlockBase
    {
        public DamageConstraintInfoBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class DamageConstraintInfoBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent physicsModelConstraintName;
        internal Moonfish.Tags.StringIdent damageConstraintName;
        internal Moonfish.Tags.StringIdent damageConstraintGroupName;
        internal float groupProbabilityScale;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public DamageConstraintInfoBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            physicsModelConstraintName = binaryReader.ReadStringID();
            damageConstraintName = binaryReader.ReadStringID();
            damageConstraintGroupName = binaryReader.ReadStringID();
            groupProbabilityScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
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
                binaryWriter.Write(physicsModelConstraintName);
                binaryWriter.Write(damageConstraintName);
                binaryWriter.Write(damageConstraintGroupName);
                binaryWriter.Write(groupProbabilityScale);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress;
            }
        }
    };
}
