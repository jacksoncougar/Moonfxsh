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
        public  SoundSceneryDatumStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundSceneryDatumStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            volumeType = (VolumeType)binaryReader.ReadInt32();
            height = binaryReader.ReadSingle();
            overrideDistanceBounds = binaryReader.ReadRange();
            overrideConeAngleBounds = binaryReader.ReadRange();
            overrideOuterConeGainDB = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)volumeType);
                binaryWriter.Write(height);
                binaryWriter.Write(overrideDistanceBounds);
                binaryWriter.Write(overrideConeAngleBounds);
                binaryWriter.Write(overrideOuterConeGainDB);
            }
        }
        internal enum VolumeType : int
        
        {
            Sphere = 0,
            VerticalCylinder = 1,
        };
    };
}
