using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioBspSwitchTransitionVolumeBlock : ScenarioBspSwitchTransitionVolumeBlockBase
    {
        public  ScenarioBspSwitchTransitionVolumeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ScenarioBspSwitchTransitionVolumeBlockBase
    {
        internal int bSPIndexKey;
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal byte[] invalidName_;
        internal  ScenarioBspSwitchTransitionVolumeBlockBase(BinaryReader binaryReader)
        {
            this.bSPIndexKey = binaryReader.ReadInt32();
            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
