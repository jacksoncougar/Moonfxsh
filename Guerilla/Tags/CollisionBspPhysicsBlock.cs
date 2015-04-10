using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionBspPhysicsBlock : CollisionBspPhysicsBlockBase
    {
        public  CollisionBspPhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 112)]
    public class CollisionBspPhysicsBlockBase
    {
        internal byte[] invalidName_;
        internal short size;
        internal short count;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal short size0;
        internal short count0;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal short size1;
        internal short count1;
        internal byte[] invalidName_8;
        internal byte[] invalidName_9;
        internal byte[] moppCodeData;
        internal byte[] padding;
        internal  CollisionBspPhysicsBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.size = binaryReader.ReadInt16();
            this.count = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.invalidName_2 = binaryReader.ReadBytes(32);
            this.invalidName_3 = binaryReader.ReadBytes(16);
            this.invalidName_4 = binaryReader.ReadBytes(4);
            this.size0 = binaryReader.ReadInt16();
            this.count0 = binaryReader.ReadInt16();
            this.invalidName_5 = binaryReader.ReadBytes(4);
            this.invalidName_6 = binaryReader.ReadBytes(4);
            this.invalidName_7 = binaryReader.ReadBytes(4);
            this.size1 = binaryReader.ReadInt16();
            this.count1 = binaryReader.ReadInt16();
            this.invalidName_8 = binaryReader.ReadBytes(4);
            this.invalidName_9 = binaryReader.ReadBytes(8);
            this.moppCodeData = ReadData(binaryReader);
            this.padding = binaryReader.ReadBytes(4);
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
