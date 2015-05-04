// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalVisibilityBoundsBlock : GlobalVisibilityBoundsBlockBase
    {
        public  GlobalVisibilityBoundsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalVisibilityBoundsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class GlobalVisibilityBoundsBlockBase : GuerillaBlock
    {
        internal float positionX;
        internal float positionY;
        internal float positionZ;
        internal float radius;
        internal byte node0;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalVisibilityBoundsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            positionX = binaryReader.ReadSingle();
            positionY = binaryReader.ReadSingle();
            positionZ = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            node0 = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
        }
        public  GlobalVisibilityBoundsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            positionX = binaryReader.ReadSingle();
            positionY = binaryReader.ReadSingle();
            positionZ = binaryReader.ReadSingle();
            radius = binaryReader.ReadSingle();
            node0 = binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(3);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(positionX);
                binaryWriter.Write(positionY);
                binaryWriter.Write(positionZ);
                binaryWriter.Write(radius);
                binaryWriter.Write(node0);
                binaryWriter.Write(invalidName_, 0, 3);
                return nextAddress;
            }
        }
    };
}
