using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CsPointBlock : CsPointBlockBase
    {
        public  CsPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class CsPointBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal int surfaceIndex;
        internal OpenTK.Vector2 facingDirection;
        internal  CsPointBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.position = binaryReader.ReadVector3();
            this.referenceFrame = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.surfaceIndex = binaryReader.ReadInt32();
            this.facingDirection = binaryReader.ReadVector2();
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
