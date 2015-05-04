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
        public static readonly TagClass Cin = (TagClass) "cin*";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("cin*")]
    public partial class ScenarioCinematicsResourceBlock : ScenarioCinematicsResourceBlockBase
    {
        public ScenarioCinematicsResourceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioCinematicsResourceBlockBase : GuerillaBlock
    {
        internal ScenarioCutsceneFlagBlock[] flags;
        internal ScenarioCutsceneCameraPointBlock[] cameraPoints;
        internal RecordedAnimationBlock[] recordedAnimations;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ScenarioCinematicsResourceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCutsceneFlagBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioCutsceneCameraPointBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<RecordedAnimationBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            flags = ReadBlockArrayData<ScenarioCutsceneFlagBlock>(binaryReader, blamPointers.Dequeue());
            cameraPoints = ReadBlockArrayData<ScenarioCutsceneCameraPointBlock>(binaryReader, blamPointers.Dequeue());
            recordedAnimations = ReadBlockArrayData<RecordedAnimationBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioCutsceneFlagBlock>(binaryWriter, flags, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCutsceneCameraPointBlock>(binaryWriter, cameraPoints,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RecordedAnimationBlock>(binaryWriter, recordedAnimations,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}