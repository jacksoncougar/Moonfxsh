// ReSharper disable All
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
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PointToPathCurveBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 nodeIndex;
        internal byte[] invalidName_;
        internal PointToPathCurvePointBlock[] points;
        internal  PointToPathCurveBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            nodeIndex = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            points = Guerilla.ReadBlockArray<PointToPathCurvePointBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<PointToPathCurvePointBlock>(binaryWriter, points, nextAddress);
                return nextAddress;
            }
        }
    };
}
