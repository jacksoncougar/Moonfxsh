using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("MGS2")]
    public  partial class LightVolumeBlock : LightVolumeBlockBase
    {
        public  LightVolumeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class LightVolumeBlockBase
    {
        internal float falloffDistanceFromCameraWorldUnits;
        internal float cutoffDistanceFromCameraWorldUnits;
        internal LightVolumeVolumeBlock[] volumes;
        internal  LightVolumeBlockBase(BinaryReader binaryReader)
        {
            this.falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            this.cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            this.volumes = ReadLightVolumeVolumeBlockArray(binaryReader);
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
        internal  virtual LightVolumeVolumeBlock[] ReadLightVolumeVolumeBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightVolumeVolumeBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightVolumeVolumeBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightVolumeVolumeBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
