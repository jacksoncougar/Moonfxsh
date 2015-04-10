// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPlaybackParameterDefinitionBlock : SoundPlaybackParameterDefinitionBlockBase
    {
        public  SoundPlaybackParameterDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SoundPlaybackParameterDefinitionBlockBase
    {
        internal Moonfish.Model.Range scaleBounds;
        internal Moonfish.Model.Range randomBaseAndVariance;
        internal  SoundPlaybackParameterDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            scaleBounds = binaryReader.ReadRange();
            randomBaseAndVariance = binaryReader.ReadRange();
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
                binaryWriter.Write(scaleBounds);
                binaryWriter.Write(randomBaseAndVariance);
            }
        }
    };
}
