// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyRadiosityLightBlock : SkyRadiosityLightBlockBase
    {
        public  SkyRadiosityLightBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class SkyRadiosityLightBlockBase
    {
        internal Flags flags;
        /// <summary>
        /// Light color.
        /// </summary>
        internal Moonfish.Tags.ColorR8G8B8 color;
        /// <summary>
        /// Light power from 0 to infinity.
        /// </summary>
        internal float power0Inf;
        /// <summary>
        /// Length of the ray for shadow testing.
        /// </summary>
        internal float testDistanceWorldUnits;
        internal byte[] invalidName_;
        /// <summary>
        /// Angular diameter of the light source in the sky.
        /// </summary>
        internal float diameterDegrees;
        internal  SkyRadiosityLightBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            color = binaryReader.ReadColorR8G8B8();
            power0Inf = binaryReader.ReadSingle();
            testDistanceWorldUnits = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(12);
            diameterDegrees = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(color);
                binaryWriter.Write(power0Inf);
                binaryWriter.Write(testDistanceWorldUnits);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(diameterDegrees);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            AffectsExteriors = 1,
            AffectsInteriors = 2,
            DirectIlluminationInLightmaps = 4,
            IndirectIlluminationInLightmaps = 8,
        };
    };
}
