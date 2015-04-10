using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class OldMaterialsBlock : OldMaterialsBlockBase
    {
        public  OldMaterialsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class OldMaterialsBlockBase
    {
        internal Moonfish.Tags.StringID newMaterialName;
        internal Moonfish.Tags.StringID newGeneralMaterialName;
        /// <summary>
        /// fraction of original velocity parallel to the ground after one tick
        /// </summary>
        internal float groundFrictionScale;
        /// <summary>
        /// cosine of angle at which friction falls off
        /// </summary>
        internal float groundFrictionNormalK1Scale;
        /// <summary>
        /// cosine of angle at which friction is zero
        /// </summary>
        internal float groundFrictionNormalK0Scale;
        /// <summary>
        /// depth a point mass rests in the ground
        /// </summary>
        internal float groundDepthScale;
        /// <summary>
        /// fraction of original velocity perpendicular to the ground after one tick
        /// </summary>
        internal float groundDampFractionScale;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference meleeHitSound;
        internal  OldMaterialsBlockBase(BinaryReader binaryReader)
        {
            this.newMaterialName = binaryReader.ReadStringID();
            this.newGeneralMaterialName = binaryReader.ReadStringID();
            this.groundFrictionScale = binaryReader.ReadSingle();
            this.groundFrictionNormalK1Scale = binaryReader.ReadSingle();
            this.groundFrictionNormalK0Scale = binaryReader.ReadSingle();
            this.groundDepthScale = binaryReader.ReadSingle();
            this.groundDampFractionScale = binaryReader.ReadSingle();
            this.meleeHitSound = binaryReader.ReadTagReference();
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
