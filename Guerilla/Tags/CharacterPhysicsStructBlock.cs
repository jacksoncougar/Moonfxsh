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
    [LayoutAttribute(Size = 148)]
    public class CharacterPhysicsStructBlockBase
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
            this.flags = (Flags)binaryReader.ReadInt32();
            this.heightStanding = binaryReader.ReadSingle();
            this.heightCrouching = binaryReader.ReadSingle();
            this.radius = binaryReader.ReadSingle();
            this.mass = binaryReader.ReadSingle();
            this.livingMaterialName = binaryReader.ReadStringID();
            this.deadMaterialName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.deadSphereShapes = ReadSpheresBlockArray(binaryReader);
            this.pillShapes = ReadPillsBlockArray(binaryReader);
            this.sphereShapes = ReadSpheresBlockArray(binaryReader);
            this.groundPhysics = new CharacterPhysicsGroundStructBlock(binaryReader);
            this.flyingPhysics = new CharacterPhysicsFlyingStructBlock(binaryReader);
            this.deadPhysics = new CharacterPhysicsDeadStructBlock(binaryReader);
            this.sentinelPhysics = new CharacterPhysicsSentinelStructBlock(binaryReader);
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
        internal  virtual SpheresBlock[] ReadSpheresBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SpheresBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SpheresBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SpheresBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PillsBlock[] ReadPillsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PillsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PillsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PillsBlock(binaryReader);
                }
            }
            return array;
        }
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
