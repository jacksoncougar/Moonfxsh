// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class WeaponTrackingStructBlock : WeaponTrackingStructBlockBase
    {
        public  WeaponTrackingStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class WeaponTrackingStructBlockBase
    {
        internal TrackingType trackingType;
        internal byte[] invalidName_;
        internal  WeaponTrackingStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            trackingType = (TrackingType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write((Int16)trackingType);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
        internal enum TrackingType : short
        
        {
            NoTracking = 0,
            HumanTracking = 1,
            PlasmaTracking = 2,
        };
    };
}
