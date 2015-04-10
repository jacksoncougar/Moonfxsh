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
        public  EnvironmentObjectNodes(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class EnvironmentObjectNodesBase
    {
        internal short referenceFrameIndex;
        internal byte projectionAxis;
        internal ProjectionSign projectionSign;
        internal  EnvironmentObjectNodesBase(System.IO.BinaryReader binaryReader)
        {
            referenceFrameIndex = binaryReader.ReadInt16();
            projectionAxis = binaryReader.ReadByte();
            projectionSign = (ProjectionSign)binaryReader.ReadByte();
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(referenceFrameIndex);
                binaryWriter.Write(projectionAxis);
                binaryWriter.Write((Byte)projectionSign);
            }
        }
        [FlagsAttribute]
        internal enum ProjectionSign : byte
        
        {
            ProjectionSign = 1,
        };
    };
}
