// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationBlendScreenBlock : AnimationBlendScreenBlockBase
    {
        public  AnimationBlendScreenBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class AnimationBlendScreenBlockBase
    {
        internal Moonfish.Tags.StringID label;
        internal AnimationAimingScreenStructBlock aimingScreen;
        internal  AnimationBlendScreenBlockBase(System.IO.BinaryReader binaryReader)
        {
            label = binaryReader.ReadStringID();
            aimingScreen = new AnimationAimingScreenStructBlock(binaryReader);
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
                binaryWriter.Write(label);
                aimingScreen.Write(binaryWriter);
            }
        }
    };
}
