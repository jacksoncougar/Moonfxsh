using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("fpch")]
    public  partial class PatchyFogBlock : PatchyFogBlockBase
    {
        public  PatchyFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 80)]
    public class PatchyFogBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal float rotationMultiplier01;
        internal float strafingMultiplier01;
        internal float zoomMultiplier01;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float noiseMapScale;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference noiseMap;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float noiseVerticalScaleForward;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float noiseVerticalScaleUp;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal float noiseOpacityScaleUp;
        internal float animationPeriodSeconds;
        internal Moonfish.Model.Range windVelocityWorldUnitsPerSecond;
        /// <summary>
        /// 0 defaults to 1
        /// </summary>
        internal Moonfish.Model.Range windPeriodSeconds;
        internal float windAccelerationWeight01;
        internal float windPerpendicularWeight01;
        internal float windConstantVelocityXWorldUnitsPerSecond;
        internal float windConstantVelocityYWorldUnitsPerSecond;
        internal float windConstantVelocityZWorldUnitsPerSecond;
        internal  PatchyFogBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.rotationMultiplier01 = binaryReader.ReadSingle();
            this.strafingMultiplier01 = binaryReader.ReadSingle();
            this.zoomMultiplier01 = binaryReader.ReadSingle();
            this.noiseMapScale = binaryReader.ReadSingle();
            this.noiseMap = binaryReader.ReadTagReference();
            this.noiseVerticalScaleForward = binaryReader.ReadSingle();
            this.noiseVerticalScaleUp = binaryReader.ReadSingle();
            this.noiseOpacityScaleUp = binaryReader.ReadSingle();
            this.animationPeriodSeconds = binaryReader.ReadSingle();
            this.windVelocityWorldUnitsPerSecond = binaryReader.ReadRange();
            this.windPeriodSeconds = binaryReader.ReadRange();
            this.windAccelerationWeight01 = binaryReader.ReadSingle();
            this.windPerpendicularWeight01 = binaryReader.ReadSingle();
            this.windConstantVelocityXWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.windConstantVelocityYWorldUnitsPerSecond = binaryReader.ReadSingle();
            this.windConstantVelocityZWorldUnitsPerSecond = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            SeparateLayerDepths = 1,
            SortBehindTransparents = 2,
        };
    };
}
