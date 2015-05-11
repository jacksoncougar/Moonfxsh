// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class WeaponTrackingStructBlock : WeaponTrackingStructBlockBase
    {
        public WeaponTrackingStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class WeaponTrackingStructBlockBase : GuerillaBlock
    {
        internal TrackingType trackingType;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public WeaponTrackingStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            trackingType = (TrackingType) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16) trackingType);
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