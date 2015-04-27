// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalSubpartsBlock : GlobalSubpartsBlockBase
    {
        public  GlobalSubpartsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalSubpartsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class GlobalSubpartsBlockBase : GuerillaBlock
    {
        internal short indicesStartIndex;
        internal short indicesLength;
        internal short visibilityBoundsIndex;
        internal short partIndex;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalSubpartsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            indicesStartIndex = binaryReader.ReadInt16();
            indicesLength = binaryReader.ReadInt16();
            visibilityBoundsIndex = binaryReader.ReadInt16();
            partIndex = binaryReader.ReadInt16();
        }
        public  GlobalSubpartsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(indicesStartIndex);
                binaryWriter.Write(indicesLength);
                binaryWriter.Write(visibilityBoundsIndex);
                binaryWriter.Write(partIndex);
                return nextAddress;
            }
        }
    };
}
