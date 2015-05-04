// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponTrackingStructBlock : WeaponTrackingStructBlockBase
    {
        public  WeaponTrackingStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WeaponTrackingStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class WeaponTrackingStructBlockBase : GuerillaBlock
    {
        internal TrackingType trackingType;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WeaponTrackingStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            trackingType = (TrackingType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public  WeaponTrackingStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            trackingType = (TrackingType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)trackingType);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
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
