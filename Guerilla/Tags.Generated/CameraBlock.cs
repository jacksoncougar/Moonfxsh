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
    public partial class CameraBlock : CameraBlockBase
    {
        public CameraBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CameraBlockBase : GuerillaBlock
    {
        [TagReference("trak")] internal Moonfish.Tags.TagReference defaultUnitCameraTrack;
        internal float defaultChangePause;
        internal float firstPersonChangePause;
        internal float followingCameraChangePause;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CameraBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            defaultUnitCameraTrack = binaryReader.ReadTagReference();
            defaultChangePause = binaryReader.ReadSingle();
            firstPersonChangePause = binaryReader.ReadSingle();
            followingCameraChangePause = binaryReader.ReadSingle();
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
                binaryWriter.Write(defaultUnitCameraTrack);
                binaryWriter.Write(defaultChangePause);
                binaryWriter.Write(firstPersonChangePause);
                binaryWriter.Write(followingCameraChangePause);
                return nextAddress;
            }
        }
    };
}