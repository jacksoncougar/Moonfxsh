// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterPhysicsStructBlock : CharacterPhysicsStructBlockBase
    {
        public  CharacterPhysicsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 148, Alignment = 4)]
    public class CharacterPhysicsStructBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal float heightStanding;
        internal float heightCrouching;
        internal float radius;
        internal float mass;
        /// <summary>
        /// collision material used when character is alive
        /// </summary>
        internal Moonfish.Tags.StringID livingMaterialName;
        /// <summary>
        /// collision material used when character is dead
        /// </summary>
        internal Moonfish.Tags.StringID deadMaterialName;
        internal byte[] invalidName_;
        internal SpheresBlock[] deadSphereShapes;
        internal PillsBlock[] pillShapes;
        internal SpheresBlock[] sphereShapes;
        internal CharacterPhysicsGroundStructBlock groundPhysics;
        internal CharacterPhysicsFlyingStructBlock flyingPhysics;
        internal CharacterPhysicsDeadStructBlock deadPhysics;
        internal CharacterPhysicsSentinelStructBlock sentinelPhysics;
        internal  CharacterPhysicsStructBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            heightStanding = binaryReader.ReadSingle();
            heightCrouching = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            livingMaterialName = binaryReader.ReadStringID();
            deadMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            deadSphereShapes = Guerilla.ReadBlockArray<SpheresBlock>(binaryReader);
            pillShapes = Guerilla.ReadBlockArray<PillsBlock>(binaryReader);
            sphereShapes = Guerilla.ReadBlockArray<SpheresBlock>(binaryReader);
            groundPhysics = new CharacterPhysicsGroundStructBlock(binaryReader);
            flyingPhysics = new CharacterPhysicsFlyingStructBlock(binaryReader);
            deadPhysics = new CharacterPhysicsDeadStructBlock(binaryReader);
            sentinelPhysics = new CharacterPhysicsSentinelStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(heightStanding);
                binaryWriter.Write(heightCrouching);
                binaryWriter.Write(radius);
                binaryWriter.Write(mass);
                binaryWriter.Write(livingMaterialName);
                binaryWriter.Write(deadMaterialName);
                binaryWriter.Write(invalidName_, 0, 4);
                Guerilla.WriteBlockArray<SpheresBlock>(binaryWriter, deadSphereShapes, nextAddress);
                Guerilla.WriteBlockArray<PillsBlock>(binaryWriter, pillShapes, nextAddress);
                Guerilla.WriteBlockArray<SpheresBlock>(binaryWriter, sphereShapes, nextAddress);
                groundPhysics.Write(binaryWriter);
                flyingPhysics.Write(binaryWriter);
                deadPhysics.Write(binaryWriter);
                sentinelPhysics.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
