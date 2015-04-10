// ReSharper disable All
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
        public  EnvironmentObjectRefs(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  EnvironmentObjectRefsBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            firstSector = binaryReader.ReadInt32();
            lastSector = binaryReader.ReadInt32();
            ReadEnvironmentObjectBspRefsArray(binaryReader);
            ReadEnvironmentObjectNodesArray(binaryReader);
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
        internal  virtual EnvironmentObjectBspRefs[] ReadEnvironmentObjectBspRefsArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual EnvironmentObjectNodes[] ReadEnvironmentObjectNodesArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEnvironmentObjectBspRefsArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEnvironmentObjectNodesArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(firstSector);
                binaryWriter.Write(lastSector);
                WriteEnvironmentObjectBspRefsArray(binaryWriter);
                WriteEnvironmentObjectNodesArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Mobile = 1,
        };
    };
}
