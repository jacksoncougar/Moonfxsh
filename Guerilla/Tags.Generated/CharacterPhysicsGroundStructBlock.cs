// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class CharacterPhysicsGroundStructBlock : CharacterPhysicsGroundStructBlockBase
    {
        public CharacterPhysicsGroundStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class CharacterPhysicsGroundStructBlockBase : GuerillaBlock
    {
        internal float maximumSlopeAngleDegrees;
        internal float downhillFalloffAngleDegrees;
        internal float downhillCutoffAngleDegrees;
        internal float uphillFalloffAngleDegrees;
        internal float uphillCutoffAngleDegrees;
        internal float downhillVelocityScale;
        internal float uphillVelocityScale;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 48; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CharacterPhysicsGroundStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            maximumSlopeAngleDegrees = binaryReader.ReadSingle();
            downhillFalloffAngleDegrees = binaryReader.ReadSingle();
            downhillCutoffAngleDegrees = binaryReader.ReadSingle();
            uphillFalloffAngleDegrees = binaryReader.ReadSingle();
            uphillCutoffAngleDegrees = binaryReader.ReadSingle();
            downhillVelocityScale = binaryReader.ReadSingle();
            uphillVelocityScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(20);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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