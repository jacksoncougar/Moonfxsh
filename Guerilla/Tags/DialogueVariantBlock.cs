using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DialogueVariantBlock : DialogueVariantBlockBase
    {
        public  DialogueVariantBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class DialogueVariantBlockBase
    {
        /// <summary>
        /// variantNumber to use this dialogue with (must match the suffix in the permutations on the unit's model)
        /// </summary>
        internal short variantNumber;
        internal byte[] invalidName_;
        [TagReference("udlg")]
        internal Moonfish.Tags.TagReference dialogue;
        internal  DialogueVariantBlockBase(BinaryReader binaryReader)
        {
            this.variantNumber = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.dialogue = binaryReader.ReadTagReference();
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
