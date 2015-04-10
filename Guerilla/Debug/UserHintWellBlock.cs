// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintWellBlock : UserHintWellBlockBase
    {
        public  UserHintWellBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class UserHintWellBlockBase
    {
        internal Flags flags;
        internal UserHintWellPointBlock[] points;
        internal  UserHintWellBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            ReadUserHintWellPointBlockArray(binaryReader);
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
        internal  virtual UserHintWellPointBlock[] ReadUserHintWellPointBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintWellPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintWellPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintWellPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintWellPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                WriteUserHintWellPointBlockArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            Bidirectional = 1,
        };
    };
}
