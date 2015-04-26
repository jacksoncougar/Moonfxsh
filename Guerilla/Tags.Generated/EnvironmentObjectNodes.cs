// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EnvironmentObjectNodes : EnvironmentObjectNodesBase
    {
        public  EnvironmentObjectNodes(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class EnvironmentObjectNodesBase  : IGuerilla
    {
        internal short referenceFrameIndex;
        internal byte projectionAxis;
        internal ProjectionSign projectionSign;
        internal  EnvironmentObjectNodesBase(BinaryReader binaryReader)
        {
            referenceFrameIndex = binaryReader.ReadInt16();
            projectionAxis = binaryReader.ReadByte();
            projectionSign = (ProjectionSign)binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(referenceFrameIndex);
                binaryWriter.Write(projectionAxis);
                binaryWriter.Write((Byte)projectionSign);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum ProjectionSign : byte
        {
            ProjectionSign = 1,
        };
    };
}
