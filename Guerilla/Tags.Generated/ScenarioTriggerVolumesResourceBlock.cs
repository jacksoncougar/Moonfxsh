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
        public static readonly TagClass Trg = (TagClass)"trg*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("trg*")]
    public partial class ScenarioTriggerVolumesResourceBlock : ScenarioTriggerVolumesResourceBlockBase
    {
        public  ScenarioTriggerVolumesResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioTriggerVolumesResourceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioTriggerVolumesResourceBlockBase : GuerillaBlock
    {
        internal ScenarioTriggerVolumeBlock[] killTriggerVolumes;
        internal ScenarioObjectNamesBlock[] objectNames;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioTriggerVolumesResourceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            killTriggerVolumes = Guerilla.ReadBlockArray<ScenarioTriggerVolumeBlock>(binaryReader);
            objectNames = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
        }
        public  ScenarioTriggerVolumesResourceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            killTriggerVolumes = Guerilla.ReadBlockArray<ScenarioTriggerVolumeBlock>(binaryReader);
            objectNames = Guerilla.ReadBlockArray<ScenarioObjectNamesBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioTriggerVolumeBlock>(binaryWriter, killTriggerVolumes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioObjectNamesBlock>(binaryWriter, objectNames, nextAddress);
                return nextAddress;
            }
        }
    };
}
