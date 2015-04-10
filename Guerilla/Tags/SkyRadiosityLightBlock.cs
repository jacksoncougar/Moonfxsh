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
        public  SkyRadiosityLightBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SkyRadiosityLightBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.color = binaryReader.ReadColorR8G8B8();
            this.power0Inf = binaryReader.ReadSingle();
            this.testDistanceWorldUnits = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.diameterDegrees = binaryReader.ReadSingle();
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
        internal enum Flags : int
        
        {
            AffectsExteriors = 1,
            AffectsInteriors = 2,
            DirectIlluminationInLightmaps = 4,
            IndirectIlluminationInLightmaps = 8,
        };
    };
}
