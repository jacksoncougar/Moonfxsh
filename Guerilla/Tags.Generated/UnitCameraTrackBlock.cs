// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UnitCameraTrackBlock : UnitCameraTrackBlockBase
    {
        public  UnitCameraTrackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UnitCameraTrackBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UnitCameraTrackBlockBase : GuerillaBlock
    {
        [TagReference("trak")]
        internal Moonfish.Tags.TagReference track;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UnitCameraTrackBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            track = binaryReader.ReadTagReference();
        }
        public  UnitCameraTrackBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(track);
                return nextAddress;
            }
        }
    };
}
