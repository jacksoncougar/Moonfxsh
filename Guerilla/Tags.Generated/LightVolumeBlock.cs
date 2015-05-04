// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
        public LightVolumeBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class LightVolumeBlockBase : GuerillaBlock
    {
        internal float falloffDistanceFromCameraWorldUnits;
        internal float cutoffDistanceFromCameraWorldUnits;
        internal LightVolumeVolumeBlock[] volumes;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public LightVolumeBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            falloffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            cutoffDistanceFromCameraWorldUnits = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<LightVolumeVolumeBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            volumes = ReadBlockArrayData<LightVolumeVolumeBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
