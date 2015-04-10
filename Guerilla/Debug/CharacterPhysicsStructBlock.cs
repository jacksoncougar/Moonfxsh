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
        public  CharacterPhysicsStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterPhysicsStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            heightStanding = binaryReader.ReadSingle();
            heightCrouching = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            mass = binaryReader.ReadSingle();
            livingMaterialName = binaryReader.ReadStringID();
            deadMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            ReadSpheresBlockArray(binaryReader);
            ReadPillsBlockArray(binaryReader);
            ReadSpheresBlockArray(binaryReader);
            groundPhysics = new CharacterPhysicsGroundStructBlock(binaryReader);
            flyingPhysics = new CharacterPhysicsFlyingStructBlock(binaryReader);
            deadPhysics = new CharacterPhysicsDeadStructBlock(binaryReader);
            sentinelPhysics = new CharacterPhysicsSentinelStructBlock(binaryReader);
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
        internal  virtual SpheresBlock[] ReadSpheresBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PillsBlock[] ReadPillsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteSpheresBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePillsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
                WriteSpheresBlockArray(binaryWriter);
                WritePillsBlockArray(binaryWriter);
                WriteSpheresBlockArray(binaryWriter);
                groundPhysics.Write(binaryWriter);
                flyingPhysics.Write(binaryWriter);
                deadPhysics.Write(binaryWriter);
                sentinelPhysics.Write(binaryWriter);
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
