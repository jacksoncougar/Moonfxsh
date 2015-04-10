// ReSharper disable All
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
        public  ScenarioLightFixtureStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioLightFixtureStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
            intensity = binaryReader.ReadSingle();
            falloffAngleDegrees = binaryReader.ReadSingle();
            cutoffAngleDegrees = binaryReader.ReadSingle();
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
                binaryWriter.Write(color);
                binaryWriter.Write(intensity);
                binaryWriter.Write(falloffAngleDegrees);
                binaryWriter.Write(cutoffAngleDegrees);
            }
        }
    };
}
