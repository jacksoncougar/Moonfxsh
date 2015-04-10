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
        public  VisibilityStructBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  VisibilityStructBlockBase(BinaryReader binaryReader)
        {
            this.projectionCount = binaryReader.ReadInt16();
            this.clusterCount = binaryReader.ReadInt16();
            this.volumeCount = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.projections = ReadData(binaryReader);
            this.visibilityClusters = ReadData(binaryReader);
            this.clusterRemapTable = ReadData(binaryReader);
            this.visibilityVolumes = ReadData(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
