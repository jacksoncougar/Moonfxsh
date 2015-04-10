using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class FallingDamageBlock : FallingDamageBlockBase
    {
        public  FallingDamageBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 104)]
    public class FallingDamageBlockBase
    {
        internal byte[] invalidName_;
        internal Moonfish.Model.Range harmfulFallingDistanceWorldUnits;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference fallingDamage;
        internal byte[] invalidName_0;
        internal float maximumFallingDistanceWorldUnits;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference distanceDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference vehicleEnvironemtnCollisionDamageEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference vehicleKilledUnitDamageEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference vehicleCollisionDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference flamingDeathDamage;
        internal byte[] invalidName_1;
        internal  FallingDamageBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(8);
            this.harmfulFallingDistanceWorldUnits = binaryReader.ReadRange();
            this.fallingDamage = binaryReader.ReadTagReference();
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.maximumFallingDistanceWorldUnits = binaryReader.ReadSingle();
            this.distanceDamage = binaryReader.ReadTagReference();
            this.vehicleEnvironemtnCollisionDamageEffect = binaryReader.ReadTagReference();
            this.vehicleKilledUnitDamageEffect = binaryReader.ReadTagReference();
            this.vehicleCollisionDamage = binaryReader.ReadTagReference();
            this.flamingDeathDamage = binaryReader.ReadTagReference();
            this.invalidName_1 = binaryReader.ReadBytes(28);
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
