// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CsPointSetBlock : CsPointSetBlockBase
    {
        public  CsPointSetBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CsPointSetBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class CsPointSetBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal CsPointBlock[] points;
        internal Moonfish.Tags.ShortBlockIndex1 bspIndex;
        internal short manualReferenceFrame;
        internal Flags flags;
        
        public override int SerializedSize{get { return 48; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CsPointSetBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            points = Guerilla.ReadBlockArray<CsPointBlock>(binaryReader);
            bspIndex = binaryReader.ReadShortBlockIndex1();
            manualReferenceFrame = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public  CsPointSetBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<CsPointBlock>(binaryWriter, points, nextAddress);
                binaryWriter.Write(bspIndex);
                binaryWriter.Write(manualReferenceFrame);
                binaryWriter.Write((Int32)flags);
                return nextAddress;
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
