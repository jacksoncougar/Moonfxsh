using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("devi")]
    public  partial class DeviceBlock : DeviceBlockBase
    {
        public  DeviceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class DeviceBlockBase : ObjectBlock
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
        internal  DeviceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.powerTransitionTimeSeconds = binaryReader.ReadSingle();
            this.powerAccelerationTimeSeconds = binaryReader.ReadSingle();
            this.positionTransitionTimeSeconds = binaryReader.ReadSingle();
            this.positionAccelerationTimeSeconds = binaryReader.ReadSingle();
            this.depoweredPositionTransitionTimeSeconds = binaryReader.ReadSingle();
            this.depoweredPositionAccelerationTimeSeconds = binaryReader.ReadSingle();
            this.lightmapFlags = (LightmapFlags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.openUp = binaryReader.ReadTagReference();
            this.closeDown = binaryReader.ReadTagReference();
            this.opened = binaryReader.ReadTagReference();
            this.closed = binaryReader.ReadTagReference();
            this.depowered = binaryReader.ReadTagReference();
            this.repowered = binaryReader.ReadTagReference();
            this.delayTimeSeconds = binaryReader.ReadSingle();
            this.delayEffect = binaryReader.ReadTagReference();
            this.automaticActivationRadiusWorldUnits = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
