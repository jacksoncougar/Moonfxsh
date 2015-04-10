// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VisibilityStructBlock : VisibilityStructBlockBase
    {
        public  VisibilityStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class VisibilityStructBlockBase
    {
        internal short projectionCount;
        internal short clusterCount;
        internal short volumeCount;
        internal byte[] invalidName_;
        internal byte[] projections;
        internal byte[] visibilityClusters;
        internal byte[] clusterRemapTable;
        internal byte[] visibilityVolumes;
        internal  VisibilityStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            projectionCount = binaryReader.ReadInt16();
            clusterCount = binaryReader.ReadInt16();
            volumeCount = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            projections = ReadData(binaryReader);
            visibilityClusters = ReadData(binaryReader);
            clusterRemapTable = ReadData(binaryReader);
            visibilityVolumes = ReadData(binaryReader);
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
                binaryWriter.Write(projectionCount);
                binaryWriter.Write(clusterCount);
                binaryWriter.Write(volumeCount);
                binaryWriter.Write(invalidName_, 0, 2);
                WriteData(binaryWriter);
                WriteData(binaryWriter);
                WriteData(binaryWriter);
                WriteData(binaryWriter);
            }
        }
    };
}
