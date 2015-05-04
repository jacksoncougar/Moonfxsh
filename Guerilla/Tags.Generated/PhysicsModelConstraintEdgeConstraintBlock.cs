// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PhysicsModelConstraintEdgeConstraintBlock : PhysicsModelConstraintEdgeConstraintBlockBase
    {
        public PhysicsModelConstraintEdgeConstraintBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PhysicsModelConstraintEdgeConstraintBlockBase : GuerillaBlock
    {
        internal Type type;
        internal Moonfish.Tags.ShortBlockIndex2 index;
        internal Flags flags;
        /// <summary>
        /// 0 is the default (takes what it was set in max) anything else overrides that value
        /// </summary>
        internal float friction;
        public override int SerializedSize { get { return 12; } }
        public override int Alignment { get { return 4; } }
        public PhysicsModelConstraintEdgeConstraintBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type)binaryReader.ReadInt16();
            index = binaryReader.ReadShortBlockIndex2();
            flags = (Flags)binaryReader.ReadInt32();
            friction = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
