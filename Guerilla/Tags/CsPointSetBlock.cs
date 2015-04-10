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
        public  CsPointSetBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  CsPointSetBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.points = ReadCsPointBlockArray(binaryReader);
            this.bspIndex = binaryReader.ReadShortBlockIndex1();
            this.manualReferenceFrame = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
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
        internal  virtual CsPointBlock[] ReadCsPointBlockArray(BinaryReader binaryReader)
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
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ManualReferenceFrame = 1,
            TurretDeployment = 2,
        };
    };
}
