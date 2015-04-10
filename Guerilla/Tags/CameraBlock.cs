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
        public  CameraBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  CameraBlockBase(BinaryReader binaryReader)
        {
            this.defaultUnitCameraTrack = binaryReader.ReadTagReference();
            this.defaultChangePause = binaryReader.ReadSingle();
            this.firstPersonChangePause = binaryReader.ReadSingle();
            this.followingCameraChangePause = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
