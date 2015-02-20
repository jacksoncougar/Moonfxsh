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
    [LayoutAttribute(Size = 28)]
    public class SoundSceneryDatumStructBlockBase
    {
        internal VolumeType volumeType;
        internal float height;
        internal Moonfish.Model.Range overrideDistanceBounds;
        internal Moonfish.Model.Range overrideConeAngleBounds;
        internal float overrideOuterConeGainDB;
        internal  SoundSceneryDatumStructBlockBase(BinaryReader binaryReader)
        {
            this.volumeType = (VolumeType)binaryReader.ReadInt32();
            this.height = binaryReader.ReadSingle();
            this.overrideDistanceBounds = binaryReader.ReadRange();
            this.overrideConeAngleBounds = binaryReader.ReadRange();
            this.overrideOuterConeGainDB = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal enum VolumeType : int
        
        {
            Sphere = 0,
            VerticalCylinder = 1,
        };
    };
}
