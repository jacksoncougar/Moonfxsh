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
        public  EnvironmentObjectBspRefs(BinaryReader binaryReader): base(binaryReader)
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
        internal  EnvironmentObjectBspRefsBase(BinaryReader binaryReader)
        {
            this.bspReference = binaryReader.ReadInt32();
            this.firstSector = binaryReader.ReadInt32();
            this.lastSector = binaryReader.ReadInt32();
            this.nodeIndex = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
