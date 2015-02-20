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
        public  WeaponTrackingStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class WeaponTrackingStructBlockBase
    {
        internal TrackingType trackingType;
        internal byte[] invalidName_;
        internal  WeaponTrackingStructBlockBase(BinaryReader binaryReader)
        {
            this.trackingType = (TrackingType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
        internal enum TrackingType : short
        
        {
            NoTracking = 0,
            HumanTracking = 1,
            PlasmaTracking = 2,
        };
    };
}
