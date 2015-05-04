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
        public static readonly TagClass MGS2 = (TagClass)"MGS2";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("MGS2")]
    public partial class LightVolumeBlock : LightVolumeBlockBase
    {
        public  LightVolumeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightVolumeBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class LightVolumeBlockBase : GuerillaBlock
    {
        internal float falloffDistanceFromCameraWorldUnits;
        internal float cutoffDistanceFromCameraWorldUnits;
        internal LightVolumeVolumeBlock[] volumes;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightVolumeBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            volumes = Guerilla.ReadBlockArray<LightVolumeVolumeBlock>(binaryReader);
        }
        public  LightVolumeBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            volumes = Guerilla.ReadBlockArray<LightVolumeVolumeBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(falloffDistanceFromCameraWorldUnits);
                binaryWriter.Write(cutoffDistanceFromCameraWorldUnits);
                nextAddress = Guerilla.WriteBlockArray<LightVolumeVolumeBlock>(binaryWriter, volumes, nextAddress);
                return nextAddress;
            }
        }
    };
}
