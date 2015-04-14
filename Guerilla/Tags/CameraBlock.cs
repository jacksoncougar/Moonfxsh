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
        public  CameraBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CameraBlockBase  : IGuerilla
    {
        [TagReference("trak")]
        internal Moonfish.Tags.TagReference defaultUnitCameraTrack;
        internal float defaultChangePause;
        internal float firstPersonChangePause;
        internal float followingCameraChangePause;
        internal  CameraBlockBase(BinaryReader binaryReader)
        {
            defaultUnitCameraTrack = binaryReader.ReadTagReference();
            defaultChangePause = binaryReader.ReadSingle();
            firstPersonChangePause = binaryReader.ReadSingle();
            followingCameraChangePause = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(defaultUnitCameraTrack);
                binaryWriter.Write(defaultChangePause);
                binaryWriter.Write(firstPersonChangePause);
                binaryWriter.Write(followingCameraChangePause);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
