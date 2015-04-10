// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGestaltPlaybackBlock : SoundGestaltPlaybackBlockBase
    {
        public  SoundGestaltPlaybackBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class SoundGestaltPlaybackBlockBase
    {
        internal SoundPlaybackParametersStructBlock soundPlaybackParametersStruct;
        internal  SoundGestaltPlaybackBlockBase(System.IO.BinaryReader binaryReader)
        {
            soundPlaybackParametersStruct = new SoundPlaybackParametersStructBlock(binaryReader);
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
                soundPlaybackParametersStruct.Write(binaryWriter);
            }
        }
    };
}
