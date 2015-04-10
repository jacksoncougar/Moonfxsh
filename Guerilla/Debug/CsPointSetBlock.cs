// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CsPointSetBlock : CsPointSetBlockBase
    {
        public  CsPointSetBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class CsPointSetBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal CsPointBlock[] points;
        internal Moonfish.Tags.ShortBlockIndex1 bspIndex;
        internal short manualReferenceFrame;
        internal Flags flags;
        internal  CsPointSetBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            ReadCsPointBlockArray(binaryReader);
            bspIndex = binaryReader.ReadShortBlockIndex1();
            manualReferenceFrame = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
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
        internal  virtual CsPointBlock[] ReadCsPointBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CsPointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CsPointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CsPointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCsPointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                WriteCsPointBlockArray(binaryWriter);
                binaryWriter.Write(bspIndex);
                binaryWriter.Write(manualReferenceFrame);
                binaryWriter.Write((Int32)flags);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ManualReferenceFrame = 1,
            TurretDeployment = 2,
        };
    };
}
