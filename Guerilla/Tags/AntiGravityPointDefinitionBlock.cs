using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AntiGravityPointDefinitionBlock : AntiGravityPointDefinitionBlockBase
    {
        public  AntiGravityPointDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 76)]
    public class AntiGravityPointDefinitionBlockBase
    {
        internal Moonfish.Tags.StringID markerName;
        internal Flags flags;
        internal float antigravStrength;
        internal float antigravOffset;
        internal float antigravHeight;
        internal float antigravDampFactor;
        internal float antigravNormalK1;
        internal float antigravNormalK0;
        internal float radius;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.StringID damageSourceRegionName;
        internal float defaultStateError;
        internal float minorDamageError;
        internal float mediumDamageError;
        internal float majorDamageError;
        internal float destroyedStateError;
        internal  AntiGravityPointDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.markerName = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.antigravStrength = binaryReader.ReadSingle();
            this.antigravOffset = binaryReader.ReadSingle();
            this.antigravHeight = binaryReader.ReadSingle();
            this.antigravDampFactor = binaryReader.ReadSingle();
            this.antigravNormalK1 = binaryReader.ReadSingle();
            this.antigravNormalK0 = binaryReader.ReadSingle();
            this.radius = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.damageSourceRegionName = binaryReader.ReadStringID();
            this.defaultStateError = binaryReader.ReadSingle();
            this.minorDamageError = binaryReader.ReadSingle();
            this.mediumDamageError = binaryReader.ReadSingle();
            this.majorDamageError = binaryReader.ReadSingle();
            this.destroyedStateError = binaryReader.ReadSingle();
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
        internal enum Flags : int
        {
            GetsDamageFromRegion = 1,
        };
    };
}
