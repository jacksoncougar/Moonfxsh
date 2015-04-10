// ReSharper disable All
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
        public  SoundDialogueConstantsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundDialogueConstantsBlockBase(System.IO.BinaryReader binaryReader)
        {
            almostNever = binaryReader.ReadSingle();
            rarely = binaryReader.ReadSingle();
            somewhat = binaryReader.ReadSingle();
            often = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(almostNever);
                binaryWriter.Write(rarely);
                binaryWriter.Write(somewhat);
                binaryWriter.Write(often);
                binaryWriter.Write(invalidName_, 0, 24);
            }
        }
    };
}
