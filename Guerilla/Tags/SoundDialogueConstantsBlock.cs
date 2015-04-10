using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("spk!")]
    public  partial class SoundDialogueConstantsBlock : SoundDialogueConstantsBlockBase
    {
        public  SoundDialogueConstantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class SoundDialogueConstantsBlockBase
    {
        internal float almostNever;
        internal float rarely;
        internal float somewhat;
        internal float often;
        internal byte[] invalidName_;
        internal  SoundDialogueConstantsBlockBase(BinaryReader binaryReader)
        {
            this.almostNever = binaryReader.ReadSingle();
            this.rarely = binaryReader.ReadSingle();
            this.somewhat = binaryReader.ReadSingle();
            this.often = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(24);
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
