using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MeleeDamageParametersStructBlock : MeleeDamageParametersStructBlockBase
    {
        public  MeleeDamageParametersStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 76)]
    public class MeleeDamageParametersStructBlockBase
    {
        internal OpenTK.Vector2 damagePyramidAngles;
        internal float damagePyramidDepth;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference invalidName_1StHitMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference invalidName_1StHitMeleeResponse;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference invalidName_2NdHitMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference invalidName_2NdHitMeleeResponse;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference invalidName_3RdHitMeleeDamage;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference invalidName_3RdHitMeleeResponse;
        /// <summary>
        /// this is only important for the energy sword
        /// </summary>
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference lungeMeleeDamage;
        /// <summary>
        /// this is only important for the energy sword
        /// </summary>
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference lungeMeleeResponse;
        internal  MeleeDamageParametersStructBlockBase(BinaryReader binaryReader)
        {
            this.damagePyramidAngles = binaryReader.ReadVector2();
            this.damagePyramidDepth = binaryReader.ReadSingle();
            this.invalidName_1StHitMeleeDamage = binaryReader.ReadTagReference();
            this.invalidName_1StHitMeleeResponse = binaryReader.ReadTagReference();
            this.invalidName_2NdHitMeleeDamage = binaryReader.ReadTagReference();
            this.invalidName_2NdHitMeleeResponse = binaryReader.ReadTagReference();
            this.invalidName_3RdHitMeleeDamage = binaryReader.ReadTagReference();
            this.invalidName_3RdHitMeleeResponse = binaryReader.ReadTagReference();
            this.lungeMeleeDamage = binaryReader.ReadTagReference();
            this.lungeMeleeResponse = binaryReader.ReadTagReference();
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
