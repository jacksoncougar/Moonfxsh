// ReSharper disable All
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
        public  LightVolumeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class LightVolumeBlockBase
    {
        internal float falloffDistanceFromCameraWorldUnits;
        internal float cutoffDistanceFromCameraWorldUnits;
        internal LightVolumeVolumeBlock[] volumes;
        internal  LightVolumeBlockBase(System.IO.BinaryReader binaryReader)
        {
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            ReadLightVolumeVolumeBlockArray(binaryReader);
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
        internal  virtual LightVolumeVolumeBlock[] ReadLightVolumeVolumeBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightVolumeVolumeBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(falloffDistanceFromCameraWorldUnits);
                binaryWriter.Write(cutoffDistanceFromCameraWorldUnits);
                WriteLightVolumeVolumeBlockArray(binaryWriter);
            }
        }
    };
}
