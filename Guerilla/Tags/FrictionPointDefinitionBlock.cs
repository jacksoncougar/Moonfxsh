using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class FrictionPointDefinitionBlock : FrictionPointDefinitionBlockBase
    {
        public  FrictionPointDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 76)]
    public class FrictionPointDefinitionBlockBase
    {
        internal Moonfish.Tags.StringID markerName;
        internal Flags flags;
        /// <summary>
        /// (0.0-1.0) fraction of total vehicle mass
        /// </summary>
        internal float fractionOfTotalMass;
        internal float radius;
        /// <summary>
        /// radius when the tire is blown off.
        /// </summary>
        internal float damagedRadius;
        internal FrictionType frictionType;
        internal byte[] invalidName_;
        internal float movingFrictionVelocityDiff;
        internal float eBrakeMovingFriction;
        internal float eBrakeFriction;
        internal float eBrakeMovingFrictionVelDiff;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringID collisionGlobalMaterialName;
        internal byte[] invalidName_1;
        /// <summary>
        /// only need point can destroy flag set
        /// </summary>
        internal ModelStateDestroyedOnlyNeedPointCanDestroyFlagSet modelStateDestroyed;
        /// <summary>
        /// only need point can destroy flag set
        /// </summary>
        internal Moonfish.Tags.StringID regionName;
        internal byte[] invalidName_2;
        internal  FrictionPointDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.markerName = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.fractionOfTotalMass = binaryReader.ReadSingle();
            this.radius = binaryReader.ReadSingle();
            this.damagedRadius = binaryReader.ReadSingle();
            this.frictionType = (FrictionType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.movingFrictionVelocityDiff = binaryReader.ReadSingle();
            this.eBrakeMovingFriction = binaryReader.ReadSingle();
            this.eBrakeFriction = binaryReader.ReadSingle();
            this.eBrakeMovingFrictionVelDiff = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(20);
            this.collisionGlobalMaterialName = binaryReader.ReadStringID();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.modelStateDestroyed = (ModelStateDestroyedOnlyNeedPointCanDestroyFlagSet)binaryReader.ReadInt16();
            this.regionName = binaryReader.ReadStringID();
            this.invalidName_2 = binaryReader.ReadBytes(4);
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
            Powered = 2,
            FrontTurning = 4,
            RearTurning = 8,
            AttachedToEBrake = 16,
            CanBeDestroyed = 32,
        };
        internal enum FrictionType : short
        {
            Point = 0,
            Forward = 1,
        };
        internal enum ModelStateDestroyedOnlyNeedPointCanDestroyFlagSet : short
        {
            Default = 0,
            MinorDamage = 1,
            MediumDamage = 2,
            MajorDamage = 3,
            Destroyed = 4,
        };
    };
}
