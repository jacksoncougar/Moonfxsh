// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PointToPathCurvePointBlock : PointToPathCurvePointBlockBase
    {
        public  PointToPathCurvePointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class PointToPathCurvePointBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 position;
        internal float tValue;
        internal  PointToPathCurvePointBlockBase(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            tValue = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
