// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SurfacesBlock : SurfacesBlockBase
    {
        public  SurfacesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class SurfacesBlockBase
    {
        internal short plane;
        internal short firstEdge;
        internal Flags flags;
        internal byte breakableSurface;
        internal short material;
        internal  SurfacesBlockBase(System.IO.BinaryReader binaryReader)
        {
            plane = binaryReader.ReadInt16();
            firstEdge = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadByte();
            breakableSurface = binaryReader.ReadByte();
            material = binaryReader.ReadInt16();
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
                binaryWriter.Write(plane);
                binaryWriter.Write(firstEdge);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(breakableSurface);
                binaryWriter.Write(material);
            }
        }
        [FlagsAttribute]
        internal enum Flags : byte
        
        {
            TwoSided = 1,
            Invisible = 2,
            Climbable = 4,
            Breakable = 8,
            Invalid = 16,
            Conveyor = 32,
        };
    };
}
