// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyAnimationBlock : SkyAnimationBlockBase
    {
        public  SkyAnimationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class SkyAnimationBlockBase
    {
        /// <summary>
        /// Index of the animation in the animation graph.
        /// </summary>
        internal short animationIndex;
        internal byte[] invalidName_;
        internal float periodSec;
        internal byte[] invalidName_0;
        internal  SkyAnimationBlockBase(System.IO.BinaryReader binaryReader)
        {
            animationIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            periodSec = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(28);
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
                binaryWriter.Write(animationIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(periodSec);
                binaryWriter.Write(invalidName_0, 0, 28);
            }
        }
    };
}
