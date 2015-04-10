using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("cin*")]
    public  partial class ScenarioCinematicsResourceBlock : ScenarioCinematicsResourceBlockBase
    {
        public  ScenarioCinematicsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ScenarioCinematicsResourceBlockBase
    {
        internal ScenarioCutsceneFlagBlock[] flags;
        internal ScenarioCutsceneCameraPointBlock[] cameraPoints;
        internal RecordedAnimationBlock[] recordedAnimations;
        internal  ScenarioCinematicsResourceBlockBase(BinaryReader binaryReader)
        {
            this.flags = ReadScenarioCutsceneFlagBlockArray(binaryReader);
            this.cameraPoints = ReadScenarioCutsceneCameraPointBlockArray(binaryReader);
            this.recordedAnimations = ReadRecordedAnimationBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual ScenarioCutsceneFlagBlock[] ReadScenarioCutsceneFlagBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCutsceneFlagBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCutsceneFlagBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCutsceneFlagBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCutsceneCameraPointBlock[] ReadScenarioCutsceneCameraPointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCutsceneCameraPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCutsceneCameraPointBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCutsceneCameraPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RecordedAnimationBlock[] ReadRecordedAnimationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RecordedAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RecordedAnimationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RecordedAnimationBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
