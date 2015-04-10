// ReSharper disable All
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
        public  GlobalVisibilityBoundsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalVisibilityBoundsBlockBase(System.IO.BinaryReader binaryReader)
        {
            positionX = binaryReader.ReadSingle();
            positionY = binaryReader.ReadSingle();
            positionZ = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            node0 = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
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
                binaryWriter.Write(positionX);
                binaryWriter.Write(positionY);
                binaryWriter.Write(positionZ);
                binaryWriter.Write(radius);
                binaryWriter.Write(node0);
                binaryWriter.Write(invalidName_, 0, 3);
            }
        }
    };
}
