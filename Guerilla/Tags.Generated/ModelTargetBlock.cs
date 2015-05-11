// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelTargetBlock : ModelTargetBlockBase
    {
        public ModelTargetBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class ModelTargetBlockBase : GuerillaBlock
    {
        /// <summary>
        /// multiple markers become multiple spheres of the same radius
        /// </summary>
        internal Moonfish.Tags.StringIdent markerName;

        /// <summary>
        /// sphere radius
        /// </summary>
        internal float size;

        /// <summary>
        /// the target is only visible when viewed within this angle of the marker's x axis
        /// </summary>
        internal float coneAngle;

        /// <summary>
        /// the target is associated with this damageSection
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex2 damageSection;

        /// <summary>
        /// the target will only appear with this variant
        /// </summary>
        internal Moonfish.Tags.ShortBlockIndex1 variant;

        /// <summary>
        /// higher relevances turn into stronger magnetisms
        /// </summary>
        internal float targetingRelevance;

        internal ModelTargetLockOnDataStructBlock lockOnData;

        public override int SerializedSize
        {
            get { return 28; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ModelTargetBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            markerName = binaryReader.ReadStringID();
            size = binaryReader.ReadSingle();
            coneAngle = binaryReader.ReadSingle();
            damageSection = binaryReader.ReadShortBlockIndex2();
            variant = binaryReader.ReadShortBlockIndex1();
            targetingRelevance = binaryReader.ReadSingle();
            lockOnData = new ModelTargetLockOnDataStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(lockOnData.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lockOnData.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(markerName);
                binaryWriter.Write(size);
                binaryWriter.Write(coneAngle);
                binaryWriter.Write(damageSection);
                binaryWriter.Write(variant);
                binaryWriter.Write(targetingRelevance);
                lockOnData.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}