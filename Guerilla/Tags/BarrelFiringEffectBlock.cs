using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BarrelFiringEffectBlock : BarrelFiringEffectBlockBase
    {
        public  BarrelFiringEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class BarrelFiringEffectBlockBase
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
        [TagReference("null")]
        internal Moonfish.Tags.TagReference firingEffect;
        /// <summary>
        /// this effect is used when the weapon is loaded but fired while overheated
        /// </summary>
        [TagReference("null")]
        internal Moonfish.Tags.TagReference misfireEffect;
        /// <summary>
        /// this effect is used when the weapon is not loaded
        /// </summary>
        [TagReference("null")]
        internal Moonfish.Tags.TagReference emptyEffect;
        /// <summary>
        /// this effect is used when the weapon is loaded and fired normally
        /// </summary>
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference firingDamage;
        /// <summary>
        /// this effect is used when the weapon is loaded but fired while overheated
        /// </summary>
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference misfireDamage;
        /// <summary>
        /// this effect is used when the weapon is not loaded
        /// </summary>
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference emptyDamage;
        internal  BarrelFiringEffectBlockBase(BinaryReader binaryReader)
        {
            this.shotCountLowerBound = binaryReader.ReadInt16();
            this.shotCountUpperBound = binaryReader.ReadInt16();
            this.firingEffect = binaryReader.ReadTagReference();
            this.misfireEffect = binaryReader.ReadTagReference();
            this.emptyEffect = binaryReader.ReadTagReference();
            this.firingDamage = binaryReader.ReadTagReference();
            this.misfireDamage = binaryReader.ReadTagReference();
            this.emptyDamage = binaryReader.ReadTagReference();
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
