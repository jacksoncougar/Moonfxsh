using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioSoundSceneryBlock : ScenarioSoundSceneryBlockBase
    {
        public  ScenarioSoundSceneryBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class ScenarioSoundSceneryBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 type;
        internal Moonfish.Tags.ShortBlockIndex1 name;
        internal ScenarioObjectDatumStructBlock objectData;
        internal SoundSceneryDatumStructBlock soundScenery;
        internal  ScenarioSoundSceneryBlockBase(BinaryReader binaryReader)
        {
            this.type = binaryReader.ReadShortBlockIndex1();
            this.name = binaryReader.ReadShortBlockIndex1();
            this.objectData = new ScenarioObjectDatumStructBlock(binaryReader);
            this.soundScenery = new SoundSceneryDatumStructBlock(binaryReader);
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
    };
}
