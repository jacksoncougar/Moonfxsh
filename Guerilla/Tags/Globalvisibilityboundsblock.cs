using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalVisibilityBoundsBlock : GlobalVisibilityBoundsBlockBase
    {
        public  GlobalVisibilityBoundsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class GlobalVisibilityBoundsBlockBase
    {
        internal float positionX;
        internal float positionY;
        internal float positionZ;
        internal float radius;
        internal byte node0;
        internal byte[] invalidName_;
        internal  GlobalVisibilityBoundsBlockBase(BinaryReader binaryReader)
        {
            this.positionX = binaryReader.ReadSingle();
            this.positionY = binaryReader.ReadSingle();
            this.positionZ = binaryReader.ReadSingle();
            this.radius = binaryReader.ReadSingle();
            this.node0 = binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(3);
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
