// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterPhysicsGroundStructBlock : CharacterPhysicsGroundStructBlockBase
    {
        public  CharacterPhysicsGroundStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class CharacterPhysicsGroundStructBlockBase
    {
        internal float maximumSlopeAngleDegrees;
        internal float downhillFalloffAngleDegrees;
        internal float downhillCutoffAngleDegrees;
        internal float uphillFalloffAngleDegrees;
        internal float uphillCutoffAngleDegrees;
        internal float downhillVelocityScale;
        internal float uphillVelocityScale;
        internal byte[] invalidName_;
        internal  CharacterPhysicsGroundStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            maximumSlopeAngleDegrees = binaryReader.ReadSingle();
            downhillFalloffAngleDegrees = binaryReader.ReadSingle();
            downhillCutoffAngleDegrees = binaryReader.ReadSingle();
            uphillFalloffAngleDegrees = binaryReader.ReadSingle();
            uphillCutoffAngleDegrees = binaryReader.ReadSingle();
            downhillVelocityScale = binaryReader.ReadSingle();
            uphillVelocityScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(20);
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
                binaryWriter.Write(maximumSlopeAngleDegrees);
                binaryWriter.Write(downhillFalloffAngleDegrees);
                binaryWriter.Write(downhillCutoffAngleDegrees);
                binaryWriter.Write(uphillFalloffAngleDegrees);
                binaryWriter.Write(uphillCutoffAngleDegrees);
                binaryWriter.Write(downhillVelocityScale);
                binaryWriter.Write(uphillVelocityScale);
                binaryWriter.Write(invalidName_, 0, 20);
            }
        }
    };
}
