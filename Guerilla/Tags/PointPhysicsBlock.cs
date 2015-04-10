using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("pphy")]
    public  partial class PointPhysicsBlock : PointPhysicsBlockBase
    {
        public  PointPhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class PointPhysicsBlockBase
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
        internal  PointPhysicsBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_ = binaryReader.ReadBytes(28);
            this.densityGML = binaryReader.ReadSingle();
            this.airFriction = binaryReader.ReadSingle();
            this.waterFriction = binaryReader.ReadSingle();
            this.surfaceFriction = binaryReader.ReadSingle();
            this.elasticity = binaryReader.ReadSingle();
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
