using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BitmapGroupSpriteBlock : BitmapGroupSpriteBlockBase
    {
        public  BitmapGroupSpriteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class BitmapGroupSpriteBlockBase
    {
        internal short bitmapIndex;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal float left;
        internal float right;
        internal float top;
        internal float bottom;
        internal OpenTK.Vector2 registrationPoint;
        internal  BitmapGroupSpriteBlockBase(BinaryReader binaryReader)
        {
            this.bitmapIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.left = binaryReader.ReadSingle();
            this.right = binaryReader.ReadSingle();
            this.top = binaryReader.ReadSingle();
            this.bottom = binaryReader.ReadSingle();
            this.registrationPoint = binaryReader.ReadVector2();
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
