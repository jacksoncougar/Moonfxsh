// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightmapSceneryObjectInfoBlock : LightmapSceneryObjectInfoBlockBase
    {
        public LightmapSceneryObjectInfoBlock() : base()
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

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LightmapSceneryObjectInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            uniqueID = binaryReader.ReadInt32();
            originBSPIndex = binaryReader.ReadInt16();
            type = binaryReader.ReadByte();
            source = binaryReader.ReadByte();
            renderModelChecksum = binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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