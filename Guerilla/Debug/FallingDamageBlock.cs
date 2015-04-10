// ReSharper disable All
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
        public  FallingDamageBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  FallingDamageBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(8);
            harmfulFallingDistanceWorldUnits = binaryReader.ReadRange();
            fallingDamage = binaryReader.ReadTagReference();
            invalidName_0 = binaryReader.ReadBytes(8);
            maximumFallingDistanceWorldUnits = binaryReader.ReadSingle();
            distanceDamage = binaryReader.ReadTagReference();
            vehicleEnvironemtnCollisionDamageEffect = binaryReader.ReadTagReference();
            vehicleKilledUnitDamageEffect = binaryReader.ReadTagReference();
            vehicleCollisionDamage = binaryReader.ReadTagReference();
            flamingDeathDamage = binaryReader.ReadTagReference();
            invalidName_1 = binaryReader.ReadBytes(28);
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
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(harmfulFallingDistanceWorldUnits);
                binaryWriter.Write(fallingDamage);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(maximumFallingDistanceWorldUnits);
                binaryWriter.Write(distanceDamage);
                binaryWriter.Write(vehicleEnvironemtnCollisionDamageEffect);
                binaryWriter.Write(vehicleKilledUnitDamageEffect);
                binaryWriter.Write(vehicleCollisionDamage);
                binaryWriter.Write(flamingDeathDamage);
                binaryWriter.Write(invalidName_1, 0, 28);
            }
        }
    };
}
