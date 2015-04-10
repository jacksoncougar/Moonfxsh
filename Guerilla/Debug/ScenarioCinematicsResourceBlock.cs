// ReSharper disable All
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
        public  ScenarioCinematicsResourceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ScenarioCinematicsResourceBlockBase
    {
        internal ScenarioCutsceneFlagBlock[] flags;
        internal ScenarioCutsceneCameraPointBlock[] cameraPoints;
        internal RecordedAnimationBlock[] recordedAnimations;
        internal  ScenarioCinematicsResourceBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadScenarioCutsceneFlagBlockArray(binaryReader);
            ReadScenarioCutsceneCameraPointBlockArray(binaryReader);
            ReadRecordedAnimationBlockArray(binaryReader);
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
        internal  virtual ScenarioCutsceneFlagBlock[] ReadScenarioCutsceneFlagBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCutsceneFlagBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCutsceneFlagBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCutsceneFlagBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ScenarioCutsceneCameraPointBlock[] ReadScenarioCutsceneCameraPointBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioCutsceneCameraPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioCutsceneCameraPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioCutsceneCameraPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RecordedAnimationBlock[] ReadRecordedAnimationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RecordedAnimationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RecordedAnimationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RecordedAnimationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCutsceneFlagBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteScenarioCutsceneCameraPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRecordedAnimationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteScenarioCutsceneFlagBlockArray(binaryWriter);
                WriteScenarioCutsceneCameraPointBlockArray(binaryWriter);
                WriteRecordedAnimationBlockArray(binaryWriter);
            }
        }
    };
}
