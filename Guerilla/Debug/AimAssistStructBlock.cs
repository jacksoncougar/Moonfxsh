// ReSharper disable All
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
        public  AimAssistStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AimAssistStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            autoaimAngleDegrees = binaryReader.ReadSingle();
            autoaimRangeWorldUnits = binaryReader.ReadSingle();
            magnetismAngleDegrees = binaryReader.ReadSingle();
            magnetismRangeWorldUnits = binaryReader.ReadSingle();
            deviationAngleDegrees = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(12);
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
                binaryWriter.Write(autoaimAngleDegrees);
                binaryWriter.Write(autoaimRangeWorldUnits);
                binaryWriter.Write(magnetismAngleDegrees);
                binaryWriter.Write(magnetismRangeWorldUnits);
                binaryWriter.Write(deviationAngleDegrees);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 12);
            }
        }
    };
}
