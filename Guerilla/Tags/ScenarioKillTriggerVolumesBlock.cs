using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioKillTriggerVolumesBlock : ScenarioKillTriggerVolumesBlockBase
    {
        public  ScenarioKillTriggerVolumesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2)]
    public class ScenarioKillTriggerVolumesBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal  ScenarioKillTriggerVolumesBlockBase(BinaryReader binaryReader)
        {
            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
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
