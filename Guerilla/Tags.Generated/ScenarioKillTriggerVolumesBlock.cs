// ReSharper disable All
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
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ScenarioKillTriggerVolumesBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal  ScenarioKillTriggerVolumesBlockBase(BinaryReader binaryReader)
        {
            triggerVolume = binaryReader.ReadShortBlockIndex1();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(triggerVolume);
                return nextAddress;
            }
        }
    };
}
