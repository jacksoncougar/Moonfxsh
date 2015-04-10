// ReSharper disable All
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
        public  ScenarioBspSwitchTriggerVolumeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ScenarioBspSwitchTriggerVolumeBlockBase(System.IO.BinaryReader binaryReader)
        {
            triggerVolume = binaryReader.ReadShortBlockIndex1();
            source = binaryReader.ReadInt16();
            destination = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(triggerVolume);
                binaryWriter.Write(source);
                binaryWriter.Write(destination);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 2);
            }
        }
    };
}
