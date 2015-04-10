using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterBoardingBlock : CharacterBoardingBlockBase
    {
        public  CharacterBoardingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class CharacterBoardingBlockBase
    {
        internal Flags flags;
        /// <summary>
        /// maximum distance from entry point that we will consider boarding
        /// </summary>
        internal float maxDistanceWus;
        /// <summary>
        /// give up trying to get in boarding seat if entry point is further away than this
        /// </summary>
        internal float abortDistanceWus;
        /// <summary>
        /// maximum speed at which we will consider boarding
        /// </summary>
        internal float maxSpeedWuS;
        internal  CharacterBoardingBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.maxDistanceWus = binaryReader.ReadSingle();
            this.abortDistanceWus = binaryReader.ReadSingle();
            this.maxSpeedWuS = binaryReader.ReadSingle();
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
            AirborneBoarding = 1,
        };
    };
}
