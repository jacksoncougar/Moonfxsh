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
    public partial class UnitCameraStructBlock : UnitCameraStructBlockBase
    {
        public UnitCameraStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class UnitCameraStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent cameraMarkerName;
        internal Moonfish.Tags.StringIdent cameraSubmergedMarkerName;
        internal float pitchAutoLevel;
        internal Moonfish.Model.Range pitchRange;
        internal UnitCameraTrackBlock[] cameraTracks;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public UnitCameraStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            cameraMarkerName = binaryReader.ReadStringID();
            cameraSubmergedMarkerName = binaryReader.ReadStringID();
            pitchAutoLevel = binaryReader.ReadSingle();
            pitchRange = binaryReader.ReadRange();
            blamPointers.Enqueue(ReadBlockArrayPointer<UnitCameraTrackBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            cameraTracks = ReadBlockArrayData<UnitCameraTrackBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(cameraMarkerName);
                binaryWriter.Write(cameraSubmergedMarkerName);
                binaryWriter.Write(pitchAutoLevel);
                binaryWriter.Write(pitchRange);
                nextAddress = Guerilla.WriteBlockArray<UnitCameraTrackBlock>(binaryWriter, cameraTracks, nextAddress);
                return nextAddress;
            }
        }
    };
}