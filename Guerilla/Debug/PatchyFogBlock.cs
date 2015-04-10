// ReSharper disable All
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
        public  PatchyFogBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PatchyFogBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            rotationMultiplier01 = binaryReader.ReadSingle();
            strafingMultiplier01 = binaryReader.ReadSingle();
            zoomMultiplier01 = binaryReader.ReadSingle();
            noiseMapScale = binaryReader.ReadSingle();
            noiseMap = binaryReader.ReadTagReference();
            noiseVerticalScaleForward = binaryReader.ReadSingle();
            noiseVerticalScaleUp = binaryReader.ReadSingle();
            noiseOpacityScaleUp = binaryReader.ReadSingle();
            animationPeriodSeconds = binaryReader.ReadSingle();
            windVelocityWorldUnitsPerSecond = binaryReader.ReadRange();
            windPeriodSeconds = binaryReader.ReadRange();
            windAccelerationWeight01 = binaryReader.ReadSingle();
            windPerpendicularWeight01 = binaryReader.ReadSingle();
            windConstantVelocityXWorldUnitsPerSecond = binaryReader.ReadSingle();
            windConstantVelocityYWorldUnitsPerSecond = binaryReader.ReadSingle();
            windConstantVelocityZWorldUnitsPerSecond = binaryReader.ReadSingle();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(rotationMultiplier01);
                binaryWriter.Write(strafingMultiplier01);
                binaryWriter.Write(zoomMultiplier01);
                binaryWriter.Write(noiseMapScale);
                binaryWriter.Write(noiseMap);
                binaryWriter.Write(noiseVerticalScaleForward);
                binaryWriter.Write(noiseVerticalScaleUp);
                binaryWriter.Write(noiseOpacityScaleUp);
                binaryWriter.Write(animationPeriodSeconds);
                binaryWriter.Write(windVelocityWorldUnitsPerSecond);
                binaryWriter.Write(windPeriodSeconds);
                binaryWriter.Write(windAccelerationWeight01);
                binaryWriter.Write(windPerpendicularWeight01);
                binaryWriter.Write(windConstantVelocityXWorldUnitsPerSecond);
                binaryWriter.Write(windConstantVelocityYWorldUnitsPerSecond);
                binaryWriter.Write(windConstantVelocityZWorldUnitsPerSecond);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            SeparateLayerDepths = 1,
            SortBehindTransparents = 2,
        };
    };
}
