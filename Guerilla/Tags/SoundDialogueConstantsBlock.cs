// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Spk!Class = (TagClass)"spk!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("spk!")]
    public  partial class SoundDialogueConstantsBlock : SoundDialogueConstantsBlockBase
    {
        public  SoundDialogueConstantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class SoundDialogueConstantsBlockBase  : IGuerilla
    {
        internal float almostNever;
        internal float rarely;
        internal float somewhat;
        internal float often;
        internal byte[] invalidName_;
        internal  SoundDialogueConstantsBlockBase(BinaryReader binaryReader)
        {
            almostNever = binaryReader.ReadSingle();
            rarely = binaryReader.ReadSingle();
            somewhat = binaryReader.ReadSingle();
            often = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(almostNever);
                binaryWriter.Write(rarely);
                binaryWriter.Write(somewhat);
                binaryWriter.Write(often);
                binaryWriter.Write(invalidName_, 0, 24);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
