// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioKillTriggerVolumesBlock : ScenarioKillTriggerVolumesBlockBase
    {
        public  ScenarioKillTriggerVolumesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioKillTriggerVolumesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ScenarioKillTriggerVolumesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioKillTriggerVolumesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            triggerVolume = binaryReader.ReadShortBlockIndex1();
        }
        public  ScenarioKillTriggerVolumesBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(triggerVolume);
                return nextAddress;
            }
        }
    };
}
