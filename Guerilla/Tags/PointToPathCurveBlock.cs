using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PointToPathCurveBlock : PointToPathCurveBlockBase
    {
        public  PointToPathCurveBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class PointToPathCurveBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 nodeIndex;
        internal byte[] invalidName_;
        internal PointToPathCurvePointBlock[] points;
        internal  PointToPathCurveBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.nodeIndex = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.points = ReadPointToPathCurvePointBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual PointToPathCurvePointBlock[] ReadPointToPathCurvePointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PointToPathCurvePointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PointToPathCurvePointBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PointToPathCurvePointBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
