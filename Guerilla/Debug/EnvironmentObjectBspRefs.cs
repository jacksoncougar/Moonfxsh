// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EnvironmentObjectBspRefs : EnvironmentObjectBspRefsBase
    {
        public  EnvironmentObjectBspRefs(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class EnvironmentObjectBspRefsBase
    {
        internal int bspReference;
        internal int firstSector;
        internal int lastSector;
        internal short nodeIndex;
        internal byte[] invalidName_;
        internal  EnvironmentObjectBspRefsBase(System.IO.BinaryReader binaryReader)
        {
            bspReference = binaryReader.ReadInt32();
            firstSector = binaryReader.ReadInt32();
            lastSector = binaryReader.ReadInt32();
            nodeIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(bspReference);
                binaryWriter.Write(firstSector);
                binaryWriter.Write(lastSector);
                binaryWriter.Write(nodeIndex);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
    };
}
