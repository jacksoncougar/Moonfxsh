// ReSharper disable All
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
        public  LightmapSceneryObjectInfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  LightmapSceneryObjectInfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            uniqueID = binaryReader.ReadInt32();
            originBSPIndex = binaryReader.ReadInt16();
            type = binaryReader.ReadByte();
            source = binaryReader.ReadByte();
            renderModelChecksum = binaryReader.ReadInt32();
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
                binaryWriter.Write(uniqueID);
                binaryWriter.Write(originBSPIndex);
                binaryWriter.Write(type);
                binaryWriter.Write(source);
                binaryWriter.Write(renderModelChecksum);
            }
        }
    };
}
