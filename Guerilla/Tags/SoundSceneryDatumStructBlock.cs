// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundSceneryDatumStructBlock : SoundSceneryDatumStructBlockBase
    {
        public  SoundSceneryDatumStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundSceneryDatumStructBlockBase  : IGuerilla
    {
        internal VolumeType volumeType;
        internal float height;
        internal Moonfish.Model.Range overrideDistanceBounds;
        internal Moonfish.Model.Range overrideConeAngleBounds;
        internal float overrideOuterConeGainDB;
        internal  SoundSceneryDatumStructBlockBase(BinaryReader binaryReader)
        {
            volumeType = (VolumeType)binaryReader.ReadInt32();
            height = binaryReader.ReadSingle();
            overrideDistanceBounds = binaryReader.ReadRange();
            overrideConeAngleBounds = binaryReader.ReadRange();
            overrideOuterConeGainDB = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)volumeType);
                binaryWriter.Write(height);
                binaryWriter.Write(overrideDistanceBounds);
                binaryWriter.Write(overrideConeAngleBounds);
                binaryWriter.Write(overrideOuterConeGainDB);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum VolumeType : int
        {
            Sphere = 0,
            VerticalCylinder = 1,
        };
    };
}
