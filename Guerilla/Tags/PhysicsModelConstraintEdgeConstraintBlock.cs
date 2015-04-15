// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PhysicsModelConstraintEdgeConstraintBlock : PhysicsModelConstraintEdgeConstraintBlockBase
    {
        public  PhysicsModelConstraintEdgeConstraintBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PhysicsModelConstraintEdgeConstraintBlockBase  : IGuerilla
    {
        internal Type type;
        internal Moonfish.Tags.ShortBlockIndex2 index;
        internal Flags flags;
        /// <summary>
        /// 0 is the default (takes what it was set in max) anything else overrides that value
        /// </summary>
        internal float friction;
        internal  PhysicsModelConstraintEdgeConstraintBlockBase(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            index = binaryReader.ReadShortBlockIndex2();
            flags = (Flags)binaryReader.ReadInt32();
            friction = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(index);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(friction);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            Hinge = 0,
            LimitedHinge = 1,
            Ragdoll = 2,
            StiffSpring = 3,
            BallAndSocket = 4,
            Prismatic = 5,
        };
        [FlagsAttribute]
        internal enum Flags : int
        {
            IsRigidThisConstraintMakesTheEdgeRigidUntilItIsLoosenedByDamage = 1,
            DisableEffectsThisConstraintWillNotGenerateImpactEffects = 2,
        };
    };
}
