// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundSceneryDatumStructBlock : SoundSceneryDatumStructBlockBase
    {
        public SoundSceneryDatumStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class SoundSceneryDatumStructBlockBase : GuerillaBlock
    {
        internal VolumeType volumeType;
        internal float height;
        internal Moonfish.Model.Range overrideDistanceBounds;
        internal Moonfish.Model.Range overrideConeAngleBounds;
        internal float overrideOuterConeGainDB;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundSceneryDatumStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            volumeType = (VolumeType) binaryReader.ReadInt32();
            height = binaryReader.ReadSingle();
            overrideDistanceBounds = binaryReader.ReadRange();
            overrideConeAngleBounds = binaryReader.ReadRange();
            overrideOuterConeGainDB = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32) volumeType);
                binaryWriter.Write(height);
                binaryWriter.Write(overrideDistanceBounds);
                binaryWriter.Write(overrideConeAngleBounds);
                binaryWriter.Write(overrideOuterConeGainDB);
                return nextAddress;
            }
        }

        internal enum VolumeType : int
        {
            Sphere = 0,
            VerticalCylinder = 1,
        };
    };
}