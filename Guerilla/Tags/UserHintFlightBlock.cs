using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintFlightBlock : UserHintFlightBlockBase
    {
        public  UserHintFlightBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class UserHintFlightBlockBase
    {
        internal UserHintFlightPointBlock[] points;
        internal  UserHintFlightBlockBase(BinaryReader binaryReader)
        {
            this.points = ReadUserHintFlightPointBlockArray(binaryReader);
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
        internal  virtual UserHintFlightPointBlock[] ReadUserHintFlightPointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintFlightPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintFlightPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintFlightPointBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
