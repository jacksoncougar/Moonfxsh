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
        public  ScenarioObjectIdStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioObjectIdStructBlockBase(BinaryReader binaryReader)
        {
            this.uniqueID = binaryReader.ReadInt32();
            this.originBSPIndex = binaryReader.ReadShortBlockIndex1();
            this.type = (Type)binaryReader.ReadByte();
            this.source = (Source)binaryReader.ReadByte();
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
