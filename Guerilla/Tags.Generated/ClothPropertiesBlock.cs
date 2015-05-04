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
    public partial class ClothPropertiesBlock : ClothPropertiesBlockBase
    {
        public ClothPropertiesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class ClothPropertiesBlockBase : GuerillaBlock
    {
        internal IntegrationType integrationType;
        /// <summary>
        /// [1-8] sug 1
        /// </summary>
        internal short numberIterations;
        /// <summary>
        /// [-10.0 - 10.0] sug 1.0
        /// </summary>
        internal float weight;
        /// <summary>
        /// [0.0 - 0.5] sug 0.07
        /// </summary>
        internal float drag;
        /// <summary>
        /// [0.0 - 3.0] sug 1.0
        /// </summary>
        internal float windScale;
        /// <summary>
        /// [0.0 - 1.0] sug 0.75
        /// </summary>
        internal float windFlappinessScale;
        /// <summary>
        /// [1.0 - 10.0] sug 3.5
        /// </summary>
        internal float longestRod;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 48; } }
        public override int Alignment { get { return 4; } }
        public ClothPropertiesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            integrationType = (IntegrationType)binaryReader.ReadInt16();
            numberIterations = binaryReader.ReadInt16();
            weight = binaryReader.ReadSingle();
            drag = binaryReader.ReadSingle();
            windScale = binaryReader.ReadSingle();
            windFlappinessScale = binaryReader.ReadSingle();
            longestRod = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
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
                binaryWriter.Write((Int16)integrationType);
                binaryWriter.Write(numberIterations);
                binaryWriter.Write(weight);
                binaryWriter.Write(drag);
                binaryWriter.Write(windScale);
                binaryWriter.Write(windFlappinessScale);
                binaryWriter.Write(longestRod);
                binaryWriter.Write(invalidName_, 0, 24);
                return nextAddress;
            }
        }
        internal enum IntegrationType : short
        {
            Verlet = 0,
        };
    };
}
