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
        public  CharacterPhysicsGroundStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class CharacterPhysicsGroundStructBlockBase  : IGuerilla
    {
        internal float maximumSlopeAngleDegrees;
        internal float downhillFalloffAngleDegrees;
        internal float downhillCutoffAngleDegrees;
        internal float uphillFalloffAngleDegrees;
        internal float uphillCutoffAngleDegrees;
        internal float downhillVelocityScale;
        internal float uphillVelocityScale;
        internal byte[] invalidName_;
        internal  CharacterPhysicsGroundStructBlockBase(BinaryReader binaryReader)
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
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
                return nextAddress;
            }
        }
    };
}
