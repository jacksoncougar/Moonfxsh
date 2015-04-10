using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioBspSwitchTriggerVolumeBlock : ScenarioBspSwitchTriggerVolumeBlockBase
    {
        public  ScenarioBspSwitchTriggerVolumeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 14)]
    public class ScenarioBspSwitchTriggerVolumeBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal short source;
        internal short destination;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  ScenarioBspSwitchTriggerVolumeBlockBase(BinaryReader binaryReader)
        {
            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
            this.source = binaryReader.ReadInt16();
            this.destination = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(2);
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
