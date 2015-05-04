// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioObjectIdStructBlock : ScenarioObjectIdStructBlockBase
    {
        public  ScenarioObjectIdStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioObjectIdStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioObjectIdStructBlockBase : GuerillaBlock
    {
        internal int uniqueID;
        internal Moonfish.Tags.ShortBlockIndex1 originBSPIndex;
        internal Type type;
        internal Source source;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioObjectIdStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            uniqueID = binaryReader.ReadInt32();
            originBSPIndex = binaryReader.ReadShortBlockIndex1();
            type = (Type)binaryReader.ReadByte();
            source = (Source)binaryReader.ReadByte();
        }
        public  ScenarioObjectIdStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            uniqueID = binaryReader.ReadInt32();
            originBSPIndex = binaryReader.ReadShortBlockIndex1();
            type = (Type)binaryReader.ReadByte();
            source = (Source)binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(uniqueID);
                binaryWriter.Write(originBSPIndex);
                binaryWriter.Write((Byte)type);
                binaryWriter.Write((Byte)source);
                return nextAddress;
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
