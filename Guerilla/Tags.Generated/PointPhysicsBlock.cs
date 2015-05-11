// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Pphy = (TagClass) "pphy";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("pphy")]
    public partial class PointPhysicsBlock : PointPhysicsBlockBase
    {
        public PointPhysicsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class PointPhysicsBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal float densityGML;
        internal float airFriction;
        internal float waterFriction;

        /// <summary>
        /// when hitting the ground or interior, percentage of velocity lost in one collision
        /// </summary>
        internal float surfaceFriction;

        /// <summary>
        /// 0.0 is inelastic collisions (no bounce) 1.0 is perfectly elastic (reflected velocity equals incoming velocity)
        /// </summary>
        internal float elasticity;

        internal byte[] invalidName_0;

        public override int SerializedSize
        {
            get { return 64; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PointPhysicsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(28);
            densityGML = binaryReader.ReadSingle();
            airFriction = binaryReader.ReadSingle();
            waterFriction = binaryReader.ReadSingle();
            surfaceFriction = binaryReader.ReadSingle();
            elasticity = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(12);
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
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(invalidName_, 0, 28);
                binaryWriter.Write(densityGML);
                binaryWriter.Write(airFriction);
                binaryWriter.Write(waterFriction);
                binaryWriter.Write(surfaceFriction);
                binaryWriter.Write(elasticity);
                binaryWriter.Write(invalidName_0, 0, 12);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            UNUSED = 1,
            CollidesWithStructures = 2,
            CollidesWithWaterSurface = 4,
            UsesSimpleWindTheWindOnThisPointWontHaveHighFrequencyVariations = 8,
            UsesDampedWindTheWindOnThisPointWillBeArtificiallySlow = 16,
            NoGravityThePointIsNotAffectedByGravity = 32,
        };
    };
}