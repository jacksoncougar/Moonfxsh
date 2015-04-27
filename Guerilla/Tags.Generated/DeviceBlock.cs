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
        public static readonly TagClass Devi = (TagClass)"devi";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("devi")]
    public partial class DeviceBlock : DeviceBlockBase
    {
        public  DeviceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DeviceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class DeviceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal float powerTransitionTimeSeconds;
        internal float powerAccelerationTimeSeconds;
        internal float positionTransitionTimeSeconds;
        internal float positionAccelerationTimeSeconds;
        internal float depoweredPositionTransitionTimeSeconds;
        internal float depoweredPositionAccelerationTimeSeconds;
        internal LightmapFlags lightmapFlags;
        internal byte[] invalidName_;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference openUp;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference closeDown;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference opened;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference closed;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference depowered;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference repowered;
        internal float delayTimeSeconds;
        [TagReference("null")]
        internal Moonfish.Tags.TagReference delayEffect;
        internal float automaticActivationRadiusWorldUnits;
        
        public override int SerializedSize{get { return 96; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DeviceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            powerTransitionTimeSeconds = binaryReader.ReadSingle();
            powerAccelerationTimeSeconds = binaryReader.ReadSingle();
            positionTransitionTimeSeconds = binaryReader.ReadSingle();
            positionAccelerationTimeSeconds = binaryReader.ReadSingle();
            depoweredPositionTransitionTimeSeconds = binaryReader.ReadSingle();
            depoweredPositionAccelerationTimeSeconds = binaryReader.ReadSingle();
            lightmapFlags = (LightmapFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            openUp = binaryReader.ReadTagReference();
            closeDown = binaryReader.ReadTagReference();
            opened = binaryReader.ReadTagReference();
            closed = binaryReader.ReadTagReference();
            depowered = binaryReader.ReadTagReference();
            repowered = binaryReader.ReadTagReference();
            delayTimeSeconds = binaryReader.ReadSingle();
            delayEffect = binaryReader.ReadTagReference();
            automaticActivationRadiusWorldUnits = binaryReader.ReadSingle();
        }
        public  DeviceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            powerTransitionTimeSeconds = binaryReader.ReadSingle();
            powerAccelerationTimeSeconds = binaryReader.ReadSingle();
            positionTransitionTimeSeconds = binaryReader.ReadSingle();
            positionAccelerationTimeSeconds = binaryReader.ReadSingle();
            depoweredPositionTransitionTimeSeconds = binaryReader.ReadSingle();
            depoweredPositionAccelerationTimeSeconds = binaryReader.ReadSingle();
            lightmapFlags = (LightmapFlags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            openUp = binaryReader.ReadTagReference();
            closeDown = binaryReader.ReadTagReference();
            opened = binaryReader.ReadTagReference();
            closed = binaryReader.ReadTagReference();
            depowered = binaryReader.ReadTagReference();
            repowered = binaryReader.ReadTagReference();
            delayTimeSeconds = binaryReader.ReadSingle();
            delayEffect = binaryReader.ReadTagReference();
            automaticActivationRadiusWorldUnits = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(powerTransitionTimeSeconds);
                binaryWriter.Write(powerAccelerationTimeSeconds);
                binaryWriter.Write(positionTransitionTimeSeconds);
                binaryWriter.Write(positionAccelerationTimeSeconds);
                binaryWriter.Write(depoweredPositionTransitionTimeSeconds);
                binaryWriter.Write(depoweredPositionAccelerationTimeSeconds);
                binaryWriter.Write((Int16)lightmapFlags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(openUp);
                binaryWriter.Write(closeDown);
                binaryWriter.Write(opened);
                binaryWriter.Write(closed);
                binaryWriter.Write(depowered);
                binaryWriter.Write(repowered);
                binaryWriter.Write(delayTimeSeconds);
                binaryWriter.Write(delayEffect);
                binaryWriter.Write(automaticActivationRadiusWorldUnits);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            PositionLoops = 1,
            Unused = 2,
            AllowInterpolation = 4,
        };
        [FlagsAttribute]
        internal enum LightmapFlags : short
        {
            DontUseInLightmap = 1,
            DontUseInLightprobe = 2,
        };
    };
}
