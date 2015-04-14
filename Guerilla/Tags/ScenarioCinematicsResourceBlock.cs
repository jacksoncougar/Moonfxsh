// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass CinClass = (TagClass)"cin*";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("cin*")]
    public  partial class ScenarioCinematicsResourceBlock : ScenarioCinematicsResourceBlockBase
    {
        public  ScenarioCinematicsResourceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioCinematicsResourceBlockBase  : IGuerilla
    {
        internal ScenarioCutsceneFlagBlock[] flags;
        internal ScenarioCutsceneCameraPointBlock[] cameraPoints;
        internal RecordedAnimationBlock[] recordedAnimations;
        internal  ScenarioCinematicsResourceBlockBase(BinaryReader binaryReader)
        {
            flags = Guerilla.ReadBlockArray<ScenarioCutsceneFlagBlock>(binaryReader);
            cameraPoints = Guerilla.ReadBlockArray<ScenarioCutsceneCameraPointBlock>(binaryReader);
            recordedAnimations = Guerilla.ReadBlockArray<RecordedAnimationBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ScenarioCutsceneFlagBlock>(binaryWriter, flags, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ScenarioCutsceneCameraPointBlock>(binaryWriter, cameraPoints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<RecordedAnimationBlock>(binaryWriter, recordedAnimations, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
