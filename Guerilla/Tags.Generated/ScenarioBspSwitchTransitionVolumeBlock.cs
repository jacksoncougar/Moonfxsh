// ReSharper disable All
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
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioBspSwitchTransitionVolumeBlockBase  : IGuerilla
    {
        internal int bSPIndexKey;
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal byte[] invalidName_;
        internal  ScenarioBspSwitchTransitionVolumeBlockBase(BinaryReader binaryReader)
        {
            bSPIndexKey = binaryReader.ReadInt32();
            triggerVolume = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSPIndexKey);
                binaryWriter.Write(triggerVolume);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
    };
}
