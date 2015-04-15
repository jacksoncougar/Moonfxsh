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
    public  partial class CameraTrackBlock : CameraTrackBlockBase
    {
        public  CameraTrackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CameraTrackBlockBase  : IGuerilla
    {
        internal Flags flags;
        internal CameraTrackControlPointBlock[] controlPoints;
        internal  CameraTrackBlockBase(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            controlPoints = Guerilla.ReadBlockArray<CameraTrackControlPointBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
