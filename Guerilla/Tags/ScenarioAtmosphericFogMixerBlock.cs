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
        public  ScenarioAtmosphericFogMixerBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioAtmosphericFogMixerBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.atmosphericFogSourceFromScenarioAtmosphericFogPalette = binaryReader.ReadStringID();
            this.interpolatorFromScenarioInterpolators = binaryReader.ReadStringID();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(2);
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
