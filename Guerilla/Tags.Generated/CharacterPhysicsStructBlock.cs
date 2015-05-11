// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterPhysicsStructBlock : CharacterPhysicsStructBlockBase
    {
        public CharacterPhysicsStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 148, Alignment = 4)]
    public class CharacterPhysicsStructBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal float heightStanding;
        internal float heightCrouching;
        internal float radius;
        internal float mass;

        /// <summary>
        /// collision material used when character is alive
        /// </summary>
        internal Moonfish.Tags.StringIdent livingMaterialName;

        /// <summary>
        /// collision material used when character is dead
        /// </summary>
        internal Moonfish.Tags.StringIdent deadMaterialName;

        internal byte[] invalidName_;
        internal SpheresBlock[] deadSphereShapes;
        internal PillsBlock[] pillShapes;
        internal SpheresBlock[] sphereShapes;
        internal CharacterPhysicsGroundStructBlock groundPhysics;
        internal CharacterPhysicsFlyingStructBlock flyingPhysics;
        internal CharacterPhysicsDeadStructBlock deadPhysics;
        internal CharacterPhysicsSentinelStructBlock sentinelPhysics;

        public override int SerializedSize
        {
            get { return 148; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterPhysicsStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            heightStanding = binaryReader.ReadSingle();
            heightCrouching = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            livingMaterialName = binaryReader.ReadStringID();
            deadMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<SpheresBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PillsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SpheresBlock>(binaryReader));
            groundPhysics = new CharacterPhysicsGroundStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(groundPhysics.ReadFields(binaryReader)));
            flyingPhysics = new CharacterPhysicsFlyingStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(flyingPhysics.ReadFields(binaryReader)));
            deadPhysics = new CharacterPhysicsDeadStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(deadPhysics.ReadFields(binaryReader)));
            sentinelPhysics = new CharacterPhysicsSentinelStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(sentinelPhysics.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            deadSphereShapes = ReadBlockArrayData<SpheresBlock>(binaryReader, blamPointers.Dequeue());
            pillShapes = ReadBlockArrayData<PillsBlock>(binaryReader, blamPointers.Dequeue());
            sphereShapes = ReadBlockArrayData<SpheresBlock>(binaryReader, blamPointers.Dequeue());
            groundPhysics.ReadPointers(binaryReader, blamPointers);
            flyingPhysics.ReadPointers(binaryReader, blamPointers);
            deadPhysics.ReadPointers(binaryReader, blamPointers);
            sentinelPhysics.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(heightStanding);
                binaryWriter.Write(heightCrouching);
                binaryWriter.Write(radius);
                binaryWriter.Write(mass);
                binaryWriter.Write(livingMaterialName);
                binaryWriter.Write(deadMaterialName);
                binaryWriter.Write(invalidName_, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<SpheresBlock>(binaryWriter, deadSphereShapes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PillsBlock>(binaryWriter, pillShapes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SpheresBlock>(binaryWriter, sphereShapes, nextAddress);
                groundPhysics.Write(binaryWriter);
                flyingPhysics.Write(binaryWriter);
                deadPhysics.Write(binaryWriter);
                sentinelPhysics.Write(binaryWriter);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            CenteredAtOrigin = 1,
            ShapeSpherical = 2,
            UsePlayerPhysics = 4,
            ClimbAnySurface = 8,
            Flying = 16,
            NotPhysical = 32,
            DeadCharacterCollisionGroup = 64,
        };
    };
}