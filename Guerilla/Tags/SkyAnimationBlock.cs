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
        public  SkyAnimationBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SkyAnimationBlockBase(BinaryReader binaryReader)
        {
            this.animationIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.periodSec = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(28);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
