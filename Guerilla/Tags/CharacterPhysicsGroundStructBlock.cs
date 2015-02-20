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
        internal  CharacterPhysicsGroundStructBlockBase(BinaryReader binaryReader)
        {
            this.maximumSlopeAngleDegrees = binaryReader.ReadSingle();
            this.downhillFalloffAngleDegrees = binaryReader.ReadSingle();
            this.downhillCutoffAngleDegrees = binaryReader.ReadSingle();
            this.uphillFalloffAngleDegrees = binaryReader.ReadSingle();
            this.uphillCutoffAngleDegrees = binaryReader.ReadSingle();
            this.downhillVelocityScale = binaryReader.ReadSingle();
            this.uphillVelocityScale = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(20);
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
