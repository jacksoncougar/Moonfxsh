using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioLightFixtureStructBlock : ScenarioLightFixtureStructBlockBase
    {
        public  ScenarioLightFixtureStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ScenarioLightFixtureStructBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal float intensity;
        internal float falloffAngleDegrees;
        internal float cutoffAngleDegrees;
        internal  ScenarioLightFixtureStructBlockBase(BinaryReader binaryReader)
        {
            this.color = binaryReader.ReadColorR8G8B8();
            this.intensity = binaryReader.ReadSingle();
            this.falloffAngleDegrees = binaryReader.ReadSingle();
            this.cutoffAngleDegrees = binaryReader.ReadSingle();
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
