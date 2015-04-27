// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Trak = (TagClass)"trak";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("trak")]
    public partial class CameraTrackBlock : CameraTrackBlockBase
    {
        public  CameraTrackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CameraTrackBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CameraTrackBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal CameraTrackControlPointBlock[] controlPoints;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CameraTrackBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            controlPoints = Guerilla.ReadBlockArray<CameraTrackControlPointBlock>(binaryReader);
        }
        public  CameraTrackBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                nextAddress = Guerilla.WriteBlockArray<CameraTrackControlPointBlock>(binaryWriter, controlPoints, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
        };
    };
}
