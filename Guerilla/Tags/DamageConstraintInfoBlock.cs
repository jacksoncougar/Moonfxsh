using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 20)]
    public  partial class DamageConstraintInfoBlock : DamageConstraintInfoBlockBase
    {
        public  DamageConstraintInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class DamageConstraintInfoBlockBase
    {
        internal Moonfish.Tags.StringID physicsModelConstraintName;
        internal Moonfish.Tags.StringID damageConstraintName;
        internal Moonfish.Tags.StringID damageConstraintGroupName;
        internal float groupProbabilityScale;
        internal byte[] invalidName_;
        internal  DamageConstraintInfoBlockBase(BinaryReader binaryReader)
        {
            this.physicsModelConstraintName = binaryReader.ReadStringID();
            this.damageConstraintName = binaryReader.ReadStringID();
            this.damageConstraintGroupName = binaryReader.ReadStringID();
            this.groupProbabilityScale = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
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
