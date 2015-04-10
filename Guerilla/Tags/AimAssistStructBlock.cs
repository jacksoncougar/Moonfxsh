using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AimAssistStructBlock : AimAssistStructBlockBase
    {
        public  AimAssistStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class AimAssistStructBlockBase
    {
        /// <summary>
        /// the maximum angle that autoaim works at full strength
        /// </summary>
        internal float autoaimAngleDegrees;
        /// <summary>
        /// the maximum distance that autoaim works at full strength
        /// </summary>
        internal float autoaimRangeWorldUnits;
        /// <summary>
        /// the maximum angle that magnetism works at full strength
        /// </summary>
        internal float magnetismAngleDegrees;
        /// <summary>
        /// the maximum distance that magnetism works at full strength
        /// </summary>
        internal float magnetismRangeWorldUnits;
        /// <summary>
        /// the maximum angle that a projectile is allowed to deviate from the gun barrel
        /// </summary>
        internal float deviationAngleDegrees;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal  AimAssistStructBlockBase(BinaryReader binaryReader)
        {
            this.autoaimAngleDegrees = binaryReader.ReadSingle();
            this.autoaimRangeWorldUnits = binaryReader.ReadSingle();
            this.magnetismAngleDegrees = binaryReader.ReadSingle();
            this.magnetismRangeWorldUnits = binaryReader.ReadSingle();
            this.deviationAngleDegrees = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.invalidName_0 = binaryReader.ReadBytes(12);
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
    };
}
