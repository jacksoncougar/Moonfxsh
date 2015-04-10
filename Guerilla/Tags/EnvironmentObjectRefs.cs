using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EnvironmentObjectRefs : EnvironmentObjectRefsBase
    {
        public  EnvironmentObjectRefs(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class EnvironmentObjectRefsBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal int firstSector;
        internal int lastSector;
        internal EnvironmentObjectBspRefs[] bsps;
        internal EnvironmentObjectNodes[] nodes;
        internal  EnvironmentObjectRefsBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.firstSector = binaryReader.ReadInt32();
            this.lastSector = binaryReader.ReadInt32();
            this.bsps = ReadEnvironmentObjectBspRefsArray(binaryReader);
            this.nodes = ReadEnvironmentObjectNodesArray(binaryReader);
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
        internal  virtual EnvironmentObjectBspRefs[] ReadEnvironmentObjectBspRefsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EnvironmentObjectBspRefs));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EnvironmentObjectBspRefs[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EnvironmentObjectBspRefs(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EnvironmentObjectNodes[] ReadEnvironmentObjectNodesArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EnvironmentObjectNodes));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EnvironmentObjectNodes[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EnvironmentObjectNodes(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Mobile = 1,
        };
    };
}
