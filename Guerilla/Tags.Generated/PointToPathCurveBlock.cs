// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PointToPathCurveBlock : PointToPathCurveBlockBase
    {
        public  PointToPathCurveBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PointToPathCurveBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PointToPathCurveBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Moonfish.Tags.ShortBlockIndex1 nodeIndex;
        internal byte[] invalidName_;
        internal PointToPathCurvePointBlock[] points;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PointToPathCurveBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            nodeIndex = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            points = Guerilla.ReadBlockArray<PointToPathCurvePointBlock>(binaryReader);
        }
        public  PointToPathCurveBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            nodeIndex = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            points = Guerilla.ReadBlockArray<PointToPathCurvePointBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
