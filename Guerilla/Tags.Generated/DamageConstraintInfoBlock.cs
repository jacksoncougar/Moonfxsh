// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageConstraintInfoBlock : DamageConstraintInfoBlockBase
    {
        public  DamageConstraintInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DamageConstraintInfoBlock(): base()
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
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DamageConstraintInfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            physicsModelConstraintName = binaryReader.ReadStringID();
            damageConstraintName = binaryReader.ReadStringID();
            damageConstraintGroupName = binaryReader.ReadStringID();
            groupProbabilityScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public  DamageConstraintInfoBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            physicsModelConstraintName = binaryReader.ReadStringID();
            damageConstraintName = binaryReader.ReadStringID();
            damageConstraintGroupName = binaryReader.ReadStringID();
            groupProbabilityScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
