// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioAtmosphericFogMixerBlock : ScenarioAtmosphericFogMixerBlockBase
    {
        public  ScenarioAtmosphericFogMixerBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ScenarioAtmosphericFogMixerBlockBase
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringID atmosphericFogSourceFromScenarioAtmosphericFogPalette;
        internal Moonfish.Tags.StringID interpolatorFromScenarioInterpolators;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal  ScenarioAtmosphericFogMixerBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            atmosphericFogSourceFromScenarioAtmosphericFogPalette = binaryReader.ReadStringID();
            interpolatorFromScenarioInterpolators = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(atmosphericFogSourceFromScenarioAtmosphericFogPalette);
                binaryWriter.Write(interpolatorFromScenarioInterpolators);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
            }
        }
    };
}
