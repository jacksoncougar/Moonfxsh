// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageConstraintInfoBlock : DamageConstraintInfoBlockBase
    {
        public  DamageConstraintInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class DamageConstraintInfoBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID physicsModelConstraintName;
        internal Moonfish.Tags.StringID damageConstraintName;
        internal Moonfish.Tags.StringID damageConstraintGroupName;
        internal float groupProbabilityScale;
        internal byte[] invalidName_;
        internal  DamageConstraintInfoBlockBase(BinaryReader binaryReader)
        {
            physicsModelConstraintName = binaryReader.ReadStringID();
            damageConstraintName = binaryReader.ReadStringID();
            damageConstraintGroupName = binaryReader.ReadStringID();
            groupProbabilityScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(physicsModelConstraintName);
                binaryWriter.Write(damageConstraintName);
                binaryWriter.Write(damageConstraintGroupName);
                binaryWriter.Write(groupProbabilityScale);
                binaryWriter.Write(invalidName_, 0, 4);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
