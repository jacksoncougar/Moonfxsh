// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionBspPhysicsBlock : CollisionBspPhysicsBlockBase
    {
        public  CollisionBspPhysicsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CollisionBspPhysicsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 112, Alignment = 16)]
    public class CollisionBspPhysicsBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 112; }}
        
        
        public override int Alignment{get { return 16; }}
        
        public  CollisionBspPhysicsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(4);
            invalidName_2 = binaryReader.ReadBytes(32);
            invalidName_3 = binaryReader.ReadBytes(16);
            invalidName_4 = binaryReader.ReadBytes(4);
            size0 = binaryReader.ReadInt16();
            count0 = binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(4);
            invalidName_6 = binaryReader.ReadBytes(4);
            invalidName_7 = binaryReader.ReadBytes(4);
            size1 = binaryReader.ReadInt16();
            count1 = binaryReader.ReadInt16();
            invalidName_8 = binaryReader.ReadBytes(4);
            invalidName_9 = binaryReader.ReadBytes(8);
            moppCodeData = Guerilla.ReadData(binaryReader);
            padding = binaryReader.ReadBytes(4);
        }
        public  CollisionBspPhysicsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            size = binaryReader.ReadInt16();
            count = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(4);
            invalidName_1 = binaryReader.ReadBytes(4);
            invalidName_2 = binaryReader.ReadBytes(32);
            invalidName_3 = binaryReader.ReadBytes(16);
            invalidName_4 = binaryReader.ReadBytes(4);
            size0 = binaryReader.ReadInt16();
            count0 = binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(4);
            invalidName_6 = binaryReader.ReadBytes(4);
            invalidName_7 = binaryReader.ReadBytes(4);
            size1 = binaryReader.ReadInt16();
            count1 = binaryReader.ReadInt16();
            invalidName_8 = binaryReader.ReadBytes(4);
            invalidName_9 = binaryReader.ReadBytes(8);
            moppCodeData = Guerilla.ReadData(binaryReader);
            padding = binaryReader.ReadBytes(4);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(size);
                binaryWriter.Write(count);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(invalidName_2, 0, 32);
                binaryWriter.Write(invalidName_3, 0, 16);
                binaryWriter.Write(invalidName_4, 0, 4);
                binaryWriter.Write(size0);
                binaryWriter.Write(count0);
                binaryWriter.Write(invalidName_5, 0, 4);
                binaryWriter.Write(invalidName_6, 0, 4);
                binaryWriter.Write(invalidName_7, 0, 4);
                binaryWriter.Write(size1);
                binaryWriter.Write(count1);
                binaryWriter.Write(invalidName_8, 0, 4);
                binaryWriter.Write(invalidName_9, 0, 8);
                nextAddress = Guerilla.WriteData(binaryWriter, moppCodeData, nextAddress);
                binaryWriter.Write(padding, 0, 4);
                return nextAddress;
            }
        }
    };
}
