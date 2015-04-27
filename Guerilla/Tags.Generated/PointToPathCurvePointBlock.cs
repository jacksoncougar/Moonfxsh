// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PointToPathCurvePointBlock : PointToPathCurvePointBlockBase
    {
        public  PointToPathCurvePointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PointToPathCurvePointBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PointToPathCurvePointBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal float tValue;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PointToPathCurvePointBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            position = binaryReader.ReadVector3();
            tValue = binaryReader.ReadSingle();
        }
        public  PointToPathCurvePointBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            tValue = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                binaryWriter.Write(tValue);
                return nextAddress;
            }
        }
    };
}
