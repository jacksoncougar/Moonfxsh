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
        public  ScenarioBspSwitchTransitionVolumeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ScenarioBspSwitchTransitionVolumeBlockBase
    {
        internal int bSPIndexKey;
        internal Moonfish.Tags.ShortBlockIndex1 triggerVolume;
        internal byte[] invalidName_;
        internal  ScenarioBspSwitchTransitionVolumeBlockBase(System.IO.BinaryReader binaryReader)
        {
            bSPIndexKey = binaryReader.ReadInt32();
            triggerVolume = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bSPIndexKey);
                binaryWriter.Write(triggerVolume);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
    };
}
