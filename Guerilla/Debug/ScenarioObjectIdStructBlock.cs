// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioObjectIdStructBlock : ScenarioObjectIdStructBlockBase
    {
        public  ScenarioObjectIdStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ScenarioObjectIdStructBlockBase
    {
        internal int uniqueID;
        internal Moonfish.Tags.ShortBlockIndex1 originBSPIndex;
        internal Type type;
        internal Source source;
        internal  ScenarioObjectIdStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            uniqueID = binaryReader.ReadInt32();
            originBSPIndex = binaryReader.ReadShortBlockIndex1();
            type = (Type)binaryReader.ReadByte();
            source = (Source)binaryReader.ReadByte();
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
                binaryWriter.Write(uniqueID);
                binaryWriter.Write(originBSPIndex);
                binaryWriter.Write((Byte)type);
                binaryWriter.Write((Byte)source);
            }
        }
        internal enum Type : byte
        
        {
            Biped = 0,
            Vehicle = 1,
            Weapon = 2,
            Equipment = 3,
            Garbage = 4,
            Projectile = 5,
            Scenery = 6,
            Machine = 7,
            Control = 8,
            LightFixture = 9,
            SoundScenery = 10,
            Crate = 11,
            Creature = 12,
        };
        internal enum Source : byte
        
        {
            Structure = 0,
            Editor = 1,
            Dynamic = 2,
            Legacy = 3,
        };
    };
}
