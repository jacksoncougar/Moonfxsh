// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapSceneryObjectInfoBlock : LightmapSceneryObjectInfoBlockBase
    {
        public  LightmapSceneryObjectInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LightmapSceneryObjectInfoBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class LightmapSceneryObjectInfoBlockBase : GuerillaBlock
    {
        internal int uniqueID;
        internal short originBSPIndex;
        internal byte type;
        internal byte source;
        internal int renderModelChecksum;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LightmapSceneryObjectInfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            uniqueID = binaryReader.ReadInt32();
            originBSPIndex = binaryReader.ReadInt16();
            type = binaryReader.ReadByte();
            source = binaryReader.ReadByte();
            renderModelChecksum = binaryReader.ReadInt32();
        }
        public  LightmapSceneryObjectInfoBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            uniqueID = binaryReader.ReadInt32();
            originBSPIndex = binaryReader.ReadInt16();
            type = binaryReader.ReadByte();
            source = binaryReader.ReadByte();
            renderModelChecksum = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(uniqueID);
                binaryWriter.Write(originBSPIndex);
                binaryWriter.Write(type);
                binaryWriter.Write(source);
                binaryWriter.Write(renderModelChecksum);
                return nextAddress;
            }
        }
    };
}
