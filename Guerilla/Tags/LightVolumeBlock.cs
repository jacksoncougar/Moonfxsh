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
        public static readonly TagClass MGS2Class = (TagClass)"MGS2";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("MGS2")]
    public  partial class LightVolumeBlock : LightVolumeBlockBase
    {
        public  LightVolumeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class LightVolumeBlockBase  : IGuerilla
    {
        internal float falloffDistanceFromCameraWorldUnits;
        internal float cutoffDistanceFromCameraWorldUnits;
        internal LightVolumeVolumeBlock[] volumes;
        internal  LightVolumeBlockBase(BinaryReader binaryReader)
        {
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            volumes = Guerilla.ReadBlockArray<LightVolumeVolumeBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(falloffDistanceFromCameraWorldUnits);
                binaryWriter.Write(cutoffDistanceFromCameraWorldUnits);
                nextAddress = Guerilla.WriteBlockArray<LightVolumeVolumeBlock>(binaryWriter, volumes, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
