// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CameraBlock : CameraBlockBase
    {
        public  CameraBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class CameraBlockBase
    {
        [TagReference("trak")]
        internal Moonfish.Tags.TagReference defaultUnitCameraTrack;
        internal float defaultChangePause;
        internal float firstPersonChangePause;
        internal float followingCameraChangePause;
        internal  CameraBlockBase(System.IO.BinaryReader binaryReader)
        {
            defaultUnitCameraTrack = binaryReader.ReadTagReference();
            defaultChangePause = binaryReader.ReadSingle();
            firstPersonChangePause = binaryReader.ReadSingle();
            followingCameraChangePause = binaryReader.ReadSingle();
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
                binaryWriter.Write(defaultUnitCameraTrack);
                binaryWriter.Write(defaultChangePause);
                binaryWriter.Write(firstPersonChangePause);
                binaryWriter.Write(followingCameraChangePause);
            }
        }
    };
}
