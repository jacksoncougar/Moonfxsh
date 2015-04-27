// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrecacheListBlock : PrecacheListBlockBase
    {
        public  PrecacheListBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PrecacheListBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class PrecacheListBlockBase : GuerillaBlock
    {
        internal int cacheBlockIndex;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PrecacheListBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            cacheBlockIndex = binaryReader.ReadInt32();
        }
        public  PrecacheListBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(cacheBlockIndex);
                return nextAddress;
            }
        }
    };
}
