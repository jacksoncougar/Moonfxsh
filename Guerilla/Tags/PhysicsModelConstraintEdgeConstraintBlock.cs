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
    [LayoutAttribute(Size = 12)]
    public class PhysicsModelConstraintEdgeConstraintBlockBase
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
            this.type = (Type)binaryReader.ReadInt16();
            this.index = binaryReader.ReadShortBlockIndex2();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.friction = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
