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
        public  DamageConstraintInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DamageConstraintInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            physicsModelConstraintName = binaryReader.ReadStringID();
            damageConstraintName = binaryReader.ReadStringID();
            damageConstraintGroupName = binaryReader.ReadStringID();
            groupProbabilityScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(physicsModelConstraintName);
                binaryWriter.Write(damageConstraintName);
                binaryWriter.Write(damageConstraintGroupName);
                binaryWriter.Write(groupProbabilityScale);
                binaryWriter.Write(invalidName_, 0, 4);
            }
        }
    };
}
