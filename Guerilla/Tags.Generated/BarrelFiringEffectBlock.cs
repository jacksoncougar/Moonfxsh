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
    public partial class BarrelFiringEffectBlock : BarrelFiringEffectBlockBase
    {
        public BarrelFiringEffectBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 52, Alignment = 4)]
    public class BarrelFiringEffectBlockBase : GuerillaBlock
    {
        /// <summary>
        /// the minimum number of times this firing effect will be used, once it has been chosen
        /// </summary>
        internal short shotCountLowerBound;

        /// <summary>
        /// the maximum number of times this firing effect will be used, once it has been chosen
        /// </summary>
        internal short shotCountUpperBound;

        /// <summary>
        /// this effect is used when the weapon is loaded and fired normally
        /// </summary>
        [TagReference("null")] internal Moonfish.Tags.TagReference firingEffect;

        /// <summary>
        /// this effect is used when the weapon is loaded but fired while overheated
        /// </summary>
        [TagReference("null")] internal Moonfish.Tags.TagReference misfireEffect;

        /// <summary>
        /// this effect is used when the weapon is not loaded
        /// </summary>
        [TagReference("null")] internal Moonfish.Tags.TagReference emptyEffect;

        /// <summary>
        /// this effect is used when the weapon is loaded and fired normally
        /// </summary>
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference firingDamage;

        /// <summary>
        /// this effect is used when the weapon is loaded but fired while overheated
        /// </summary>
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference misfireDamage;

        /// <summary>
        /// this effect is used when the weapon is not loaded
        /// </summary>
        [TagReference("jpt!")] internal Moonfish.Tags.TagReference emptyDamage;

        public override int SerializedSize
        {
            get { return 52; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public BarrelFiringEffectBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            shotCountLowerBound = binaryReader.ReadInt16();
            shotCountUpperBound = binaryReader.ReadInt16();
            firingEffect = binaryReader.ReadTagReference();
            misfireEffect = binaryReader.ReadTagReference();
            emptyEffect = binaryReader.ReadTagReference();
            firingDamage = binaryReader.ReadTagReference();
            misfireDamage = binaryReader.ReadTagReference();
            emptyDamage = binaryReader.ReadTagReference();
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
                binaryWriter.Write(shotCountLowerBound);
                binaryWriter.Write(shotCountUpperBound);
                binaryWriter.Write(firingEffect);
                binaryWriter.Write(misfireEffect);
                binaryWriter.Write(emptyEffect);
                binaryWriter.Write(firingDamage);
                binaryWriter.Write(misfireDamage);
                binaryWriter.Write(emptyDamage);
                return nextAddress;
            }
        }
    };
}