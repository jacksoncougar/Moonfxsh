// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioAtmosphericFogMixerBlock : ScenarioAtmosphericFogMixerBlockBase
    {
        public  ScenarioAtmosphericFogMixerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioAtmosphericFogMixerBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioAtmosphericFogMixerBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.StringIdent atmosphericFogSourceFromScenarioAtmosphericFogPalette;
        internal Moonfish.Tags.StringIdent interpolatorFromScenarioInterpolators;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioAtmosphericFogMixerBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            atmosphericFogSourceFromScenarioAtmosphericFogPalette = binaryReader.ReadStringID();
            interpolatorFromScenarioInterpolators = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
        }
        public  ScenarioAtmosphericFogMixerBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            atmosphericFogSourceFromScenarioAtmosphericFogPalette = binaryReader.ReadStringID();
            interpolatorFromScenarioInterpolators = binaryReader.ReadStringID();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(atmosphericFogSourceFromScenarioAtmosphericFogPalette);
                binaryWriter.Write(interpolatorFromScenarioInterpolators);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                return nextAddress;
            }
        }
    };
}
