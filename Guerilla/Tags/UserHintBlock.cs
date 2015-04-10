using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintBlock : UserHintBlockBase
    {
        public  UserHintBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class UserHintBlockBase
    {
        internal UserHintPointBlock[] pointGeometry;
        internal UserHintRayBlock[] rayGeometry;
        internal UserHintLineSegmentBlock[] lineSegmentGeometry;
        internal UserHintParallelogramBlock[] parallelogramGeometry;
        internal UserHintPolygonBlock[] polygonGeometry;
        internal UserHintJumpBlock[] jumpHints;
        internal UserHintClimbBlock[] climbHints;
        internal UserHintWellBlock[] wellHints;
        internal UserHintFlightBlock[] flightHints;
        internal  UserHintBlockBase(BinaryReader binaryReader)
        {
            this.pointGeometry = ReadUserHintPointBlockArray(binaryReader);
            this.rayGeometry = ReadUserHintRayBlockArray(binaryReader);
            this.lineSegmentGeometry = ReadUserHintLineSegmentBlockArray(binaryReader);
            this.parallelogramGeometry = ReadUserHintParallelogramBlockArray(binaryReader);
            this.polygonGeometry = ReadUserHintPolygonBlockArray(binaryReader);
            this.jumpHints = ReadUserHintJumpBlockArray(binaryReader);
            this.climbHints = ReadUserHintClimbBlockArray(binaryReader);
            this.wellHints = ReadUserHintWellBlockArray(binaryReader);
            this.flightHints = ReadUserHintFlightBlockArray(binaryReader);
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
        internal  virtual UserHintRayBlock[] ReadUserHintRayBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintRayBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintRayBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintRayBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintLineSegmentBlock[] ReadUserHintLineSegmentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintLineSegmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintLineSegmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintLineSegmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintParallelogramBlock[] ReadUserHintParallelogramBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintParallelogramBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintParallelogramBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintParallelogramBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintPolygonBlock[] ReadUserHintPolygonBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintPolygonBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintPolygonBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintPolygonBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintJumpBlock[] ReadUserHintJumpBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintJumpBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintJumpBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintJumpBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintClimbBlock[] ReadUserHintClimbBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintClimbBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintClimbBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintClimbBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintWellBlock[] ReadUserHintWellBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintWellBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintWellBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintWellBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual UserHintFlightBlock[] ReadUserHintFlightBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UserHintFlightBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UserHintFlightBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UserHintFlightBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
