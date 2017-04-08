using System.IO;
using Moonfish.Tags;

namespace Moonfish.Cache
{
    public class TagIndexBase
    {
        protected internal const int HeaderSize = 32;

        public int classArrayAddress;
        public int classArrayCount;
        public int datumArrayAddress;
        public TagIdent ScenarioIdent { get; set; }
        public TagIdent GlobalsIdent { get; set; }
        public int _noodleValue;
        public int datumArrayCount;
        private readonly TagClass fourCC;

        protected TagIndexBase(Map cache)
        {
            var binaryReader = new BinaryReader(cache.BaseStream);
            classArrayAddress = binaryReader.ReadInt32();
            classArrayCount = binaryReader.ReadInt32();
            datumArrayAddress = binaryReader.ReadInt32();
            ScenarioIdent = binaryReader.ReadTagIdent();
            GlobalsIdent = binaryReader.ReadTagIdent();
            _noodleValue = binaryReader.ReadInt32();
            datumArrayCount = binaryReader.ReadInt32();
            fourCC = binaryReader.ReadTagClass();
            if (fourCC != new TagClass("tags")) throw new InvalidDataException();
        }

        protected byte[] SerializeHeader()
        {
            MemoryStream stream = new MemoryStream(HeaderSize);
            BinaryWriter binaryWriter = new BinaryWriter(stream);
            binaryWriter.Write(classArrayAddress);
            binaryWriter.Write(classArrayCount);
            binaryWriter.Write(datumArrayAddress);
            binaryWriter.Write(ScenarioIdent);
            binaryWriter.Write(GlobalsIdent);
            binaryWriter.Write((int)0);
            binaryWriter.Write(datumArrayCount);
            binaryWriter.Write(fourCC);
            return stream.GetBuffer();
        }
    }
}