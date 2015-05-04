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
    public partial class OldMaterialsBlock : OldMaterialsBlockBase
    {
        public OldMaterialsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class OldMaterialsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent newMaterialName;
        internal Moonfish.Tags.StringIdent newGeneralMaterialName;
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
        public override int SerializedSize { get { return 36; } }
        public override int Alignment { get { return 4; } }
        public OldMaterialsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            newMaterialName = binaryReader.ReadStringID();
            newGeneralMaterialName = binaryReader.ReadStringID();
            groundFrictionScale = binaryReader.ReadSingle();
            groundFrictionNormalK1Scale = binaryReader.ReadSingle();
            groundFrictionNormalK0Scale = binaryReader.ReadSingle();
            groundDepthScale = binaryReader.ReadSingle();
            groundDampFractionScale = binaryReader.ReadSingle();
            meleeHitSound = binaryReader.ReadTagReference();
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
                binaryWriter.Write(newMaterialName);
                binaryWriter.Write(newGeneralMaterialName);
                binaryWriter.Write(groundFrictionScale);
                binaryWriter.Write(groundFrictionNormalK1Scale);
                binaryWriter.Write(groundFrictionNormalK0Scale);
                binaryWriter.Write(groundDepthScale);
                binaryWriter.Write(groundDampFractionScale);
                binaryWriter.Write(meleeHitSound);
                return nextAddress;
            }
        }
    };
}
