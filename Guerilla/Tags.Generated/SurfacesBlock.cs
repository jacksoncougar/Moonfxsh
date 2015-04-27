// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SurfacesBlock : SurfacesBlockBase
    {
        public  SurfacesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SurfacesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 8)]
    public class SurfacesBlockBase : GuerillaBlock
    {
        internal short plane;
        internal short firstEdge;
        internal Flags flags;
        internal byte breakableSurface;
        internal short material;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 8; }}
        
        public  SurfacesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            plane = binaryReader.ReadInt16();
            firstEdge = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadByte();
            breakableSurface = binaryReader.ReadByte();
            material = binaryReader.ReadInt16();
        }
        public  SurfacesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            plane = binaryReader.ReadInt16();
            firstEdge = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadByte();
            breakableSurface = binaryReader.ReadByte();
            material = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(plane);
                binaryWriter.Write(firstEdge);
                binaryWriter.Write((Byte)flags);
                binaryWriter.Write(breakableSurface);
                binaryWriter.Write(material);
                return nextAddress;
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
