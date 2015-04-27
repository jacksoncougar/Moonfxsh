// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioBspSwitchTransitionVolumeBlock : ScenarioBspSwitchTransitionVolumeBlockBase
    {
        public  ScenarioBspSwitchTransitionVolumeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioBspSwitchTransitionVolumeBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioBspSwitchTransitionVolumeBlockBase : GuerillaBlock
    {
        internal int bSPIndexKey;
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioBspSwitchTransitionVolumeBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bSPIndexKey = binaryReader.ReadInt32();
            triggerVolume = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  ScenarioBspSwitchTransitionVolumeBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
