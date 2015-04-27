// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CameraTrackControlPointBlock : CameraTrackControlPointBlockBase
    {
        public  CameraTrackControlPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CameraTrackControlPointBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class CameraTrackControlPointBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Quaternion orientation;
        
        public override int SerializedSize{get { return 28; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CameraTrackControlPointBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            position = binaryReader.ReadVector3();
            orientation = binaryReader.ReadQuaternion();
        }
        public  CameraTrackControlPointBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            orientation = binaryReader.ReadQuaternion();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                binaryWriter.Write(orientation);
                return nextAddress;
            }
        }
    };
}
