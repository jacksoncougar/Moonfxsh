// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalGeometrySectionStripIndexBlock : GlobalGeometrySectionStripIndexBlockBase
    {
        public  GlobalGeometrySectionStripIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalGeometrySectionStripIndexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class GlobalGeometrySectionStripIndexBlockBase : GuerillaBlock
    {
        internal short index;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalGeometrySectionStripIndexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            index = binaryReader.ReadInt16();
        }
        public  GlobalGeometrySectionStripIndexBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            index = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                return nextAddress;
            }
        }
    };
}
