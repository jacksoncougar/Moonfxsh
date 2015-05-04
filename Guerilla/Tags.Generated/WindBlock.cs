// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
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
        public static readonly TagClass Wind = (TagClass)"wind";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("wind")]
    public partial class WindBlock : WindBlockBase
    {
        public WindBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class WindBlockBase : GuerillaBlock
    {
        /// <summary>
        /// the wind magnitude in the weather region scales the wind between these bounds
        /// </summary>
        internal Moonfish.Model.Range velocityWorldUnits;
        /// <summary>
        /// the wind direction varies inside a box defined by these angles on either side of the direction from the weather region.
        /// </summary>
        internal OpenTK.Vector2 variationArea;
        internal float localVariationWeight;
        internal float localVariationRate;
        internal float damping;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 64; } }
        public override int Alignment { get { return 4; } }
        public WindBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            velocityWorldUnits = binaryReader.ReadRange();
            variationArea = binaryReader.ReadVector2();
            localVariationWeight = binaryReader.ReadSingle();
            localVariationRate = binaryReader.ReadSingle();
            damping = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(36);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(velocityWorldUnits);
                binaryWriter.Write(variationArea);
                binaryWriter.Write(localVariationWeight);
                binaryWriter.Write(localVariationRate);
                binaryWriter.Write(damping);
                binaryWriter.Write(invalidName_, 0, 36);
                return nextAddress;
            }
        }
    };
}
