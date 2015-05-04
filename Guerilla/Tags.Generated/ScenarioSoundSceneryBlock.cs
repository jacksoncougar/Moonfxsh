// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioSoundSceneryBlock : ScenarioSoundSceneryBlockBase
    {
        public  ScenarioSoundSceneryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioSoundSceneryBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 80, Alignment = 4)]
    public class ScenarioSoundSceneryBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal SoundSceneryDatumStructBlock soundScenery;
        
        public override int SerializedSize{get { return 80; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioSoundSceneryBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            soundScenery = new SoundSceneryDatumStructBlock(binaryReader);
        }
        public  ScenarioSoundSceneryBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            type = binaryReader.ReadShortBlockIndex1();
            name = binaryReader.ReadShortBlockIndex1();
            objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            soundScenery = new SoundSceneryDatumStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(name);
                objectData.Write(binaryWriter);
                soundScenery.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
