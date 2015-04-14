// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass TrgClass = (TagClass)"trg*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("trg*")]
    public  partial class ScenarioTriggerVolumesResourceBlock : ScenarioTriggerVolumesResourceBlockBase
    {
        public  ScenarioTriggerVolumesResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioTriggerVolumesResourceBlockBase  : IGuerilla
    {
        internal ScenarioTriggerVolumeBlock[] killTriggerVolumes;
        internal ScenarioObjectNamesBlock[] objectNames;
        internal  ScenarioTriggerVolumesResourceBlockBase(BinaryReader binaryReader)
        {
            killTriggerVolumes = Guerilla.ReadBlockArray<ScenarioTriggerVolumeBlock>(binaryReader);
            objectNames = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioTriggerVolumeBlock>(binaryWriter, killTriggerVolumes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, objectNames, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
