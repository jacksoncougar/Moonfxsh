using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightmapSceneryObjectInfoBlock : LightmapSceneryObjectInfoBlockBase
    {
        public  LightmapSceneryObjectInfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class LightmapSceneryObjectInfoBlockBase
    {
        internal int uniqueID;
        internal short originBSPIndex;
        internal byte type;
        internal byte source;
        internal int renderModelChecksum;
        internal  LightmapSceneryObjectInfoBlockBase(BinaryReader binaryReader)
        {
            this.uniqueID = binaryReader.ReadInt32();
            this.originBSPIndex = binaryReader.ReadInt16();
            this.type = binaryReader.ReadByte();
            this.source = binaryReader.ReadByte();
            this.renderModelChecksum = binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
