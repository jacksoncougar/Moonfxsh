using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintPolygonBlock : UserHintPolygonBlockBase
    {
        public  UserHintPolygonBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class UserHintPolygonBlockBase
    {
        internal Flags flags;
        internal UserHintPointBlock[] points;
        internal  UserHintPolygonBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.points = ReadUserHintPointBlockArray(binaryReader);
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
        internal  virtual UserHintPointBlock[] ReadUserHintPointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintPointBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Bidirectional = 1,
            Closed = 2,
        };
    };
}
