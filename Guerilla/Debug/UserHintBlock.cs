// ReSharper disable All
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
        public  UserHintBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  UserHintBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadUserHintPointBlockArray(binaryReader);
            ReadUserHintRayBlockArray(binaryReader);
            ReadUserHintLineSegmentBlockArray(binaryReader);
            ReadUserHintParallelogramBlockArray(binaryReader);
            ReadUserHintPolygonBlockArray(binaryReader);
            ReadUserHintJumpBlockArray(binaryReader);
            ReadUserHintClimbBlockArray(binaryReader);
            ReadUserHintWellBlockArray(binaryReader);
            ReadUserHintFlightBlockArray(binaryReader);
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
        internal  virtual UserHintPointBlock[] ReadUserHintPointBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintRayBlock[] ReadUserHintRayBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintLineSegmentBlock[] ReadUserHintLineSegmentBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintParallelogramBlock[] ReadUserHintParallelogramBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintPolygonBlock[] ReadUserHintPolygonBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintJumpBlock[] ReadUserHintJumpBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintClimbBlock[] ReadUserHintClimbBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintWellBlock[] ReadUserHintWellBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual UserHintFlightBlock[] ReadUserHintFlightBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintRayBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintLineSegmentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintParallelogramBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintPolygonBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintJumpBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintClimbBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintWellBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUserHintFlightBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteUserHintPointBlockArray(binaryWriter);
                WriteUserHintRayBlockArray(binaryWriter);
                WriteUserHintLineSegmentBlockArray(binaryWriter);
                WriteUserHintParallelogramBlockArray(binaryWriter);
                WriteUserHintPolygonBlockArray(binaryWriter);
                WriteUserHintJumpBlockArray(binaryWriter);
                WriteUserHintClimbBlockArray(binaryWriter);
                WriteUserHintWellBlockArray(binaryWriter);
                WriteUserHintFlightBlockArray(binaryWriter);
            }
        }
    };
}
